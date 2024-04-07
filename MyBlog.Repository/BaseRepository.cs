﻿
using MyBlog.IRepository;
using MyBlog.Model.entity;
using MyBlog.Model.mapper;
using SqlSugar;
using SqlSugar.IOC;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Repository
{
    //类必须放在接口前面
    public class BaseRepository<TEntity> : SimpleClient<TEntity>, IBaseRepository<TEntity> where TEntity : class, new()
    {
        public BaseRepository(ISqlSugarClient context = null) : base(context)
        {
            Console.WriteLine("创建数据库");
            base.Context = DbScoped.Sugar;
            // 创建数据库
            base.Context.DbMaintenance.CreateDatabase();
            // 创建表
            base.Context.CodeFirst.InitTables(
              typeof(BlogNews),
              typeof(TypeInfo),
              typeof(WriterInfo),
              typeof(Blog),
              typeof(Blog_Tag),
              typeof(BlogNews),
              typeof(Category),
              typeof(CityVisitor),
              typeof(Comment),
              typeof(ExceptionLog),
              typeof(Friend),
              typeof(LoginLog),
              typeof(Moment),
              typeof(OperationLog),
              typeof(ScheduleJob),
              typeof(ScheduleJobLog),
              typeof(SiteSetting),
              typeof(Tag),
              typeof(User),
              typeof(VisitLog),
              typeof(Visitor),
              typeof(VisitRecord),
              typeof(WriterInfo)
              );
        }
        public async Task<bool> CreateAsync(TEntity entity)
        {
            
            return await base.InsertAsync(entity);
        }
        public async Task<bool> DeleteAsync(int id)
        {
            return await base.DeleteByIdAsync(id);
        }
        public async Task<bool> DeleteAsync(long id)
        {
            return await base.DeleteByIdAsync(id);
        }
        public async Task<bool> DeleteAsync(Expression<Func<TEntity, bool>> func)
        {
            return await base.DeleteByIdAsync(func);
        }

        public async Task<bool> EditAsync(TEntity entity)
        {
            return await base.UpdateAsync(entity);
        }
        //导航查询
        public virtual async Task<TEntity> FindAsync(int id)
        {
            return await base.GetByIdAsync(id);
        }
        public virtual async Task<TEntity> FindAsync(long id)
        {
            return await base.GetByIdAsync(id);
        }

        public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> func)
        {
            return await base.GetSingleAsync(func);
        }

        public virtual async Task<List<TEntity>> QueryAsync()
        {
            return await base.GetListAsync();
        }

        public virtual async Task<List<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> func)
        {
            return await base.GetListAsync(func);
        }

        public virtual async Task<List<TEntity>> QueryAsync(int page, int size, RefAsync<int> total)
        {
            return await base.Context.Queryable<TEntity>()
              .ToPageListAsync(page, size, total);
        }

        public virtual async Task<List<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> func, int page, int size, RefAsync<int> total)
        {
            return await base.Context.Queryable<TEntity>()
              .Where(func)
              .ToPageListAsync(page, size, total);
        }
        
    }
}
