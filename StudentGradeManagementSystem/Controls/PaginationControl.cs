using System;
using System.Windows.Forms;

namespace StudentGradeManagementSystem.Controls
{
    public partial class PaginationControl : UserControl
    {
        public delegate void PageChangedEventHandler(object sender, PageChangedEventArgs e);

        public event PageChangedEventHandler? PageChanged;

        private int _currentPage = 1;
        private int _pageSize = 20;
        private int _totalItems = 0;
        private int _totalPages = 0;

        public PaginationControl()
        {
            InitializeComponent();
        }

        public int CurrentPage
        {
            get { return _currentPage; }
            set
            {
                _currentPage = value;
                UpdatePaginationControls();
            }
        }

        public int PageSize
        {
            get { return _pageSize; }
            set
            {
                _pageSize = value;
                UpdatePaginationControls();
            }
        }

        public int TotalItems
        {
            get { return _totalItems; }
            set
            {
                _totalItems = value;
                _totalPages = (int)Math.Ceiling((double)_totalItems / _pageSize);
                UpdatePaginationControls();
            }
        }

        public void InitializePagination()
        {
            txtPageSize.Text = _pageSize.ToString();
            txtPageNumber.Text = _currentPage.ToString();

            txtPageNumber.KeyDown += TxtPageNumber_KeyDown;
            txtPageSize.KeyDown += TxtPageSize_KeyDown;
            txtPageSize.Leave += TxtPageSize_Leave;
            btnFirstPage.Click += BtnFirstPage_Click;
            btnPreviousPage.Click += BtnPreviousPage_Click;
            btnNextPage.Click += BtnNextPage_Click;
            btnLastPage.Click += BtnLastPage_Click;

            UpdatePaginationControls();
        }

        private void UpdatePaginationControls()
        {
            lblTotalCount.Text = $"共 {_totalItems} 条记录";
            txtPageNumber.Text = _currentPage.ToString();

            btnFirstPage.Enabled = _currentPage > 1;
            btnPreviousPage.Enabled = _currentPage > 1;
            btnNextPage.Enabled = _currentPage < _totalPages;
            btnLastPage.Enabled = _currentPage < _totalPages;
        }

        private void OnPageChanged()
        {
            PageChanged?.Invoke(this, new PageChangedEventArgs
            {
                CurrentPage = _currentPage,
                PageSize = _pageSize
            });
        }

        private void TxtPageNumber_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (int.TryParse(txtPageNumber.Text, out int pageNumber) && pageNumber > 0 && pageNumber <= _totalPages)
                {
                    _currentPage = pageNumber;
                    UpdatePaginationControls();
                    OnPageChanged();
                }
                else
                {
                    MessageBox.Show("请输入有效的页码", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPageNumber.Text = _currentPage.ToString();
                }
            }
        }

        private void TxtPageSize_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (int.TryParse(txtPageSize.Text, out int pageSize) && pageSize > 0)
                {
                    _pageSize = pageSize;
                    _currentPage = 1;
                    _totalPages = (int)Math.Ceiling((double)_totalItems / _pageSize);
                    UpdatePaginationControls();
                    OnPageChanged();
                }
                else
                {
                    MessageBox.Show("请输入有效的每页显示条数", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPageSize.Text = _pageSize.ToString();
                }
            }
        }

        private void TxtPageSize_Leave(object? sender, EventArgs e)
        {
            if (int.TryParse(txtPageSize.Text, out int pageSize) && pageSize > 0)
            {
                if (pageSize != _pageSize)
                {
                    _pageSize = pageSize;
                    _currentPage = 1;
                    _totalPages = (int)Math.Ceiling((double)_totalItems / _pageSize);
                    UpdatePaginationControls();
                    OnPageChanged();
                }
            }
            else
            {
                MessageBox.Show("请输入有效的每页显示条数", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPageSize.Text = _pageSize.ToString();
            }
        }

        private void BtnFirstPage_Click(object? sender, EventArgs e)
        {
            if (_currentPage > 1)
            {
                _currentPage = 1;
                UpdatePaginationControls();
                OnPageChanged();
            }
        }

        private void BtnPreviousPage_Click(object? sender, EventArgs e)
        {
            if (_currentPage > 1)
            {
                _currentPage--;
                UpdatePaginationControls();
                OnPageChanged();
            }
        }

        private void BtnNextPage_Click(object? sender, EventArgs e)
        {
            if (_currentPage < _totalPages)
            {
                _currentPage++;
                UpdatePaginationControls();
                OnPageChanged();
            }
        }

        private void BtnLastPage_Click(object? sender, EventArgs e)
        {
            if (_currentPage < _totalPages)
            {
                _currentPage = _totalPages;
                UpdatePaginationControls();
                OnPageChanged();
            }
        }

        private void lblTotalCount_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }

    public class PageChangedEventArgs : EventArgs
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
    }
}