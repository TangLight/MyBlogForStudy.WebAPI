using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Model.entity
{
    using SqlSugar;
    using System;

    public class ExceptionLog
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public long Id { get; set; }

        [SugarColumn(Length = 500)]
        public string Uri { get; set; }

        [SugarColumn(Length = 10)]
        public string Method { get; set; }

        public string Param { get; set; }

        public string Description { get; set; }

        public string Error { get; set; }

        [SugarColumn(Length = 50)]
        public string Ip { get; set; }

        [SugarColumn(Length = 50)]
        public string IpSource { get; set; }

        [SugarColumn(Length = 50)]
        public string Os { get; set; }

        [SugarColumn(Length = 50)]
        public string Browser { get; set; }

        public DateTime CreateTime { get; set; }

        public string UserAgent { get; set; }

        public ExceptionLog(string uri, string method, string description, string error, string ip, string userAgent)
        {
            Uri = uri;
            Method = method;
            Description = description;
            Error = error;
            Ip = ip;
            CreateTime = DateTime.Now;
            UserAgent = userAgent;
        }
    }

}
