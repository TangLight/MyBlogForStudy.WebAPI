namespace MyBlogForStudy.WebAPI.PageHelper
{
    public class PageSerializable<T>
    {
        private long total;
        private List<T> list;

        public PageSerializable() { }

        public PageSerializable(List<T> list)
        {
            this.list = list;
            if (list is Page<T>)
            {
                this.total = ((Page<T>)list).Total;
            }
            else
            {
                this.total = list.Count;
            }
        }

        public static PageSerializable<T> Of(List<T> list)
        {
            return new PageSerializable<T>(list);
        }

        public long Total { get => total; set => total = value; }
        public List<T> List { get => list; set => list = value; }

        public override string ToString()
        {
            return "PageSerializable{" +
                    "total=" + total +
                    ", list=" + list +
                    '}';
        }
    }
}
