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
    public class CommentService : BaseService<Comment>, ICommentService
    {
        private readonly ICommentRepository _iCommentRepository;
        public CommentService(ICommentRepository iCommentRepository)
        {
            base._iBaseRepository = iCommentRepository;
            _iCommentRepository = iCommentRepository;
        }
    }
}
