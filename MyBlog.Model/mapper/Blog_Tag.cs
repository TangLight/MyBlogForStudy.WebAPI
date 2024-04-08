﻿using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Model.mapper
{
    [SugarTable("Blog_Tag")]
    public class Blog_Tag
    {
        public long BlogId { get; set; }

        public long TagId { get; set; }
    }
}
