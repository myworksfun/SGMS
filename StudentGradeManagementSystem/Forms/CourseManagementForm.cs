using System;
using System.Collections.Generic;
using System.Windows.Forms;
using StudentGradeManagementSystem.Data;
using StudentGradeManagementSystem.Models;
using StudentGradeManagementSystem.Services;
using StudentGradeManagementSystem.Controls;

namespace StudentGradeManagementSystem.Forms
{
    public partial class CourseManagementForm : Form
    {
        private CourseRepository _courseRepository = new CourseRepository();
        private TeacherRepository _teacherRepository = new TeacherRepository(); // 添加教师Repository
        private ExcelService _excelService = new ExcelService();
        private bool _isEditMode = false;
        private int _currentCourseId = 0;
        
        // 分页相关字段
        private int _currentPage = 1;
        private int _pageSize = 20;
        private int _totalCourses = 0;
        private int _totalPages = 0;
        
        public CourseManagementForm()
        {
            InitializeComponent();
        }
        
        private void CourseManagementForm_Load(object sender, EventArgs e)
        {
            // 富文本编辑支持
            txtDescription.Multiline = true;
            txtDescription.ScrollBars = ScrollBars.Vertical;
            // 订阅分页控件的事件
            paginationControl.PageChanged += PaginationControl_PageChanged;
            paginationControl.InitializePagination();
            
            LoadCoursesByPage(_currentPage, _pageSize);
            // 初始化按钮状态
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
        }
        
        private void LoadTeachers()
        {
            try
            {
                var teachers = _teacherRepository.GetAllTeachers();
                // 添加空选项作为默认选择
                var teacherList = new List<Teacher>();
                teacherList.Add(new Teacher { TeacherId = "", Name = "请选择教师" });
                teacherList.AddRange(teachers);
                
                cmbTeacher.DataSource = teacherList;
                cmbTeacher.DisplayMember = "Name";
                cmbTeacher.ValueMember = "TeacherId";
            }
            catch (Exception ex)
            {
                MessageBox.Show("加载教师数据时发生错误: " + ex.Message + "\n堆栈跟踪: " + ex.StackTrace, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void LoadCourseTypes()
        {
            try
            {
                // 课程类型列表
                var courseTypes = new List<string> { "必修", "选修", "实践" };
                
                // 清空现有项
                txtType.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"加载课程类型时发生错误: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        // 分页控件页码更改事件处理
        private void PaginationControl_PageChanged(object sender, PageChangedEventArgs e)
        {
            LoadCoursesByPage(e.CurrentPage, e.PageSize);
        }
        
        // 加载分页数据
        private void LoadCoursesByPage(int pageNumber, int pageSize)
        {
            try
            {
                var allCourses = _courseRepository.GetAllCourses();
                _totalCourses = allCourses.Count;
                
                // 手动实现分页
                var courses = allCourses.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
                
                dataGridViewCourses.DataSource = courses;
                
                // 更新分页信息
                _currentPage = pageNumber;
                _pageSize = pageSize;
                _totalPages = (int)Math.Ceiling((double)_totalCourses / pageSize);
                
                // 更新分页控件显示
                paginationControl.CurrentPage = _currentPage;
                paginationControl.PageSize = _pageSize;
                paginationControl.TotalItems = _totalCourses;
                
                // 设置列标题
                if (dataGridViewCourses.Columns["Id"] != null)
                    dataGridViewCourses.Columns["Id"].Visible = false;
                    
                if (dataGridViewCourses.Columns["course_id"] != null)
                    dataGridViewCourses.Columns["course_id"].HeaderText = "课程代码";
                    
                if (dataGridViewCourses.Columns["Name"] != null)
                    dataGridViewCourses.Columns["Name"].HeaderText = "课程名称";
                    
                if (dataGridViewCourses.Columns["TeacherId"] != null)
                    dataGridViewCourses.Columns["TeacherId"].HeaderText = "教师工号";
                    
                if (dataGridViewCourses.Columns["TeacherName"] != null)
                    dataGridViewCourses.Columns["TeacherName"].HeaderText = "授课教师";
                    
                if (dataGridViewCourses.Columns["Credit"] != null)
                    dataGridViewCourses.Columns["Credit"].HeaderText = "学分";
                    
                if (dataGridViewCourses.Columns["Type"] != null)
                    dataGridViewCourses.Columns["Type"].HeaderText = "课程类型";
                    
                if (dataGridViewCourses.Columns["Description"] != null)
                    dataGridViewCourses.Columns["Description"].HeaderText = "课程描述";
                    
                if (dataGridViewCourses.Columns["CreatedAt"] != null)
                    dataGridViewCourses.Columns["CreatedAt"].HeaderText = "创建时间";
                    dataGridViewCourses.Columns["CreatedAt"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                    
                if (dataGridViewCourses.Columns["UpdatedAt"] != null)
                    dataGridViewCourses.Columns["UpdatedAt"].HeaderText = "更新时间";
                    dataGridViewCourses.Columns["UpdatedAt"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"加载课程数据时发生错误: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        // 重写LoadCourses方法以使用分页
        private void LoadCourses()
        {
            LoadCoursesByPage(_currentPage, _pageSize);
        }
        
        // 刷新按钮点击事件
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadCourses();
        }
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            _isEditMode = false;
            ClearForm();
            groupBoxCourseDetails.Enabled = true;
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
        }
        
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewCourses.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择要编辑的课程", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            _isEditMode = true;
            var selectedCourse = (Course)dataGridViewCourses.SelectedRows[0].DataBoundItem;
            _currentCourseId = selectedCourse.Id;
            
            txtCourseId.Text = selectedCourse.course_id;
            txtName.Text = selectedCourse.Name;
            // 设置教师选择
            if (!string.IsNullOrEmpty(selectedCourse.TeacherId))
            {
                cmbTeacher.SelectedValue = selectedCourse.TeacherId;
            }
            else
            {
                cmbTeacher.SelectedIndex = 0; // 选择默认项
            }
            if (selectedCourse.Credit >= numCredit.Minimum && selectedCourse.Credit <= numCredit.Maximum)
                numCredit.Value = selectedCourse.Credit;
            else
                numCredit.Value = 1; // 默认学分
            // 设置课程类型
            txtType.Text = selectedCourse.Type;

            txtDescription.Text = selectedCourse.Description;
            
            groupBoxCourseDetails.Enabled = true;
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
        }
        
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewCourses.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择要删除的课程", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            var result = MessageBox.Show("确定要删除选中的课程吗？", "确认删除", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
                return;
            
            try
            {
                var selectedCourse = (Course)dataGridViewCourses.SelectedRows[0].DataBoundItem;
                bool success = _courseRepository.DeleteCourse(selectedCourse.Id);
                
                if (success)
                {
                    MessageBox.Show("课程删除成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCourses();
                }
                else
                {
                    MessageBox.Show("课程删除失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("删除课程时发生错误: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // 创建课程对象
                var course = new Course
                {
                    course_id = txtCourseId.Text.Trim(),
                    Name = txtName.Text.Trim(),
                    TeacherId = string.IsNullOrEmpty(cmbTeacher.SelectedValue?.ToString()) ? null : cmbTeacher.SelectedValue?.ToString(),
                    TeacherName = cmbTeacher.Text,
                    Credit = (int)numCredit.Value,
                    Type = txtType.Text,
                    Description = txtDescription.Text.Trim()
                };

                // 验证课程信息
                var (isValid, errorMessage) = course.Validate();
                if (!isValid)
                {
                    MessageBox.Show(errorMessage, "验证失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (_isEditMode)
                {
                    // 编辑模式
                    course.Id = _currentCourseId;
                    if (_courseRepository.UpdateCourse(course))
                    {
                        MessageBox.Show("课程信息更新成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("课程信息更新失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    // 新增模式
                    if (_courseRepository.AddCourse(course))
                    {
                        MessageBox.Show("课程信息添加成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("课程信息添加失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // 重置表单状态
                groupBoxCourseDetails.Enabled = false;
                btnSave.Enabled = false;
                btnCancel.Enabled = false;

                // 重新加载数据
                LoadCourses();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存课程信息时发生错误: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearForm();
            groupBoxCourseDetails.Enabled = false;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            UpdateButtonStates();
        }
        
        private void ClearForm()
        {
            _isEditMode = false;
            _currentCourseId = 0;
            
            txtCourseId.Text = "";
            txtName.Text = "";
            if (cmbTeacher.Items.Count > 0)
                cmbTeacher.SelectedIndex = 0; // 选择默认项
            numCredit.Value = 1; // 默认学分
            txtType.Text = ""; // 清空文本
            txtDescription.Text = "";
            
            txtCourseId.Enabled = true;
            
            // 更新按钮状态
            UpdateButtonStates();
        }
        
        private void ClearCourseDetails()
        {
            txtCourseId.Text = "";
            txtName.Text = "";
            txtType.Text = "";
            if (cmbTeacher.Items.Count > 0)
                cmbTeacher.SelectedIndex = -1;
            numCredit.Value = 1;
            txtDescription.Text = "";
            
            groupBoxCourseDetails.Enabled = false;
            btnAdd.Enabled = true;
            btnEdit.Enabled = false;
        }
        
        private void UpdateButtonStates()
        {
            btnAdd.Enabled = true;
            btnEdit.Enabled = dataGridViewCourses.SelectedRows.Count > 0;
            btnDelete.Enabled = dataGridViewCourses.SelectedRows.Count > 0;
        }
        
        private void dataGridViewCourses_SelectionChanged(object sender, EventArgs e)
        {
            UpdateButtonStates();
        }
        
        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel文件|*.xlsx";
                saveFileDialog.Title = "导出课程信息到Excel";
                
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var courses = _courseRepository.GetAllCourses();
                    bool success = _excelService.ExportCoursesToExcel(courses, saveFileDialog.FileName);
                    
                    if (success)
                    {
                        MessageBox.Show("课程信息导出成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("课程信息导出失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("导出课程信息时发生错误: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}