using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Model.entity
{
    using MyBlog.Model.mapper;
    using SqlSugar;

    [SugarTable("tags")]
    public class Tag
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public long Id { get; set; }

        [SugarColumn(Length = 100)]
        public string Name { get; set; }

        [SugarColumn(Length = 50)]
        public string Color { get; set; }

        [Navigate(typeof(Blog_Tag), nameof(Blog_Tag.TagId), nameof(Blog_Tag.BlogId))]
        public List<Blog> Blogs { get; set; } = new List<Blog>();
    }


}
