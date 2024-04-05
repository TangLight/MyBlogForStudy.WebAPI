using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Model
{
    using SqlSugar;
    using System;

    public class VisitLog
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public long Id { get; set; }

        public string Uuid { get; set; }

        public string Uri { get; set; }

        public string Method { get; set; }

        public string Param { get; set; }

        public string Behavior { get; set; }

        public string Content { get; set; }

        public string Remark { get; set; }

        public string Ip { get; set; }

        public string IpSource { get; set; }

        public string Os { get; set; }

        public string Browser { get; set; }

        public int Times { get; set; }

        public DateTime CreateTime { get; set; }

        public string UserAgent { get; set; }

        [SugarColumn(IsIgnore = true)]
        public string CustomProperty { get; set; } // 如果需要忽略某个属性在数据库中映射，则使用 [SugarColumn(IsIgnore = true)] 特性
    }

}
