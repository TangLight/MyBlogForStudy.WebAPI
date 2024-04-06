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
    public class TagService : BaseService<Tag>, ITagService
    {
        private readonly ITagRepository _iTagRepository;
        public TagService(ITagRepository iTagRepository)
        {
            base._iBaseRepository = iTagRepository;
            _iTagRepository = iTagRepository;
        }
    }
}
