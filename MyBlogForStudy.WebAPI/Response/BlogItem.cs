using MyBlog.Model.entity;

namespace MyBlogForStudy.WebAPI.Response
{
    public class BlogItem
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string FirstPicture { get; set; }
        public string Content { get; set; }
        public string Description { get; set; }
        public bool Published { get; set; }
        public bool Recommend { get; set; }
        public bool Appreciation { get; set; }
        public bool CommentEnabled { get; set; }
        public bool Top { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public int Views { get; set; }
        public int Words { get; set; }
        public int ReadTime { get; set; }
        public string Password { get; set; }
        public object User { get; set; } // 假设 User 是一个对象
        public int UserId { get; set; }
        public CategoryItem Category { get; set; }
        public List<Tag> Tags { get; set; } // 假设 Tags 是一个对象列表
    }
}
