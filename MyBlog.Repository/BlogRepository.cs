using MyBlog.IRepository;
using MyBlog.Model.entity;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Repository
{
    public class BlogRepository : BaseRepository<Blog>, IBlogRepository
    {
        //导航查询子类
        public async override Task<List<Blog>> QueryAsync()
        {
            return await base.Context.Queryable<Blog>()
              .Mapper(c => c.User, c => c.UserId, c => c.User.Id)
              .Mapper(c => c.Category, c => c.Cate, c => c.Category.Id)
              .ToListAsync();
        }
        public async override Task<List<Blog>> QueryAsync(Expression<Func<Blog, bool>> func)
        {
            return await base.Context.Queryable<Blog>()
              .Where(func)
              .Mapper(c => c.User, c => c.UserId, c => c.User.Id)
              .Mapper(c => c.Category, c => c.Cate, c => c.Category.Id)
              .Includes(x => x.Tags)
              .ToListAsync();
        }
        public async override Task<List<Blog>> QueryAsync(int page, int size, RefAsync<int> total)
        {
            return await base.Context.Queryable<Blog>()
              .Mapper(c => c.User, c => c.UserId, c => c.User.Id)
              .Mapper(c => c.Category, c => c.Cate, c => c.Category.Id)
              .ToPageListAsync(page, size, total);
        }
        public async override Task<List<Blog>> QueryAsync(Expression<Func<Blog, bool>> func, int page, int size, RefAsync<int> total)
        {
            return await base.Context.Queryable<Blog>()
              .Where(func)
              .Mapper(c => c.User, c => c.UserId, c => c.User.Id)
              .Mapper(c => c.Category, c => c.Cate, c => c.Category.Id)
              .ToPageListAsync(page, size, total);
        }


    }
    
    
}
