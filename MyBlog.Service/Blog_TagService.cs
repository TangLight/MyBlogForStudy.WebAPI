using MyBlog.IRepository;
using MyBlog.IService;
using MyBlog.Model.entity;
using MyBlog.Model.mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Service
{
    public class Blog_TagService : BaseService<Blog_Tag>, IBlog_TagService
    {
        private readonly IBlog_TagRepository _iBlog_TagRepository;
        public Blog_TagService(IBlog_TagRepository iBlog_TagRepository)
        {
            base._iBaseRepository = iBlog_TagRepository;
            _iBlog_TagRepository = iBlog_TagRepository;
        }
    }
    
}
