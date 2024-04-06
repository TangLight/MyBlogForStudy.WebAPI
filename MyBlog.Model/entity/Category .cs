using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Model.entity
{
    using SqlSugar;
    using System.Collections.Generic;

    [SugarTable("category")]
    public class Category
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public long Id { get; set; }

        [SugarColumn(Length = 100)]
        public string Name { get; set; }

        [SugarColumn(IsIgnore = true)]
        public List<Blog> Blogs { get; set; } = new List<Blog>();
    }



}
