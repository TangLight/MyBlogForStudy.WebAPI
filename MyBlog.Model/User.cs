using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Model
{
    public class User : BaseId
    {
        [SugarColumn(ColumnDataType = "nvarchar(12)")]
        public string Username { get; set; }
        [SugarColumn(ColumnDataType = "nvarchar(12)")]
        public string Password { get; set; }
        [SugarColumn(ColumnDataType = "nvarchar(32)")]
        public string Nickname { get; set; }
        [SugarColumn(ColumnDataType = "nvarchar(32)")]
        public string Avatar { get; set; }
        [SugarColumn(ColumnDataType = "nvarchar(32)")]
        public string Email { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        [SugarColumn(ColumnDataType = "nvarchar(32)")]
        public string Role { get; set; }
    }
}
