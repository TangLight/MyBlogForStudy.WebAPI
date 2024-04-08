using System.Collections.ObjectModel;

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
        //public PageInfo(List<T> list, int navigatePages) : base(list)
        //{
        //    if (list is Page<T>)
        //    {
        //        Page<T> page = (Page<T>)list;
        //        this.pageNum = page.PageNum;
        //        this.pageSize = page.PageSize;

        //        this.pages = page.Pages;
        //        this.size = page.Count;
        //        // 由于结果是 > startRow 的，所以实际的需要 +1
        //        if (this.size == 0)
        //        {
        //            this.startRow = 0;
        //            this.endRow = 0;
        //        }
        //        else
        //        {
        //            this.startRow = page.StartRow + 1;
        //            // 计算实际的 endRow（最后一页的时候特殊）
        //            this.endRow = this.startRow - 1 + this.size;
        //        }
        //    }
        //    else if (list is Collection<T>)
        //    {
        //        this.pageNum = 1;
        //        this.pageSize = list.Count;

        //        this.pages = this.pageSize > 0 ? 1 : 0;
        //        this.size = list.Count;
        //        this.startRow = 0;
        //        this.endRow = list.Count > 0 ? list.Count - 1 : 0;
        //    }
        //    if (list is Collection<T>)
        //    {
        //        this.navigatePages = navigatePages;
        //        // 计算导航页
        //        CalcNavigatepageNums();
        //        // 计算前后页，第一页，最后一页
        //        CalcPage();
        //        // 判断页面边界
        //        JudgePageBoudary();
        //    }
        //}

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
        private int[] CalculateNavigatepageNums(int pageNum, int navigatePages, int pages)
        {
            int[] navigatepageNums;
            if (pages <= navigatePages)
            {
                navigatepageNums = new int[pages];
                for (int i = 0; i < pages; i++)
                {
                    navigatepageNums[i] = i + 1;
                }
            }
            else
            {
                navigatepageNums = new int[navigatePages];
                int startNum = pageNum - navigatePages / 2;
                int endNum = pageNum + navigatePages / 2;
                if (startNum < 1)
                {
                    startNum = 1;
                    for (int i = 0; i < navigatePages; i++)
                    {
                        navigatepageNums[i] = startNum++;
                    }
                }
                else if (endNum > pages)
                {
                    endNum = pages;
                    for (int i = navigatePages - 1; i >= 0; i--)
                    {
                        navigatepageNums[i] = endNum--;
                    }
                }
                else
                {
                    for (int i = 0; i < navigatePages; i++)
                    {
                        navigatepageNums[i] = startNum++;
                    }
                }
            }
            return navigatepageNums;
        }


    }
}
