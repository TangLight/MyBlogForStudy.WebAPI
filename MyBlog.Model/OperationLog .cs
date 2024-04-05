using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Model
{
    using SqlSugar;
    using System;

    public class OperationLog
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public long Id { get; set; }

        public string Username { get; set; }

        public string Uri { get; set; }

        public string Method { get; set; }

        public string Param { get; set; }

        public string Description { get; set; }

        public string Ip { get; set; }

        public string IpSource { get; set; }

        public string Os { get; set; }

        public string Browser { get; set; }

        public int Times { get; set; }

        public DateTime CreateTime { get; set; }

        public string UserAgent { get; set; }

        public OperationLog(string username, string uri, string method, string description, string ip, int times, string userAgent)
        {
            Username = username;
            Uri = uri;
            Method = method;
            Description = description;
            Ip = ip;
            Times = times;
            CreateTime = DateTime.Now;
            UserAgent = userAgent;
        }
    }

}
