using MyBlog.IRepository;
using MyBlog.IService;
using MyBlog.Model.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Service
{
    public class BlogService : BaseService<Blog>, IBlogService
    {
        private readonly IBlogRepository _iBlogRepository;
        public BlogService(IBlogRepository iBlogRepository)
        {
            base._iBaseRepository = iBlogRepository;
            _iBlogRepository = iBlogRepository;
        }

    }
}
