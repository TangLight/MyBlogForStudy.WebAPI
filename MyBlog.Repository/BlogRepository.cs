using MyBlog.IRepository;
using MyBlog.Model.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Repository
{
    public class BlogRepository : BaseRepository<Blog>, IBlogRepository
    {
    }
}
