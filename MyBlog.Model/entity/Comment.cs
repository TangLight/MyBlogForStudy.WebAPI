using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Model.entity
{
    using SqlSugar;
    using System;
    using System.Collections.Generic;

    public class Comment
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public long Id { get; set; }

        [SugarColumn(Length = 100)]
        public string Nickname { get; set; }

        [SugarColumn(Length = 100)]
        public string Email { get; set; }

        public string Content { get; set; }

        public string Avatar { get; set; }

        public DateTime CreateTime { get; set; }

        [SugarColumn(Length = 100)]
        public string Website { get; set; }

        [SugarColumn(Length = 50)]
        public string Ip { get; set; }

        public bool Published { get; set; }

        public bool AdminComment { get; set; }

        public int Page { get; set; }

        public bool Notice { get; set; }

        public long? ParentCommentId { get; set; }

        [SugarColumn(Length = 20)]
        public string Qq { get; set; }

        // 关联属性
        [Navigate(NavigateType.ManyToOne, nameof(BlogId), nameof(Blog.Id))]
        public Blog Blog { get; set; }

        public int BlogId { get; set; }
        public List<Comment> ReplyComments { get; set; } = new List<Comment>();
    }

}
