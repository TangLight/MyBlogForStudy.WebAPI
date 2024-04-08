using MyBlog.IRepository;
using MyBlog.IService;
using MyBlog.Model.entity;
using MyBlog.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Service
{
    public class CategoryService : BaseService<Category>, ICategoryService
    {
        private readonly ICategoryRepository _iCategoryRepository;
        public CategoryService(ICategoryRepository iCategoryRepository)
        {
            base._iBaseRepository = iCategoryRepository;
            _iCategoryRepository = iCategoryRepository;
        }

        
    }
}
