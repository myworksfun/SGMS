using System;
using System.Collections.Generic;
using System.Windows.Forms;
using StudentGradeManagementSystem.Data;
using StudentGradeManagementSystem.Models;
using StudentGradeManagementSystem.Services;
using StudentGradeManagementSystem.Controls;

namespace StudentGradeManagementSystem.Forms
{
    public partial class TeacherManagementForm : Form
    {
        private TeacherRepository _teacherRepository = new TeacherRepository();
        private ExcelService _excelService = new ExcelService();
        private bool _isEditMode = false;
        private int _currentTeacherId = 0;
        
        // 分页相关字段
        private int _currentPage = 1;
        private int _pageSize = 20;
        private int _totalTeachers = 0;
        private int _totalPages = 0;
        
        public TeacherManagementForm()
        {
            InitializeComponent();
        }
        
        private void TeacherManagementForm_Load(object sender, EventArgs e)
        {
            // 表单分组边框
            groupBoxTeacherDetails.FlatStyle = FlatStyle.Flat;
            // 订阅分页控件的事件
            paginationControl.PageChanged += PaginationControl_PageChanged;
            paginationControl.InitializePagination();
            
            LoadTeachersByPage(_currentPage, _pageSize);
            // 初始化按钮状态
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
        }
        
        // 分页控件页码更改事件处理
        private void PaginationControl_PageChanged(object sender, PageChangedEventArgs e)
        {
            LoadTeachersByPage(e.CurrentPage, e.PageSize);
        }
        
        // 加载分页数据
        private void LoadTeachersByPage(int pageNumber, int pageSize)
        {
            try
            {
                var teachers = _teacherRepository.GetTeachersByPage(pageNumber, pageSize, out _totalTeachers);
                dataGridViewTeachers.DataSource = teachers;
                
                // 更新分页信息
                _currentPage = pageNumber;
                _pageSize = pageSize;
                _totalPages = (int)Math.Ceiling((double)_totalTeachers / pageSize);
                
                // 更新分页控件显示
                paginationControl.CurrentPage = _currentPage;
                paginationControl.PageSize = _pageSize;
                paginationControl.TotalItems = _totalTeachers;
                
                // 设置列标题
                if (dataGridViewTeachers.Columns["Id"] != null)
                    dataGridViewTeachers.Columns["Id"].Visible = false;
                    
                if (dataGridViewTeachers.Columns["TeacherId"] != null)
                    dataGridViewTeachers.Columns["TeacherId"].HeaderText = "工号";
                    
                if (dataGridViewTeachers.Columns["Name"] != null)
                    dataGridViewTeachers.Columns["Name"].HeaderText = "姓名";
                    
                if (dataGridViewTeachers.Columns["Gender"] != null)
                    dataGridViewTeachers.Columns["Gender"].HeaderText = "性别";
                    
                if (dataGridViewTeachers.Columns["Age"] != null)
                    dataGridViewTeachers.Columns["Age"].HeaderText = "年龄";
                    
                if (dataGridViewTeachers.Columns["Department"] != null)
                    dataGridViewTeachers.Columns["Department"].HeaderText = "部门";
                    
                if (dataGridViewTeachers.Columns["Title"] != null)
                    dataGridViewTeachers.Columns["Title"].HeaderText = "职称";
                    
                if (dataGridViewTeachers.Columns["Phone"] != null)
                    dataGridViewTeachers.Columns["Phone"].HeaderText = "电话";
                    
                if (dataGridViewTeachers.Columns["Email"] != null)
                    dataGridViewTeachers.Columns["Email"].HeaderText = "邮箱";
                    
                if (dataGridViewTeachers.Columns["CreatedAt"] != null)
                    dataGridViewTeachers.Columns["CreatedAt"].HeaderText = "创建时间";
                    
                if (dataGridViewTeachers.Columns["UpdatedAt"] != null)
                    dataGridViewTeachers.Columns["UpdatedAt"].HeaderText = "更新时间";
                    
                // 更新按钮状态
                UpdateButtonStates();
            }
            catch (Exception ex)
            {
                MessageBox.Show("加载教师数据时发生错误: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        // 重写LoadTeachers方法以使用分页
        private void LoadTeachers()
        {
            LoadTeachersByPage(_currentPage, _pageSize);
        }
        
        // 刷新按钮点击事件
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadTeachers();
        }
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            _isEditMode = false;
            ClearForm();
            groupBoxTeacherDetails.Enabled = true;
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
        }
        
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewTeachers.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择要编辑的教师", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            _isEditMode = true;
            var selectedTeacher = (Teacher)dataGridViewTeachers.SelectedRows[0].DataBoundItem;
            _currentTeacherId = selectedTeacher.Id;
            
            txtTeacherId.Text = selectedTeacher.TeacherId;
            txtName.Text = selectedTeacher.Name;
            cmbGender.Text = selectedTeacher.Gender;
            if (selectedTeacher.Age >= numAge.Minimum && selectedTeacher.Age <= numAge.Maximum)
                numAge.Value = selectedTeacher.Age;
            else
                numAge.Value = 30; // 默认年龄
            txtDepartment.Text = selectedTeacher.Department;
            txtTitle.Text = selectedTeacher.Title;
            txtPhone.Text = selectedTeacher.Phone;
            txtEmail.Text = selectedTeacher.Email;
            
            groupBoxTeacherDetails.Enabled = true;
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
        }
        
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewTeachers.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择要删除的教师", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            var result = MessageBox.Show("确定要删除选中的教师吗？", "确认删除", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
                return;
            
            try
            {
                var selectedTeacher = (Teacher)dataGridViewTeachers.SelectedRows[0].DataBoundItem;
                bool success = _teacherRepository.DeleteTeacher(selectedTeacher.Id);
                
                if (success)
                {
                    MessageBox.Show("教师删除成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadTeachers();
                }
                else
                {
                    MessageBox.Show("教师删除失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("删除教师时发生错误: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // 创建教师对象
                var teacher = new Teacher
                {
                    TeacherId = txtTeacherId.Text.Trim(),
                    Name = txtName.Text.Trim(),
                    Gender = cmbGender.Text,
                    Age = (int)numAge.Value,
                    Department = txtDepartment.Text.Trim(),
                    Title = txtTitle.Text.Trim(),
                    Phone = txtPhone.Text.Trim(),
                    Email = txtEmail.Text.Trim()
                };

                // 验证教师信息
                var (isValid, errorMessage) = teacher.Validate();
                if (!isValid)
                {
                    MessageBox.Show(errorMessage, "验证失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (_isEditMode)
                {
                    // 编辑模式
                    teacher.Id = _currentTeacherId;
                    if (_teacherRepository.UpdateTeacher(teacher))
                    {
                        MessageBox.Show("教师信息更新成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("教师信息更新失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    // 新增模式
                    if (_teacherRepository.AddTeacher(teacher))
                    {
                        MessageBox.Show("教师信息添加成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("教师信息添加失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // 重置表单状态
                groupBoxTeacherDetails.Enabled = false;
                btnSave.Enabled = false;
                btnCancel.Enabled = false;
                
                // 重新加载数据
                LoadTeachers();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存教师信息时发生错误: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearForm();
            groupBoxTeacherDetails.Enabled = false;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            UpdateButtonStates();
        }
        
        private void ClearForm()
        {
            txtTeacherId.Text = "";
            txtName.Text = "";
            cmbGender.SelectedIndex = -1;
            numAge.Value = 30;
            txtDepartment.Text = "";
            txtTitle.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            _currentTeacherId = 0;
        }
        
        private void UpdateButtonStates()
        {
            btnAdd.Enabled = true;
            btnEdit.Enabled = dataGridViewTeachers.SelectedRows.Count > 0;
            btnDelete.Enabled = dataGridViewTeachers.SelectedRows.Count > 0;
        }
        
        private void dataGridViewTeachers_SelectionChanged(object sender, EventArgs e)
        {
            UpdateButtonStates();
        }
        
        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel文件|*.xlsx";
                saveFileDialog.Title = "导出教师信息到Excel";
                
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var teachers = _teacherRepository.GetAllTeachers();
                    bool success = _excelService.ExportTeachersToExcel(teachers, saveFileDialog.FileName);
                    
                    if (success)
                    {
                        MessageBox.Show("教师信息导出成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("教师信息导出失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("导出教师信息时发生错误: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}