namespace MyBlogForStudy.WebAPI.PageHelper
{
    public class PageInfo<T>
    {
        public int PageNum { get; set; }
        public int PageSize { get; set; }
        public int Size { get; set; }
        public int StartRow { get; set; }
        public int EndRow { get; set; }
        public int Pages { get; set; }
        public int PrePage { get; set; }
        public int NextPage { get; set; }
        public bool IsFirstPage { get; set; }
        public bool IsLastPage { get; set; }
        public bool HasPreviousPage { get; set; }
        public bool HasNextPage { get; set; }
        public int NavigatePages { get; set; }
        public List<int> NavigatePageNums { get; set; }
        public int NavigateFirstPage { get; set; }
        public int NavigateLastPage { get; set; }
        public List<T> List { get; set; }
    }
}
