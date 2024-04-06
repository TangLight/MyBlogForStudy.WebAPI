using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Model.entity
{
    using SqlSugar;
    using System;

    public class SiteSetting
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public long Id { get; set; }

        public string NameEn { get; set; }

        public string NameZh { get; set; }

        public string Value { get; set; }

        public int Type { get; set; }
    }

}
