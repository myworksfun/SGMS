using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using StudentGradeManagementSystem.Data;
using StudentGradeManagementSystem.Models;

namespace StudentGradeManagementSystem.Forms
{
    public partial class ScoreReportForm : Form
    {
        private ScoreRepository _scoreRepository = new ScoreRepository();
        private CourseRepository _courseRepository = new CourseRepository();
        private StudentRepository _studentRepository = new StudentRepository();
        
        public ScoreReportForm()
        {
            InitializeComponent();
        }
        
        private void ScoreReportForm_Load(object sender, EventArgs e)
        {
            LoadCourses();
            LoadStudents();
            LoadReportData();
        }
        
        private void LoadCourses()
        {
            try
            {
                var courses = _courseRepository.GetAllCourses();
                cmbCourse.DisplayMember = "Name";
                cmbCourse.ValueMember = "CourseId";
                cmbCourse.Items.Add(new { Name = "全部课程", CourseId = "" });
                
                foreach (var course in courses)
                {
                    cmbCourse.Items.Add(course);
                }
                
                cmbCourse.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("加载课程数据时发生错误: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void LoadStudents()
        {
            try
            {
                var students = _studentRepository.GetAllStudents();
                cmbStudent.DisplayMember = "Name";
                cmbStudent.ValueMember = "StudentId";
                cmbStudent.Items.Add(new { Name = "全部学生", StudentId = "" });
                
                foreach (var student in students)
                {
                    cmbStudent.Items.Add(student);
                }
                
                cmbStudent.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("加载学生数据时发生错误: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void LoadReportData()
        {
            try
            {
                var scores = _scoreRepository.GetAllScores();
                
                // 根据筛选条件过滤数据
                string selectedCourseId = "";
                string selectedStudentId = "";
                
                if (cmbCourse.SelectedItem != null && cmbCourse.SelectedIndex > 0)
                {
                    var selectedCourse = cmbCourse.SelectedItem as Course;
                    selectedCourseId = selectedCourse?.course_id ?? "";
                }
                
                if (cmbStudent.SelectedItem != null && cmbStudent.SelectedIndex > 0)
                {
                    var selectedStudent = cmbStudent.SelectedItem as Student;
                    selectedStudentId = selectedStudent?.student_id ?? "";
                }
                
                // 应用筛选条件
                var filteredScores = scores.Where(s => 
                    (string.IsNullOrEmpty(selectedCourseId) || s.course_id == selectedCourseId) &&
                    (string.IsNullOrEmpty(selectedStudentId) || s.student_id == selectedStudentId)
                ).ToList();
                
                // 绑定到数据网格
                dataGridViewScores.DataSource = filteredScores;
                
                // 设置列标题为中文
                if (dataGridViewScores.Columns["Id"] != null)
                    dataGridViewScores.Columns["Id"].HeaderText = "ID";
                    
                if (dataGridViewScores.Columns["student_id"] != null)
                    dataGridViewScores.Columns["student_id"].HeaderText = "学号";
                    
                if (dataGridViewScores.Columns["StudentName"] != null)
                    dataGridViewScores.Columns["StudentName"].HeaderText = "学生姓名";
                    
                if (dataGridViewScores.Columns["course_id"] != null)
                    dataGridViewScores.Columns["course_id"].HeaderText = "课程代码";
                    
                if (dataGridViewScores.Columns["CourseName"] != null)
                    dataGridViewScores.Columns["CourseName"].HeaderText = "课程名称";
                    
                if (dataGridViewScores.Columns["score"] != null)
                    dataGridViewScores.Columns["score"].HeaderText = "成绩";
                    
                if (dataGridViewScores.Columns["term"] != null)
                    dataGridViewScores.Columns["term"].HeaderText = "学期";
                    
                if (dataGridViewScores.Columns["exam_date"] != null)
                    dataGridViewScores.Columns["exam_date"].HeaderText = "考试日期";
                    
                if (dataGridViewScores.Columns["CreatedAt"] != null)
                    dataGridViewScores.Columns["CreatedAt"].HeaderText = "创建时间";
                    
                if (dataGridViewScores.Columns["UpdatedAt"] != null)
                    dataGridViewScores.Columns["UpdatedAt"].HeaderText = "更新时间";
                
                // 计算统计信息
                CalculateStatistics(filteredScores);
            }
            catch (Exception ex)
            {
                MessageBox.Show("加载报表数据时发生错误: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void CalculateStatistics(List<Score> scores)
        {
            if (scores.Count == 0)
            {
                lblTotalCount.Text = "总记录数: 0";
                lblAverageScore.Text = "平均分: 0.00";
                lblHighestScore.Text = "最高分: 0.00";
                lblLowestScore.Text = "最低分: 0.00";
                lblPassRate.Text = "及格率: 0.00%";
                return;
            }
            
            lblTotalCount.Text = $"总记录数: {scores.Count}";
            lblAverageScore.Text = $"平均分: {scores.Average(s => s.score):F2}";
            lblHighestScore.Text = $"最高分: {scores.Max(s => s.score):F2}";
            lblLowestScore.Text = $"最低分: {scores.Min(s => s.score):F2}";
            
            // 计算及格率（假设60分及格）
            int passCount = scores.Count(s => s.score >= 60);
            double passRate = (double)passCount / scores.Count * 100;
            lblPassRate.Text = $"及格率: {passRate:F2}%";
        }
        
        private void btnFilter_Click(object sender, EventArgs e)
        {
            LoadReportData();
        }
        
        private void btnReset_Click(object sender, EventArgs e)
        {
            cmbCourse.SelectedIndex = 0;
            cmbStudent.SelectedIndex = 0;
            LoadReportData();
        }
    }
}