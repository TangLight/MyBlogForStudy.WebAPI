using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Model.entity
{
    using MyBlog.Model.mapper;
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


        [Navigate(NavigateType.ManyToOne, nameof(UserId), nameof(User.Id))]
        public User User { get; set; }

        public int UserId { get; set; }



        [Navigate(NavigateType.ManyToOne, nameof(CategoryId), nameof(Category.Id))]
        public Category Category { get; set; }

        

        public int CategoryId { get; set; }

        [Navigate(typeof(Blog_Tag), nameof(Blog_Tag.BlogId), nameof(Blog_Tag.TagId))]
        public List<Tag> Tags { get; set; }
    }



}
