using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Model
{
    using SqlSugar;
    using System;

    public class Moment
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public long Id { get; set; }

        public string Content { get; set; }

        public DateTime CreateTime { get; set; }

        public int Likes { get; set; }

        public bool Published { get; set; }
    }
}

