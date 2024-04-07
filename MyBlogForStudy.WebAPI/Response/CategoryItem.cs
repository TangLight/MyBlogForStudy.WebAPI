using MyBlog.Model.entity;

namespace MyBlogForStudy.WebAPI.Response
{
    public class CategoryItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<Blog> Blogs { get; set; } // 假设 Blogs 是一个对象列表
    }
}
