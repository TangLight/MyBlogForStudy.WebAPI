using Microsoft.AspNetCore.Mvc;
using MyBlog.IService;
using MyBlog.Model.entity;
using MyBlog.Model.vo;
using MyBlog.Service;
using MyBlogForStudy.WebAPI.PageHelper;
using SqlSugar;

namespace MyBlogForStudy.WebAPI.Controllers.admin
{
    [ApiController]
    [Route("admin")]
    public class CategoryAdminController : ControllerBase
    {
        private readonly ILogger<CategoryAdminController> _logger;
        private readonly IBlogService _blogService;
        private readonly ICategoryService _categoryService;

        public CategoryAdminController(IBlogService blogService, ILogger<CategoryAdminController> logger, ICategoryService categoryService)
        {
            _blogService = blogService;
            _logger = logger;
            _categoryService = categoryService;
        }


        [HttpGet("categories")]
        public async Task<Result> GetCategories(int pageNum = 1, int pageSize = 10)
        {
            RefAsync<int> total = 0;
            string orderBy = "create_time desc";
            PageInfo<Category> pageInfoall = new PageInfo<Category>(await _categoryService.QueryAsync());
            RefAsync<int> tota1all = (RefAsync<int>)pageInfoall.Total;
            PageInfo<Category> pageInfo = new PageInfo<Category>(await _categoryService.QueryAsync(pageNum, pageSize,total));
            pageInfo.Total = tota1all;
            //var categoryList = await _categoryService.GetCategoryListAsync();
            //var categoryList = await _categoryService.QueryAsync();

            return Result.Ok("请求成功", pageInfo);
        }

        [HttpPost("category")]
        public async Task<Result> SaveCategory([FromBody] Category category)
        {
            return await GetResult(category, "save");
        }

        [HttpPut("category")]
        public async Task<Result> UpdateCategory([FromBody] Category category)
        {
            return await GetResult(category, "update");
        }

        private async Task<Result> GetResult(Category category, string type)
        {
            if (string.IsNullOrEmpty(category.Name))
            {
                return Result.Error("分类名称不能为空");
                
            }

            //var category1 = await _categoryService.GetCategoryByNameAsync(category.Name);
            var category1 = await _categoryService.FindAsync(c=>c.Name==category.Name);
            if (category1 != null && category1.Id != category.Id)
            {
                return Result.Error("该分类已存在");
            }

            if (type == "save")
            {
                //await _categoryService.SaveCategoryAsync(category);
                await _categoryService.CreateAsync(category);
                return Result.Ok("分类添加成功");
            }
            else
            {
                await _categoryService.EditAsync(category);
                return Result.Ok("分类更新成功");
            }
        }

        [HttpDelete("category")]
        public async Task<Result> DeleteCategory(long id)
        {
            //var num = await _blogService.CountBlogByCategoryIdAsync(id);
            var bloglist = await _blogService.QueryAsync();
            int num = 0;
            foreach(var blog in bloglist)
            {
                if(blog.Category.Id == id)
                {
                    num++;
                }
            }
            if (num != 0)
            {
                return Result.Error("已有博客与此分类关联，不可删除");
            }
            await _categoryService.DeleteAsync(id);
            return Result.Ok("删除成功");
        }
    }
}
