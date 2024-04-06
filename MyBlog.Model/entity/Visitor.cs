using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Model.entity
{
    using SqlSugar;
    using System;

    public class Visitor
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public long Id { get; set; }

        public string Uuid { get; set; }

        public string Ip { get; set; }

        public string IpSource { get; set; }

        public string Os { get; set; }

        public string Browser { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime LastTime { get; set; }

        public int Pv { get; set; }

        public string UserAgent { get; set; }

        [SugarColumn(IsIgnore = true)]
        public string CustomProperty { get; set; } // 如果需要忽略某个属性在数据库中映射，则使用 [SugarColumn(IsIgnore = true)] 特性

        public Visitor(string uuid, string ip, string userAgent)
        {
            Uuid = uuid;
            Ip = ip;
            CreateTime = DateTime.Now;
            LastTime = DateTime.Now;
            Pv = 0;
            UserAgent = userAgent;
        }
    }

}
