using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBlog.Model.entity;

namespace MyBlog.IRepository
{
    public interface IUserRepository : IBaseRepository<User>
    {
    }
}
