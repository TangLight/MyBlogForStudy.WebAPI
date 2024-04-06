using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Model.entity
{
    using SqlSugar;

    [SugarTable("CityVisitor")]
    public class CityVisitor
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        [SugarColumn(Length = 100)]
        public string City { get; set; }

        public int Uv { get; set; }
    }

}
