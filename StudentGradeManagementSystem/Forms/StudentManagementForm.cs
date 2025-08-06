using System;
using System.Windows.Forms;
using StudentGradeManagementSystem.Models;
using StudentGradeManagementSystem.Data;
using StudentGradeManagementSystem.Services;
using System.Collections.Generic;
using StudentGradeManagementSystem.Controls;

namespace StudentGradeManagementSystem.Forms
{
    public partial class StudentManagementForm : Form
    {
        private StudentRepository _studentRepository;
        private ExcelService _excelService = new ExcelService();
        private bool _isEditMode = false;
        private int _currentStudentId = 0;

        // 分页相关字段
        private int _currentPage = 1;
        private int _pageSize = 20;
        private int _totalStudents = 0;
        private int _totalPages = 0;

        public StudentManagementForm()
        {
            InitializeComponent();
            _studentRepository = new StudentRepository(); // 确保 StudentRepository 正确实例化
        }

        private void StudentManagementForm_Load(object sender, EventArgs e)
        {
            // 订阅分页控件的事件
            paginationControl.PageChanged += PaginationControl_PageChanged;
            paginationControl.InitializePagination();

            LoadStudentsByPage(_currentPage, _pageSize);
            // 初始化按钮状态
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;

            // 初始化学生详细信息区域控件
            groupBoxStudentDetails.Enabled = false;

            // 创建一个新的 TableLayoutPanel 来管理控件布局
            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.ColumnCount = 4;
            tableLayoutPanel.RowCount = 6;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            // 添加控件到 TableLayoutPanel
            tableLayoutPanel.Controls.Add(new Label { Text = "学号：" }, 0, 0);
            tableLayoutPanel.Controls.Add(txtStudentId, 1, 0);
            tableLayoutPanel.Controls.Add(new Label { Text = "姓名：" }, 2, 0);
            tableLayoutPanel.Controls.Add(txtName, 3, 0);

            tableLayoutPanel.Controls.Add(new Label { Text = "性别：" }, 0, 1);
            tableLayoutPanel.Controls.Add(cmbGender, 1, 1);
            tableLayoutPanel.Controls.Add(new Label { Text = "年龄：" }, 2, 1);
            tableLayoutPanel.Controls.Add(numAge, 3, 1);

            tableLayoutPanel.Controls.Add(new Label { Text = "班级：" }, 0, 2);
            tableLayoutPanel.Controls.Add(txtClass, 1, 2);
            tableLayoutPanel.Controls.Add(new Label { Text = "专业：" }, 2, 2);
            tableLayoutPanel.Controls.Add(txtMajor, 3, 2);

            tableLayoutPanel.Controls.Add(new Label { Text = "电话：" }, 0, 3);
            tableLayoutPanel.Controls.Add(txtPhone, 1, 3);
            tableLayoutPanel.Controls.Add(new Label { Text = "邮箱：" }, 2, 3);
            tableLayoutPanel.Controls.Add(txtEmail, 3, 3);

            tableLayoutPanel.Controls.Add(new Label { Text = "入学时间：" }, 0, 4);
            tableLayoutPanel.Controls.Add(dtpEnrollmentDate, 1, 4);

            // 将 TableLayoutPanel 添加到 groupBoxStudentDetails 中
            groupBoxStudentDetails.Controls.Clear();
            groupBoxStudentDetails.Controls.Add(tableLayoutPanel);
        }

        // 分页控件页码更改事件处理
        private void PaginationControl_PageChanged(object sender, PageChangedEventArgs e)
        {
            LoadStudentsByPage(e.CurrentPage, e.PageSize);
        }

        // 加载分页数据
        private void LoadStudentsByPage(int pageNumber, int pageSize)
        {
            // 斑马纹效果
            dataGridViewStudents.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.LightGray;
            try
            {
                // 获取当前用户信息
                var currentUser = CurrentUser.GetCurrentUser();

                var students = _studentRepository.GetStudentsByPage(pageNumber, pageSize, out _totalStudents, currentUser?.Id ?? 0);
                dataGridViewStudents.DataSource = students;

                // 更新分页信息
                _currentPage = pageNumber;
                _pageSize = pageSize;
                _totalPages = (int)Math.Ceiling((double)_totalStudents / pageSize);

                // 更新分页控件显示
                paginationControl.CurrentPage = _currentPage;
                paginationControl.PageSize = _pageSize;
                paginationControl.TotalItems = _totalStudents;

                // 设置列标题
                if (dataGridViewStudents.Columns["Id"] != null)
                    dataGridViewStudents.Columns["Id"].Visible = false;

                if (dataGridViewStudents.Columns["StudentId"] != null)
                    dataGridViewStudents.Columns["StudentId"].HeaderText = "学号";

                if (dataGridViewStudents.Columns["Name"] != null)
                    dataGridViewStudents.Columns["Name"].HeaderText = "姓名";

                if (dataGridViewStudents.Columns["Gender"] != null)
                    dataGridViewStudents.Columns["Gender"].HeaderText = "性别";

                if (dataGridViewStudents.Columns["Age"] != null)
                    dataGridViewStudents.Columns["Age"].HeaderText = "年龄";

                if (dataGridViewStudents.Columns["Class"] != null)
                    dataGridViewStudents.Columns["Class"].HeaderText = "班级";

                if (dataGridViewStudents.Columns["Major"] != null)
                    dataGridViewStudents.Columns["Major"].HeaderText = "专业";

                if (dataGridViewStudents.Columns["Phone"] != null)
                    dataGridViewStudents.Columns["Phone"].HeaderText = "电话";

                if (dataGridViewStudents.Columns["Email"] != null)
                    dataGridViewStudents.Columns["Email"].HeaderText = "邮箱";

                if (dataGridViewStudents.Columns["CreatedAt"] != null)
                    dataGridViewStudents.Columns["CreatedAt"].HeaderText = "创建时间";

                if (dataGridViewStudents.Columns["UpdatedAt"] != null)
                    dataGridViewStudents.Columns["UpdatedAt"].HeaderText = "更新时间";

                if (dataGridViewStudents.Columns["EnrollmentDate"] != null)
                    dataGridViewStudents.Columns["EnrollmentDate"].HeaderText = "入学时间";

                // 更新按钮状态
                UpdateButtonStates();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"加载学生数据时发生错误: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 刷新按钮点击事件
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadStudentsByPage(_currentPage, _pageSize);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _isEditMode = false;
            ClearForm();
            groupBoxStudentDetails.Enabled = true;
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewStudents.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择要编辑的学生", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _isEditMode = true;
            var selectedStudent = (Student)dataGridViewStudents.SelectedRows[0].DataBoundItem;
            _currentStudentId = selectedStudent.Id;

            txtStudentId.Text = selectedStudent.student_id;
            txtName.Text = selectedStudent.Name;
            cmbGender.SelectedItem = selectedStudent.Gender;
            numAge.Value = selectedStudent.Age;
            txtClass.Text = selectedStudent.Class;
            txtMajor.Text = selectedStudent.Major;
            txtPhone.Text = selectedStudent.Phone;
            txtEmail.Text = selectedStudent.Email;
            dtpEnrollmentDate.Value = selectedStudent.EnrollmentDate ?? DateTime.Now;

            groupBoxStudentDetails.Enabled = true;
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewStudents.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择要删除的学生", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show("确定要删除选中的学生吗？", "确认删除", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
                return;

            try
            {
                var selectedStudent = (Student)dataGridViewStudents.SelectedRows[0].DataBoundItem;
                // 获取当前用户信息
                var currentUser = CurrentUser.GetCurrentUser();
                bool success = _studentRepository.DeleteStudent(selectedStudent.student_id, currentUser?.Id ?? 0, currentUser?.Username ?? "Unknown");

                if (success)
                {
                    MessageBox.Show("学生删除成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadStudentsByPage(_currentPage, _pageSize);
                }
                else
                {
                    MessageBox.Show("学生删除失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"删除学生时发生错误: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // 创建学生对象
                var student = new Student
                {
                    student_id = txtStudentId.Text.Trim(),
                    Name = txtName.Text.Trim(),
                    Gender = cmbGender.Text,
                    Age = (int)numAge.Value,
                    Class = txtClass.Text.Trim(),
                    Major = txtMajor.Text.Trim(),
                    Phone = txtPhone.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    EnrollmentDate = dtpEnrollmentDate.Value.Date
                };

                // 验证数据
                var validationResult = student.Validate();
                bool isValid = validationResult.Item1;
                string errorMessage = validationResult.Item2;
                if (!isValid)
                {
                    MessageBox.Show(errorMessage, "验证失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 获取当前用户信息
                var currentUser = CurrentUser.GetCurrentUser();
                bool success;

                if (_isEditMode)
                {
                    // 编辑模式
                    student.Id = _currentStudentId;
                    success = _studentRepository.UpdateStudent(student, currentUser?.Id ?? 0, currentUser?.Username ?? "Unknown");
                }
                else
                {
                    // 新增模式
                    success = _studentRepository.AddStudent(student, currentUser?.Id ?? 0, currentUser?.Username ?? "Unknown");
                }

                if (success)
                {
                    MessageBox.Show("学生信息保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                    groupBoxStudentDetails.Enabled = false;
                    LoadStudentsByPage(_currentPage, _pageSize);

                    // 恢复按钮状态
                    btnAdd.Enabled = true;
                    btnEdit.Enabled = false;
                    btnDelete.Enabled = false;
                    btnSave.Enabled = false;
                    btnCancel.Enabled = false;
                }
                else
                {
                    MessageBox.Show("学生信息保存失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"保存学生信息时发生错误: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearForm();
            groupBoxStudentDetails.Enabled = false;

            // 恢复按钮状态
            btnAdd.Enabled = true;
            btnEdit.Enabled = dataGridViewStudents.SelectedRows.Count > 0;
            btnDelete.Enabled = dataGridViewStudents.SelectedRows.Count > 0;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
        }

        private void ClearForm()
        {
            _currentStudentId = 0;
            txtStudentId.Text = "";
            txtName.Text = "";
            cmbGender.SelectedIndex = -1;
            numAge.Value = 18;
            txtClass.Text = "";
            txtMajor.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            dtpEnrollmentDate.Value = DateTime.Now;
        }

        private void dataGridViewStudents_SelectionChanged(object sender, EventArgs e)
        {
            btnEdit.Enabled = dataGridViewStudents.SelectedRows.Count > 0;
            btnDelete.Enabled = dataGridViewStudents.SelectedRows.Count > 0;
        }

        private void UpdateButtonStates()
        {
            btnEdit.Enabled = dataGridViewStudents.SelectedRows.Count > 0;
            btnDelete.Enabled = dataGridViewStudents.SelectedRows.Count > 0;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel文件|*.xlsx";
                saveFileDialog.Title = "导出学生信息到Excel";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var students = _studentRepository.GetAllStudents();
                    bool success = _excelService.ExportStudentsToExcel(students, saveFileDialog.FileName);

                    if (success)
                    {
                        MessageBox.Show("学生信息导出成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("学生信息导出失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("导出学生信息时发生错误: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Excel文件|*.xlsx";
                openFileDialog.Title = "从Excel导入学生信息";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var students = _excelService.ImportStudentsFromExcel(openFileDialog.FileName);
                    int successCount = 0;
                    int failCount = 0;

                    // 获取当前用户信息
                    var currentUser = CurrentUser.GetCurrentUser();

                    foreach (var student in students)
                    {
                        try
                        {
                            // 检查学号是否已存在
                            bool exists = false;
                            var existingStudents = _studentRepository.GetAllStudents();
                            foreach (var existingStudent in existingStudents)
                            {
                                if (existingStudent.student_id == student.student_id)
                                {
                                    exists = true;
                                    break;
                                }
                            }

                            if (!exists)
                            {
                                // 验证导入的学生数据
                                var (isValid, errorMessage) = student.Validate();
                                if (isValid)
                                {
                                    bool success = _studentRepository.AddStudent(student, currentUser?.Id ?? 0, currentUser?.Username ?? "Unknown");
                                    if (success)
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
                            else
                            {
                                failCount++;
                            }
                        }
                        catch (Exception ex)
                        {
                            // 记录错误但继续处理其他学生
                            Console.WriteLine($"导入学生 {student.Name} 时发生错误: {ex.Message}");
                            failCount++;
                        }
                    }

                    MessageBox.Show($"导入完成！成功导入{successCount}条记录，失败{failCount}条记录。",
                                  "导入结果", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadStudentsByPage(_currentPage, _pageSize);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"导入学生信息时发生错误: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtStudentId_TextChanged(object sender, EventArgs e)
        {

        }

        private void paginationControl_Load(object sender, EventArgs e)
        {

        }
    }
}