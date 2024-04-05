using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Model
{
    using SqlSugar;
    using System;
    using System.Collections.Generic;

    [SugarTable("blog")]
    public class Blog
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public long Id { get; set; }

        [SugarColumn(Length = 100)]
        public string Title { get; set; }

        [SugarColumn(Length = 255)]
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

        [SugarColumn(Length = 100)]
        public string Password { get; set; }

        // 假设 User 和 Category 类也在同一个命名空间下定义
        [SugarColumn(IsIgnore = true)]
        public User User { get; set; }

        [SugarColumn(IsIgnore = true)]
        public Category Category { get; set; }

        [SugarColumn(IsIgnore = true)]
        public List<Tag> Tags { get; set; } = new List<Tag>();
    }

    

}
