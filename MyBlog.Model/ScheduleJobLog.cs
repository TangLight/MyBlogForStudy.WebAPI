using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Model
{
    using SqlSugar;
    using System;

    public class ScheduleJobLog
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public long LogId { get; set; }

        public long JobId { get; set; }

        public string BeanName { get; set; }

        public string MethodName { get; set; }

        public string Params { get; set; }

        public bool Status { get; set; }

        public string Error { get; set; }

        public int Times { get; set; }

        public DateTime CreateTime { get; set; }
    }

}
