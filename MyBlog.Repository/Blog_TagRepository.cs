using MyBlog.IRepository;
using MyBlog.Model.entity;
using MyBlog.Model.mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Repository
{
    public class Blog_TagRepository : BaseRepository<Blog_Tag>, IBlog_TagRepository
    {
    }
}
