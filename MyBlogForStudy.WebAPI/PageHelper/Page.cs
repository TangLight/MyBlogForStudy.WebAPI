namespace MyBlogForStudy.WebAPI.PageHelper
{
    public class Page<E> : List<E>
    {
        private int pageNum;
        private int pageSize;
        private int startRow;
        private int endRow;
        private long total;
        private int pages;
        private bool count = true;
        private bool? reasonable;
        private bool? pageSizeZero;
        private string countColumn;
        private string orderBy;
        private bool orderByOnly;

        public Page()
        {
        }

        public Page(int pageNum, int pageSize)
        {
            Initialize(pageNum, pageSize, true, null);
        }

        public Page(int pageNum, int pageSize, bool count)
        {
            Initialize(pageNum, pageSize, count, null);
        }

        private void Initialize(int pageNum, int pageSize, bool count, bool? reasonable)
        {
            if (pageNum == 1 && pageSize == int.MaxValue)
            {
                pageSizeZero = true;
                pageSize = 0;
            }
            this.pageNum = pageNum;
            this.pageSize = pageSize;
            this.count = count;
            CalculateStartAndEndRow();
            SetReasonable(reasonable);
        }

        private void CalculateStartAndEndRow()
        {
            startRow = pageNum > 0 ? (pageNum - 1) * pageSize : 0;
            endRow = startRow + pageSize * (pageNum > 0 ? 1 : 0);
        }

        public int PageNum { get => pageNum; set => pageNum = value; }
        public int PageSize { get => pageSize; set => pageSize = value; }
        public int StartRow { get => startRow; set => startRow = value; }
        public int EndRow { get => endRow; set => endRow = value; }
        public long Total { get => total; set => total = value; }
        public int Pages { get => pages; set => pages = value; }
        public bool Count { get => count; set => count = value; }
        public bool? Reasonable { get => reasonable; set => reasonable = value; }
        public bool? PageSizeZero { get => pageSizeZero; set => pageSizeZero = value; }
        public string CountColumn { get => countColumn; set => countColumn = value; }
        public string OrderBy { get => orderBy; set => orderBy = value; }
        public bool OrderByOnly { get => orderByOnly; set => orderByOnly = value; }

        public void SetReasonable(bool? reasonable)
        {
            if (reasonable == null)
            {
                return;
            }
            this.reasonable = reasonable;
            if (this.reasonable == true && this.pageNum <= 0)
            {
                this.pageNum = 1;
                CalculateStartAndEndRow();
            }
        }

        public void SetPageSizeZero(bool? pageSizeZero)
        {
            if (pageSizeZero != null)
            {
                this.pageSizeZero = pageSizeZero;
            }
        }

        public override string ToString()
        {
            return "Page{" +
                    "count=" + count +
                    ", pageNum=" + pageNum +
                    ", pageSize=" + pageSize +
                    ", startRow=" + startRow +
                    ", endRow=" + endRow +
                    ", total=" + total +
                    ", pages=" + pages +
                    ", reasonable=" + reasonable +
                    ", pageSizeZero=" + pageSizeZero +
                    '}' + base.ToString();
        }

        //public void Dispose()
        //{
        //    PageHelper.ClearPage();
        //}
    }
}
