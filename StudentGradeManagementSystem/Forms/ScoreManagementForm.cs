using System;
using System.Collections.Generic;
using System.Windows.Forms;
using StudentGradeManagementSystem.Data;
using StudentGradeManagementSystem.Models;
using StudentGradeManagementSystem.Services;
using StudentGradeManagementSystem.Controls;

namespace StudentGradeManagementSystem.Forms
{
    public partial class ScoreManagementForm : Form
    {
        private ScoreRepository _scoreRepository = new ScoreRepository();
        private StudentRepository _studentRepository = new StudentRepository();
        private CourseRepository _courseRepository = new CourseRepository();
        private ExcelService _excelService = new ExcelService();
        private bool _isEditMode = false;
        private int _currentScoreId = 0;
        
        // 分页相关字段
        private int _currentPage = 1;
        private int _pageSize = 20;
        private int _totalScores = 0;
        private int _totalPages = 0;
        
        public ScoreManagementForm()
        {
            InitializeComponent();
        }
        
        private void ScoreManagementForm_Load(object sender, EventArgs e)
        {
            // 批量录入按钮
            // btnBatchImport.Visible = true;
            // btnBatchImport.Click += BtnBatchImport_Click;
            // 订阅分页控件的事件
            paginationControl.PageChanged += PaginationControl_PageChanged;
            paginationControl.InitializePagination();
            
            LoadScoresByPage(_currentPage, _pageSize);
            // 初始化按钮状态
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
        }
        
        private void ScoreManagementForm_Shown(object sender, EventArgs e)
        {
            // 每次显示窗体时重新加载学生和课程列表，确保数据是最新的
            LoadStudentsAndCourses();
        }
        
        // 分页控件页码更改事件处理
        private void PaginationControl_PageChanged(object sender, PageChangedEventArgs e)
        {
            LoadScoresByPage(e.CurrentPage, e.PageSize);
        }
        
        // 添加这个方法以解决设计器中的引用问题
        private void paginationControl_PageChanged(object sender, PageChangedEventArgs e)
        {
            LoadScoresByPage(e.CurrentPage, e.PageSize);
        }
        
        // 加载分页数据
        private void LoadScoresByPage(int pageNumber, int pageSize)
        {
            try
            {
                var scores = _scoreRepository.GetScoresByPage(pageNumber, pageSize, out _totalScores);
                dataGridViewScores.DataSource = scores;
                
                // 更新分页信息
                _currentPage = pageNumber;
                _pageSize = pageSize;
                _totalPages = (int)Math.Ceiling((double)_totalScores / pageSize);
                
                // 更新分页控件显示
                paginationControl.CurrentPage = _currentPage;
                paginationControl.PageSize = _pageSize;
                paginationControl.TotalItems = _totalScores;
                
                // 设置列标题
                if (dataGridViewScores.Columns["Id"] != null)
                    dataGridViewScores.Columns["Id"].Visible = false;
                    
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
                else if (dataGridViewScores.Columns["Score"] != null)
                    dataGridViewScores.Columns["score"].HeaderText = "成绩";
                    
                if (dataGridViewScores.Columns["term"] != null)
                    dataGridViewScores.Columns["term"].HeaderText = "学期";
                else if (dataGridViewScores.Columns["Semester"] != null)
                    dataGridViewScores.Columns["term"].HeaderText = "学期";
                    
                if (dataGridViewScores.Columns["exam_date"] != null)
                    dataGridViewScores.Columns["exam_date"].HeaderText = "考试日期";
                    
                if (dataGridViewScores.Columns["CreatedAt"] != null)
                    dataGridViewScores.Columns["CreatedAt"].HeaderText = "创建时间";
                    
                if (dataGridViewScores.Columns["UpdatedAt"] != null)
                    dataGridViewScores.Columns["UpdatedAt"].HeaderText = "更新时间";
                    
                // 更新按钮状态
                UpdateButtonStates();
            }
            catch (Exception ex)
            {
                MessageBox.Show("加载成绩数据时发生错误: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        // 重写LoadScores方法以使用分页
        private void LoadScores()
        {
            LoadScoresByPage(_currentPage, _pageSize);
        }
        
        // 刷新按钮点击事件
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadScores();
        }
        
        private void LoadStudentsAndCourses()
        {
            try
            {
                // 加载学生列表
                var students = _studentRepository.GetAllStudents();
                // 添加空选项作为默认选择
                var studentList = new List<Student>();
                studentList.Add(new Student { student_id = "", Name = "请选择学生" });
                studentList.AddRange(students);
                
                cmbStudent.DataSource = studentList;
                cmbStudent.DisplayMember = "Name";
                cmbStudent.ValueMember = "student_id";
                
                // 加载课程列表
                var courses = _courseRepository.GetAllCourses();
                // 添加空选项作为默认选择
                var courseList = new List<Course>();
                courseList.Add(new Course { course_id = "", Name = "请选择课程" });
                courseList.AddRange(courses);
                
                cmbCourse.DataSource = courseList;
                cmbCourse.DisplayMember = "Name";
                cmbCourse.ValueMember = "course_id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("加载学生或课程数据时发生错误: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            _isEditMode = false;
            ClearForm();
            groupBoxScoreDetails.Enabled = true;
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
        }
        
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewScores.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择要编辑的成绩", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            _isEditMode = true;
            var selectedScore = (Score)dataGridViewScores.SelectedRows[0].DataBoundItem;
            _currentScoreId = selectedScore.Id;
            
            // 设置学生选择
            if (!string.IsNullOrEmpty(selectedScore.student_id))
            {
                cmbStudent.SelectedValue = selectedScore.student_id;
            }
            else
            {
                cmbStudent.SelectedIndex = 0; // 选择默认项
            }
            
            // 设置课程选择
            if (!string.IsNullOrEmpty(selectedScore.course_id))
            {
                cmbCourse.SelectedValue = selectedScore.course_id;
            }
            else
            {
                cmbCourse.SelectedIndex = 0; // 选择默认项
            }
            
            if (selectedScore.score >= numScore.Minimum && selectedScore.score <= numScore.Maximum)
                numScore.Value = selectedScore.score;
            else
                numScore.Value = 0; // 默认成绩
            
            txtSemester.Text = selectedScore.term;
            dtpExamDate.Value = selectedScore.exam_date ?? DateTime.Now;
            
            groupBoxScoreDetails.Enabled = true;
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
        }
        
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewScores.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择要删除的成绩", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            var selectedScore = (Score)dataGridViewScores.SelectedRows[0].DataBoundItem;
            
            var result = MessageBox.Show($"确定要删除 {selectedScore.StudentName} 的 {selectedScore.CourseName} 成绩吗？", "确认删除", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
            if (result == DialogResult.Yes)
            {
                try
                {
                    if (_scoreRepository.DeleteScore(selectedScore.Id))
                    {
                        MessageBox.Show("成绩删除成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadScores();
                    }
                    else
                    {
                        MessageBox.Show("成绩删除失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("删除成绩时发生错误: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // 数据验证
                if (cmbStudent.SelectedValue == null || string.IsNullOrEmpty(cmbStudent.SelectedValue.ToString()) || cmbStudent.SelectedIndex == 0)
                {
                    MessageBox.Show("请选择学生", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbStudent.Focus();
                    return;
                }
                
                if (cmbCourse.SelectedValue == null || string.IsNullOrEmpty(cmbCourse.SelectedValue.ToString()) || cmbCourse.SelectedIndex == 0)
                {
                    MessageBox.Show("请选择课程", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbCourse.Focus();
                    return;
                }
                
                // 创建成绩对象
                var score = new Score
                {
                    student_id = cmbStudent.SelectedValue.ToString() ?? "", 
                    StudentName = cmbStudent.Text,
                    course_id = cmbCourse.SelectedValue.ToString() ?? "", 
                    CourseName = cmbCourse.Text,
                    score = numScore.Value, 
                    term = txtSemester.Text.Trim(), 
                    exam_date = dtpExamDate.Value
                };

                // 验证成绩信息
                var (isValid, errorMessage) = score.Validate();
                if (!isValid)
                {
                    MessageBox.Show(errorMessage, "验证失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (_isEditMode)
                {
                    // 编辑模式
                    score.Id = _currentScoreId;
                    if (_scoreRepository.UpdateScore(score))
                    {
                        MessageBox.Show("成绩信息更新成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("成绩信息更新失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    // 新增模式
                    if (_scoreRepository.AddScore(score))
                    {
                        MessageBox.Show("成绩信息添加成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("成绩信息添加失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                
                // 重置表单状态
                groupBoxScoreDetails.Enabled = false;
                btnSave.Enabled = false;
                btnCancel.Enabled = false;
                
                // 重新加载数据
                LoadScores();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存成绩信息时发生错误: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearForm();
            groupBoxScoreDetails.Enabled = false;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            UpdateButtonStates();
        }
        
        private void ClearForm()
        {
            cmbStudent.SelectedIndex = 0; // 重置为默认选项
            cmbCourse.SelectedIndex = 0;  // 重置为默认选项
            numScore.Value = 0;
            txtSemester.Text = "";
            dtpExamDate.Value = DateTime.Now;
            _currentScoreId = 0;
        }
        
        private void UpdateButtonStates()
        {
            btnAdd.Enabled = true;
            btnEdit.Enabled = dataGridViewScores.SelectedRows.Count > 0;
            btnDelete.Enabled = dataGridViewScores.SelectedRows.Count > 0;
        }
        
        private void dataGridViewScores_SelectionChanged(object sender, EventArgs e)
        {
            UpdateButtonStates();
        }
        
        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                var scores = _scoreRepository.GetAllScores();
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel文件|*.xlsx";
                saveFileDialog.Title = "选择导出文件保存位置";
                
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (_excelService.ExportScoresToExcel(scores, saveFileDialog.FileName))
                    {
                        MessageBox.Show($"成绩数据已导出到: {saveFileDialog.FileName}", "导出成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("导出成绩数据失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("导出成绩数据时发生错误: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Excel文件|*.xlsx";
                openFileDialog.Title = "选择要导入的成绩数据文件";
                
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var scores = _excelService.ImportScoresFromExcel(openFileDialog.FileName);
                    int successCount = 0;
                    int failCount = 0;
                    
                    foreach (var score in scores)
                    {
                        try
                        {
                            // 验证导入的成绩数据
                            var (isValid, errorMessage) = score.Validate();
                            if (isValid)
                            {
                                if (_scoreRepository.AddScore(score))
                                {
                                    successCount++;
                                }
                                else
                                {
                                    failCount++;
                                }
                            }
                            else
                            {
                                failCount++;
                            }
                        }
                        catch
                        {
                            failCount++;
                        }
                    }
                    
                    MessageBox.Show($"成功导入 {successCount} 条成绩数据，失败 {failCount} 条", "导入完成", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadScores();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("导入成绩数据时发生错误: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}