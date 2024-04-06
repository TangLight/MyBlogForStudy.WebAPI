using MyBlog.Model.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MyBlog.IRepository
{
    public interface ICommentRepository : IBaseRepository<Comment>
    {
    }
}
