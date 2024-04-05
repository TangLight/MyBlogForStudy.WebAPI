using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Model
{
    using SqlSugar;
    using System;

    public class VisitRecord
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public long Id { get; set; }

        public int Pv { get; set; }

        public int Uv { get; set; }

        public string Date { get; set; }

        public VisitRecord(int pv, int uv, string date)
        {
            Pv = pv;
            Uv = uv;
            Date = date;
        }
    }

}
