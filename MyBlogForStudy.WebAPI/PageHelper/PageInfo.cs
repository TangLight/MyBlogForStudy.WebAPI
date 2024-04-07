namespace MyBlogForStudy.WebAPI.PageHelper
{
    public class PageInfo<T> : PageSerializable<T>
    {
        private int pageNum;
        private int pageSize;
        private int size;
        private int startRow;
        private int endRow;
        private int pages;
        private int prePage;
        private int nextPage;
        private bool isFirstPage = false;
        private bool isLastPage = false;
        private bool hasPreviousPage = false;
        private bool hasNextPage = false;
        private int navigatePages;
        private int[] navigatepageNums;
        private int navigateFirstPage;
        private int navigateLastPage;

        

        public PageInfo(List<T> list) : base(list)
        {
            if (list.Count > 0)
            {
                pageNum = 1;
                pageSize = list.Count;
                size = list.Count;
                startRow = 0;
                endRow = list.Count - 1;
                pages = 1;
                prePage = 0;
                nextPage = 0;
                isFirstPage = true;
                isLastPage = true;
                hasPreviousPage = false;
                hasNextPage = false;
                navigatePages = 0;
                navigatepageNums = new int[0];
                navigateFirstPage = 0;
                navigateLastPage = 0;
            }
        }

        public int PageNum { get => pageNum; set => pageNum = value; }
        public int PageSize { get => pageSize; set => pageSize = value; }
        public int Size { get => size; set => size = value; }
        public int StartRow { get => startRow; set => startRow = value; }
        public int EndRow { get => endRow; set => endRow = value; }
        public int Pages { get => pages; set => pages = value; }
        public int PrePage { get => prePage; set => prePage = value; }
        public int NextPage { get => nextPage; set => nextPage = value; }
        public bool IsFirstPage { get => isFirstPage; set => isFirstPage = value; }
        public bool IsLastPage { get => isLastPage; set => isLastPage = value; }
        public bool HasPreviousPage { get => hasPreviousPage; set => hasPreviousPage = value; }
        public bool HasNextPage { get => hasNextPage; set => hasNextPage = value; }
        public int NavigatePages { get => navigatePages; set => navigatePages = value; }
        public int[] NavigatepageNums { get => navigatepageNums; set => navigatepageNums = value; }
        public int NavigateFirstPage { get => navigateFirstPage; set => navigateFirstPage = value; }
        public int NavigateLastPage { get => navigateLastPage; set => navigateLastPage = value; }
    }
}
