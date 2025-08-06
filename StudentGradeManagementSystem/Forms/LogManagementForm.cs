using System;
using System.Windows.Forms;
using StudentGradeManagementSystem.Data;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.ComponentModel;
using System.Data;
using Microsoft.Extensions.Logging;
using System.Drawing;
using StudentGradeManagementSystem.Controls;

namespace StudentGradeManagementSystem.Forms
{
    public partial class LogManagementForm : Form
    {
        private LogRepository _logRepository = new LogRepository();
        private bool userLogsLoaded = false;
        private bool systemLogsLoaded = false;
        
        // 用户日志分页相关字段
        private int _currentUserLogsPage = 1;
        private int _userLogsPageSize = 30;  // 调整默认页面大小为30
        private int _totalUserLogs = 0;
        
        // 系统日志分页相关字段
        private int _currentSystemLogsPage = 1;
        private int _systemLogsPageSize = 30;  // 调整默认页面大小为30
        private int _totalSystemLogs = 0;
        
        public LogManagementForm()
        {
            InitializeComponent();
            
            // 添加行绘制事件处理程序，用于错误日志行以红色显示
            dataGridViewUserLogs.RowPrePaint += DataGridViewUserLogs_RowPrePaint;
            dataGridViewSystemLogs.RowPrePaint += DataGridViewSystemLogs_RowPrePaint;
        }
        
        private async void LogManagementForm_Load(object sender, EventArgs e)
        {
            try
            {
                // 初始化批量删除按钮
                // btnBatchDelete.Click += BtnBatchDelete_Click;
                
                // 订阅分页控件的事件
                paginationControlUserLogs.PageChanged += PaginationControlUserLogs_PageChanged;
                paginationControlSystemLogs.PageChanged += PaginationControlSystemLogs_PageChanged;
                paginationControlUserLogs.InitializePagination();
                paginationControlSystemLogs.InitializePagination();
                
                // 显示加载提示
                toolStripStatusLabel1.Text = "正在加载用户日志...";
                statusStrip1.Visible = true;
                
                // 异步加载用户日志 (已修复)
                await LoadUserLogsByPageAsync(_currentUserLogsPage, _userLogsPageSize);
                userLogsLoaded = true;
                tabControl1.SelectedTab = tabPageUserLogs;
                
                // 预加载系统日志 (已修复)，但不显示
                _ = Task.Run(async () => {
                    await Task.Delay(1000); // 延迟1秒加载系统日志，避免阻塞UI
                    await LoadSystemLogsByPageAsync(_currentSystemLogsPage, _systemLogsPageSize);
                    systemLogsLoaded = true;
                    
                    // 确保在UI线程上刷新DataGridView以显示序号
                    if (dataGridViewSystemLogs.InvokeRequired)
                    {
                        dataGridViewSystemLogs.Invoke(new Action(() => {
                            for (int i = 0; i < dataGridViewSystemLogs.Rows.Count; i++)
                            {
                                if (dataGridViewSystemLogs.Columns["RowIndex"] != null && 
                                    i < dataGridViewSystemLogs.Rows.Count && 
                                    dataGridViewSystemLogs.Rows[i].Cells["RowIndex"] != null)
                                {
                                    if (dataGridViewSystemLogs.Rows[i].DataBoundItem is Models.OperationLog log)
                                    {
                                        dataGridViewSystemLogs.Rows[i].Cells["RowIndex"].Value = log.Id.ToString();
                                    }
                                }
                            }
                            dataGridViewSystemLogs.Refresh();
                        }));
                    }
                });
                
                // 隐藏加载提示
                statusStrip1.Visible = false;
                
                // 确保窗体正确显示
                this.BringToFront();
                this.Activate();
            }
            catch (Exception ex)
            {
                // 隐藏加载提示
                statusStrip1.Visible = false;
                MessageBox.Show("加载日志管理界面时发生错误: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        // 用户日志分页控件页码更改事件处理
        private void PaginationControlUserLogs_PageChanged(object sender, PageChangedEventArgs e)
        {
            _ = LoadUserLogsByPageAsync(e.CurrentPage, e.PageSize);
        }
        
        // 系统日志分页控件页码更改事件处理
        private void PaginationControlSystemLogs_PageChanged(object sender, PageChangedEventArgs e)
        {
            _ = LoadSystemLogsByPageAsync(e.CurrentPage, e.PageSize);
        }
        
        private async void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPageUserLogs)
            {
                // 只有在首次选择用户日志标签页时加载数据
                if (!userLogsLoaded)
                {
                    await LoadUserLogsByPageAsync(_currentUserLogsPage, _userLogsPageSize);
                    userLogsLoaded = true;
                }
            }
            else if (tabControl1.SelectedTab == tabPageSystemLogs)
            {
                // 只有在首次选择系统日志标签页时加载数据
                if (!systemLogsLoaded)
                {
                    await LoadSystemLogsByPageAsync(_currentSystemLogsPage, _systemLogsPageSize);
                    systemLogsLoaded = true;
                }
            }
        }
        
        private async Task LoadUserLogsByPageAsync(int pageNumber, int pageSize)
        {
            // 在UI线程上显示加载状态
            toolStripStatusLabel1.Text = "正在加载用户日志...";
            statusStrip1.Visible = true;
            
            try
            {
                // 使用Task.Run在后台线程加载数据
                var logs = await Task.Run(() => _logRepository.GetUserLogs(1000)); // 获取所有日志用于分页
                
                // 计算分页数据
                _totalUserLogs = logs.Count;
                int startIndex = (pageNumber - 1) * pageSize;
                var pagedLogs = logs.Skip(startIndex).Take(pageSize).ToList();
                
                // 在UI线程上更新界面
                dataGridViewUserLogs.DataSource = pagedLogs;
                
                // 更新分页信息
                _currentUserLogsPage = pageNumber;
                _userLogsPageSize = pageSize;
                
                // 更新分页控件显示
                paginationControlUserLogs.CurrentPage = _currentUserLogsPage;
                paginationControlUserLogs.PageSize = _userLogsPageSize;
                paginationControlUserLogs.TotalItems = _totalUserLogs;
                
                // 确保在数据绑定完成后设置序号列
                dataGridViewUserLogs.DataBindingComplete += (s, e) => {
                    // 添加序号列
                    if (dataGridViewUserLogs.Columns["RowIndex"] == null)
                    {
                        DataGridViewTextBoxColumn rowIndexColumn = new DataGridViewTextBoxColumn();
                        rowIndexColumn.Name = "RowIndex";
                        rowIndexColumn.HeaderText = "序号";
                        rowIndexColumn.ReadOnly = true;
                        dataGridViewUserLogs.Columns.Insert(0, rowIndexColumn);
                    }
                    
                    // 使用数据库中的ID作为序号列的值
                    for (int i = 0; i < dataGridViewUserLogs.Rows.Count; i++)
                    {
                        if (dataGridViewUserLogs.Rows[i].DataBoundItem is Models.OperationLog log)
                        {
                            dataGridViewUserLogs.Rows[i].Cells["RowIndex"].Value = log.Id.ToString();
                        }
                    }
                };
                
                // 立即添加序号列（如果DataBindingComplete事件未触发）
                if (dataGridViewUserLogs.Columns["RowIndex"] == null)
                {
                    DataGridViewTextBoxColumn rowIndexColumn = new DataGridViewTextBoxColumn();
                    rowIndexColumn.Name = "RowIndex";
                    rowIndexColumn.HeaderText = "序号";
                    rowIndexColumn.ReadOnly = true;
                    dataGridViewUserLogs.Columns.Insert(0, rowIndexColumn);
                }
                
                // 使用数据库中的ID作为序号列的值
                for (int i = 0; i < dataGridViewUserLogs.Rows.Count; i++)
                {
                    if (dataGridViewUserLogs.Rows[i].DataBoundItem is Models.OperationLog log)
                    {
                        dataGridViewUserLogs.Rows[i].Cells["RowIndex"].Value = log.Id.ToString();
                    }
                }
                
                // 设置列标题
                if (dataGridViewUserLogs.Columns["Id"] != null)
                    dataGridViewUserLogs.Columns["Id"].Visible = false;
                    
                if (dataGridViewUserLogs.Columns["UserId"] != null)
                    dataGridViewUserLogs.Columns["UserId"].Visible = false;
                    
                if (dataGridViewUserLogs.Columns["Username"] != null)
                    dataGridViewUserLogs.Columns["Username"].HeaderText = "用户名";
                    
                if (dataGridViewUserLogs.Columns["LogType"] != null)
                    dataGridViewUserLogs.Columns["LogType"].Visible = false;
                    
                if (dataGridViewUserLogs.Columns["IPAddress"] != null)
                    dataGridViewUserLogs.Columns["IPAddress"].HeaderText = "IP地址";
                    
                if (dataGridViewUserLogs.Columns["Operation"] != null)
                    dataGridViewUserLogs.Columns["Operation"].HeaderText = "操作";
                    
                if (dataGridViewUserLogs.Columns["Description"] != null)
                    dataGridViewUserLogs.Columns["Description"].HeaderText = "详细信息";
                    
                if (dataGridViewUserLogs.Columns["UserAgent"] != null)
                    dataGridViewUserLogs.Columns["UserAgent"].Visible = false;
                    
                if (dataGridViewUserLogs.Columns["CreatedAt"] != null)
                {
                    dataGridViewUserLogs.Columns["CreatedAt"].HeaderText = "操作时间";
                    // 确保时间显示格式包含秒
                    dataGridViewUserLogs.Columns["CreatedAt"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                }

                // 刷新DataGridView以确保数据显示
                dataGridViewUserLogs.Refresh();
                
                // 设置列宽
                SetUserLogsColumnWidths();
            }
            catch (Exception ex)
            {
                MessageBox.Show("加载用户日志时发生错误: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // 隐藏加载提示
                statusStrip1.Visible = false;
            }
        }

        private async Task LoadSystemLogsByPageAsync(int pageNumber, int pageSize)
        {
            // 在UI线程上显示加载状态
            toolStripStatusLabel1.Text = "正在加载系统日志...";
            statusStrip1.Visible = true;
            
            try
            {
                // 使用Task.Run在后台线程加载数据
                var logs = await Task.Run(() => _logRepository.GetSystemLogs(1000)); // 获取所有日志用于分页
                
                // 计算分页数据
                _totalSystemLogs = logs.Count;
                int startIndex = (pageNumber - 1) * pageSize;
                var pagedLogs = logs.Skip(startIndex).Take(pageSize).ToList();
                
                // 在UI线程上更新界面
                dataGridViewSystemLogs.DataSource = pagedLogs;
                
                // 更新分页信息
                _currentSystemLogsPage = pageNumber;
                _systemLogsPageSize = pageSize;
                
                // 更新分页控件显示
                paginationControlSystemLogs.CurrentPage = _currentSystemLogsPage;
                paginationControlSystemLogs.PageSize = _systemLogsPageSize;
                paginationControlSystemLogs.TotalItems = _totalSystemLogs;
                
                // 确保在数据绑定完成后设置序号列
                dataGridViewSystemLogs.DataBindingComplete += (s, e) => {
                    // 添加序号列
                    if (dataGridViewSystemLogs.Columns["RowIndex"] == null)
                    {
                        DataGridViewTextBoxColumn rowIndexColumn = new DataGridViewTextBoxColumn();
                        rowIndexColumn.Name = "RowIndex";
                        rowIndexColumn.HeaderText = "序号";
                        rowIndexColumn.ReadOnly = true;
                        dataGridViewSystemLogs.Columns.Insert(0, rowIndexColumn);
                    }
                    
                    // 使用数据库中的ID作为序号列的值
                    for (int i = 0; i < dataGridViewSystemLogs.Rows.Count; i++)
                    {
                        if (dataGridViewSystemLogs.Rows[i].DataBoundItem is Models.OperationLog log)
                        {
                            dataGridViewSystemLogs.Rows[i].Cells["RowIndex"].Value = log.Id.ToString();
                        }
                    }
                };
                
                // 立即添加序号列（如果DataBindingComplete事件未触发）
                if (dataGridViewSystemLogs.Columns["RowIndex"] == null)
                {
                    DataGridViewTextBoxColumn rowIndexColumn = new DataGridViewTextBoxColumn();
                    rowIndexColumn.Name = "RowIndex";
                    rowIndexColumn.HeaderText = "序号";
                    rowIndexColumn.ReadOnly = true;
                    dataGridViewSystemLogs.Columns.Insert(0, rowIndexColumn);
                }
                
                // 使用数据库中的ID作为序号列的值
                for (int i = 0; i < dataGridViewSystemLogs.Rows.Count; i++)
                {
                    if (dataGridViewSystemLogs.Rows[i].DataBoundItem is Models.OperationLog log)
                    {
                        dataGridViewSystemLogs.Rows[i].Cells["RowIndex"].Value = log.Id.ToString();
                    }
                }
                
                // 设置列标题
                if (dataGridViewSystemLogs.Columns["Id"] != null)
                    dataGridViewSystemLogs.Columns["Id"].Visible = false;
                    
                if (dataGridViewSystemLogs.Columns["UserId"] != null)
                    dataGridViewSystemLogs.Columns["UserId"].Visible = false;
                    
                if (dataGridViewSystemLogs.Columns["Username"] != null)
                    dataGridViewSystemLogs.Columns["Username"].Visible = false;
                    
                if (dataGridViewSystemLogs.Columns["LogType"] != null)
                    dataGridViewSystemLogs.Columns["LogType"].Visible = false;
                    
                if (dataGridViewSystemLogs.Columns["IPAddress"] != null)
                    dataGridViewSystemLogs.Columns["IPAddress"].Visible = false;
                    
                if (dataGridViewSystemLogs.Columns["Operation"] != null)
                    dataGridViewSystemLogs.Columns["Operation"].HeaderText = "操作类型";
                    
                if (dataGridViewSystemLogs.Columns["Description"] != null)
                    dataGridViewSystemLogs.Columns["Description"].HeaderText = "详细信息";
                    
                if (dataGridViewSystemLogs.Columns["UserAgent"] != null)
                    dataGridViewSystemLogs.Columns["UserAgent"].Visible = false;
                    
                if (dataGridViewSystemLogs.Columns["CreatedAt"] != null)
                {
                    dataGridViewSystemLogs.Columns["CreatedAt"].HeaderText = "操作时间";
                    // 确保时间显示格式包含秒
                    dataGridViewSystemLogs.Columns["CreatedAt"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                }
                    
                // 刷新DataGridView以确保数据显示
                dataGridViewSystemLogs.Refresh();
                
                // 设置列宽
                SetSystemLogsColumnWidths();
            }
            catch (Exception ex)
            {
                MessageBox.Show("加载系统日志时发生错误: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // 隐藏加载提示
                statusStrip1.Visible = false;
            }
        }
        
        // 保持原有的异步加载方法，用于刷新操作
        private async Task LoadUserLogsAsync()
        {
            await LoadUserLogsByPageAsync(_currentUserLogsPage, _userLogsPageSize);
        }
        
        private async Task LoadSystemLogsAsync()
        {
            await LoadSystemLogsByPageAsync(_currentSystemLogsPage, _systemLogsPageSize);
        }
        
        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPageUserLogs)
            {
                await LoadUserLogsByPageAsync(_currentUserLogsPage, _userLogsPageSize);
            }
            else if (tabControl1.SelectedTab == tabPageSystemLogs)
            {
                await LoadSystemLogsByPageAsync(_currentSystemLogsPage, _systemLogsPageSize);
            }
        }
        
        private async void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                // 确定当前选中的标签页
                if (tabControl1.SelectedTab == tabPageUserLogs)
                {
                    await DeleteSelectedUserLogsAsync();
                }
                else if (tabControl1.SelectedTab == tabPageSystemLogs)
                {
                    await DeleteSelectedSystemLogsAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("删除日志时发生错误: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private async Task DeleteSelectedUserLogsAsync()
        {
            // 检查是否有选中的行
            if (dataGridViewUserLogs.SelectedRows.Count == 0)
            {
                MessageBox.Show("请先选择要删除的日志记录", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            // 确认删除操作
            DialogResult result = MessageBox.Show($"确定要删除选中的 {dataGridViewUserLogs.SelectedRows.Count} 条用户日志记录吗？", 
                "确认删除", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (result == DialogResult.Yes)
            {
                try
                {
                    int deletedCount = 0;
                    List<int> logIds = new List<int>();
                    
                    // 收集要删除的日志ID
                    foreach (DataGridViewRow row in dataGridViewUserLogs.SelectedRows)
                    {
                        if (row.Cells["Id"].Value != null)
                        {
                            logIds.Add(Convert.ToInt32(row.Cells["Id"].Value));
                        }
                    }
                    
                    // 执行删除操作
                    foreach (int logId in logIds)
                    {
                        if (_logRepository.DeleteLog(logId))
                        {
                            deletedCount++;
                        }
                    }
                    
                    MessageBox.Show($"成功删除 {deletedCount} 条用户日志记录", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    // 重新加载数据
                    await LoadUserLogsByPageAsync(_currentUserLogsPage, _userLogsPageSize);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("删除用户日志时发生错误: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        
        private async Task DeleteSelectedSystemLogsAsync()
        {
            // 检查是否有选中的行
            if (dataGridViewSystemLogs.SelectedRows.Count == 0)
            {
                MessageBox.Show("请先选择要删除的日志记录", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            // 确认删除操作
            DialogResult result = MessageBox.Show($"确定要删除选中的 {dataGridViewSystemLogs.SelectedRows.Count} 条系统日志记录吗？", 
                "确认删除", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (result == DialogResult.Yes)
            {
                try
                {
                    int deletedCount = 0;
                    List<int> logIds = new List<int>();
                    
                    // 收集要删除的日志ID
                    foreach (DataGridViewRow row in dataGridViewSystemLogs.SelectedRows)
                    {
                        if (row.Cells["Id"].Value != null)
                        {
                            logIds.Add(Convert.ToInt32(row.Cells["Id"].Value));
                        }
                    }
                    
                    // 执行删除操作
                    foreach (int logId in logIds)
                    {
                        if (_logRepository.DeleteLog(logId))
                        {
                            deletedCount++;
                        }
                    }
                    
                    MessageBox.Show($"成功删除 {deletedCount} 条系统日志记录", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    // 重新加载数据
                    await LoadSystemLogsByPageAsync(_currentSystemLogsPage, _systemLogsPageSize);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("删除系统日志时发生错误: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        
        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "CSV文件|*.csv|文本文件|*.txt|所有文件|*.*";
                saveFileDialog.Title = "导出日志";
                saveFileDialog.FileName = $"logs_{DateTime.Now:yyyyMMdd_HHmmss}.csv";
                
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    List<Models.OperationLog> logs = new List<Models.OperationLog>();
                    
                    if (tabControl1.SelectedTab == tabPageUserLogs)
                    {
                        logs = _logRepository.GetUserLogs(1000); // 导出最多1000条记录
                    }
                    else if (tabControl1.SelectedTab == tabPageSystemLogs)
                    {
                        logs = _logRepository.GetSystemLogs(1000); // 导出最多1000条记录
                    }
                    
                    ExportLogsToCsv(logs, saveFileDialog.FileName);
                    MessageBox.Show("日志导出成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("导出日志时发生错误: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void ExportLogsToCsv(List<Models.OperationLog> logs, string filePath)
        {
            StringBuilder csvContent = new StringBuilder();
            
            // 添加标题行
            if (tabControl1.SelectedTab == tabPageUserLogs)
            {
                csvContent.AppendLine("序号,用户名,IP地址,操作,详细信息,操作时间");
                
                // 添加数据行
                for (int i = 0; i < logs.Count; i++)
                {
                    var log = logs[i];
                    csvContent.AppendLine($"{i + 1},\"{log.Username}\",\"{log.IPAddress}\",\"{log.Operation}\",\"{log.Description}\",\"{log.CreatedAt}\"");
                }
            }
            else if (tabControl1.SelectedTab == tabPageSystemLogs)
            {
                csvContent.AppendLine("序号,操作类型,详细信息,时间");
                
                // 添加数据行
                for (int i = 0; i < logs.Count; i++)
                {
                    var log = logs[i];
                    csvContent.AppendLine($"{i + 1},\"{log.Operation}\",\"{log.Description}\",\"{log.CreatedAt}\"");
                }
            }
            
            // 写入文件
            File.WriteAllText(filePath, csvContent.ToString(), Encoding.UTF8);
        }
        
        private void SetUserLogsColumnWidths()
        {
            try
            {
                // 先自动调整所有列的宽度
                dataGridViewUserLogs.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                
                // 设置除了序号列之外的所有列宽度为200像素
                foreach (DataGridViewColumn column in dataGridViewUserLogs.Columns)
                {
                    // 跳过序号列，保持其原有宽度
                    if (column.Name != "RowIndex")
                    {
                        SetColumnToSpecificWidth(dataGridViewUserLogs, column.Name, 200);
                    }
                }
                
                // 确保序号列有合适的宽度
                SetColumnToSpecificWidth(dataGridViewUserLogs, "RowIndex", 60);
            }
            catch (Exception ex)
            {
                // 如果设置列宽时出错，至少保证自动调整
                try
                {
                    dataGridViewUserLogs.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                }
                catch
                {
                    // 如果自动调整也失败，至少确保不会因为列宽问题导致程序崩溃
                }
                
                // 记录错误但不中断程序执行
                Console.WriteLine("设置用户日志列宽时发生错误: " + ex.Message);
            }
        }
        
        private void SetSystemLogsColumnWidths()
        {
            try
            {
                // 设置除了序号列之外的所有列宽度为200像素
                foreach (DataGridViewColumn column in dataGridViewSystemLogs.Columns)
                {
                    // 跳过序号列，保持其原有宽度
                    if (column.Name != "RowIndex")
                    {
                        SetColumnToSpecificWidth(dataGridViewSystemLogs, column.Name, 200);
                    }
                }
                
                // 确保序号列有合适的宽度
                SetColumnToSpecificWidth(dataGridViewSystemLogs, "RowIndex", 60);
            }
            catch (Exception ex)
            {
                // 记录错误但不中断程序执行
                Console.WriteLine("设置系统日志列宽时发生错误: " + ex.Message);
            }
        }
        
        private void SetColumnToSpecificWidth(DataGridView dataGridView, string columnName, int width)
        {
            if (dataGridView.Columns[columnName] != null)
            {
                // 确保新宽度不超过最大允许值
                dataGridView.Columns[columnName].Width = Math.Min(width, 65535);
            }
        }
        
        // 用户日志DataGridView行预绘制事件处理程序
        private void DataGridViewUserLogs_RowPrePaint(object? sender, DataGridViewRowPrePaintEventArgs e)
        {
            DataGridView? dataGridView = sender as DataGridView;
            if (dataGridView != null && e.RowIndex >= 0 && e.RowIndex < dataGridView.Rows.Count)
            {
                DataGridViewRow row = dataGridView.Rows[e.RowIndex];
                if (row.DataBoundItem is Models.OperationLog log)
                {
                    // 检查是否为错误类型的日志（可以根据操作类型或描述来判断）
                    if (log.Operation.Contains("错误") || log.Operation.Contains("失败") || 
                        log.Description.Contains("错误") || log.Description.Contains("失败"))
                    {
                        // 将整行字体颜色设置为红色
                        row.DefaultCellStyle.ForeColor = Color.Red;
                    }
                    else
                    {
                        // 恢复默认颜色
                        row.DefaultCellStyle.ForeColor = dataGridView.DefaultCellStyle.ForeColor;
                    }
                }
            }
        }
        
        // 系统日志DataGridView行预绘制事件处理程序
        private void DataGridViewSystemLogs_RowPrePaint(object? sender, DataGridViewRowPrePaintEventArgs e)
        {
            DataGridView? dataGridView = sender as DataGridView;
            if (dataGridView != null && e.RowIndex >= 0 && e.RowIndex < dataGridView.Rows.Count)
            {
                DataGridViewRow row = dataGridView.Rows[e.RowIndex];
                if (row.DataBoundItem is Models.OperationLog log)
                {
                    // 检查是否为错误类型的日志（可以根据操作类型或描述来判断）
                    if (log.Operation.Contains("错误") || log.Operation.Contains("失败") || 
                        log.Description.Contains("错误") || log.Description.Contains("失败"))
                    {
                        // 将整行字体颜色设置为红色
                        row.DefaultCellStyle.ForeColor = Color.Red;
                    }
                    else
                    {
                        // 恢复默认颜色
                        row.DefaultCellStyle.ForeColor = dataGridView.DefaultCellStyle.ForeColor;
                    }
                }
            }
        }
    }
}