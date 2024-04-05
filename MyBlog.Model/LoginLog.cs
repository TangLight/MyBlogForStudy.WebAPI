using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Model
{
    using SqlSugar;
    using System;

    public class LoginLog
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public long Id { get; set; }

        [SugarColumn(Length = 100)]
        public string Username { get; set; }

        [SugarColumn(Length = 50)]
        public string Ip { get; set; }

        [SugarColumn(Length = 50)]
        public string IpSource { get; set; }

        [SugarColumn(Length = 50)]
        public string Os { get; set; }

        [SugarColumn(Length = 50)]
        public string Browser { get; set; }

        public bool Status { get; set; }

        public string Description { get; set; }

        public DateTime CreateTime { get; set; }

        public string UserAgent { get; set; }

        public LoginLog(string username, string ip, bool status, string description, string userAgent)
        {
            Username = username;
            Ip = ip;
            Status = status;
            Description = description;
            CreateTime = DateTime.Now;
            UserAgent = userAgent;
        }
    }

}
