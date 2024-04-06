using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Model.entity
{
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

        [SugarColumn(IsIgnore = true)]
        public List<Blog> Blogs { get; set; } = new List<Blog>();
    }


}
