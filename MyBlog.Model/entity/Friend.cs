using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Model.entity
{
    using SqlSugar;
    using System;

    public class Friend
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public long Id { get; set; }

        [SugarColumn(Length = 100)]
        public string Nickname { get; set; }

        public string Description { get; set; }

        public string Website { get; set; }

        public string Avatar { get; set; }

        public bool Published { get; set; }

        public int Views { get; set; }

        public DateTime CreateTime { get; set; }
    }

}
