using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Model
{
    using SqlSugar;
    using System;

    public class ScheduleJob
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public long JobId { get; set; }

        public string BeanName { get; set; }

        public string MethodName { get; set; }

        public string Params { get; set; }

        public string Cron { get; set; }

        public bool Status { get; set; }

        public string Remark { get; set; }

        public DateTime CreateTime { get; set; }

        [SugarColumn(IsIgnore = true)]
        public static string JobParamKey { get; } = "JOB_PARAM_KEY"; //任务调度参数key
    }

}
