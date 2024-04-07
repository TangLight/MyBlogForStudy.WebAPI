using MyBlog.Model.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Model.DTO
{
    public class BlogDTO
    {
        public string Title { get; set; }
        public string FirstPicture { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public int Cate { get; set; }
        public List<int> TagList { get; set; }
        public int Words { get; set; }
        public int ReadTime { get; set; }
        public int Views { get; set; }
        public bool Appreciation { get; set; }
        public bool Recommend { get; set; }
        public bool CommentEnabled { get; set; }
        public bool Top { get; set; }
        public bool Published { get; set; }
        public string Password { get; set; }
    }
}
