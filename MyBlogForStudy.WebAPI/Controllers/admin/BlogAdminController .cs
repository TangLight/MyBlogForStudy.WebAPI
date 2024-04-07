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
    [Route("/admin")]
    public class BlogAdminController : ControllerBase
    {
        private readonly IBlogService _blogService;
        private readonly ICategoryService _categoryService;
        private readonly ITagService _tagService;
        private readonly ICommentService _commentService;

        public BlogAdminController(IBlogService blogService, ICategoryService categoryService, ITagService tagService, ICommentService commentService)
        {
            _blogService = blogService;
            _categoryService = categoryService;
            _tagService = tagService;
            _commentService = commentService;
        }

        [HttpGet("blogs")]
        public async Task<ActionResult> Blogs([FromQuery] string title = "", [FromQuery] int categoryId = 0, [FromQuery] int pageNum = 1, [FromQuery] int pageSize = 10)
        {
            RefAsync<int> total = 0;
            string orderBy = "create_time desc";

            PageInfo<Blog> pageInfo = new PageInfo<Blog>(await _blogService.QueryAsync());
            var categories = await _categoryService.QueryAsync();

            //if (!string.IsNullOrEmpty(title))
            //{
            //    pageInfo = await _blogService.QueryAsync(c => c.Title == title && c.Category.Id == categoryId, pageNum, pageSize, total);
            //}
            
            //if (categoryId!=0)
            //{
            //     categories = await _categoryService.QueryAsync(c => c.Id == categoryId);

            //}


                Dictionary<string, object> map = new  Dictionary<string, object>
            {
                { "blogs", pageInfo },
                { "categories", categories }
            };
            var result= Result.Ok("请求成功", map);
            return Ok(result);
        }




        //[HttpDelete("blog")]
        //[OperationLogger("删除博客")]
        //public Result Delete([FromQuery] long id)
        //{
        //    _blogService.DeleteBlogTagByBlogId(id);
        //    _blogService.DeleteBlogById(id);
        //    _commentService.DeleteCommentsByBlogId(id);
        //    return Result.Ok("删除成功");
        //}

        //[HttpGet("categoryAndTag")]
        //public Result CategoryAndTag()
        //{
        //    List<Category> categories = _categoryService.GetCategoryList();
        //    List<Tag> tags = _tagService.GetTagList();
        //    Dictionary<string, object> map = new Dictionary<string, object>
        //    {
        //        { "categories", categories },
        //        { "tags", tags }
        //    };
        //    return Result.Ok("请求成功", map);
        //}

        //[HttpPut("blog/top")]
        //[OperationLogger("更新博客置顶状态")]
        //public Result UpdateTop([FromQuery] long id, [FromQuery] bool top)
        //{
        //    _blogService.UpdateBlogTopById(id, top);
        //    return Result.Ok("操作成功");
        //}

        //[HttpPut("blog/recommend")]
        //[OperationLogger("更新博客推荐状态")]
        //public Result UpdateRecommend([FromQuery] long id, [FromQuery] bool recommend)
        //{
        //    _blogService.UpdateBlogRecommendById(id, recommend);
        //    return Result.Ok("操作成功");
        //}

        //[HttpPut("blog/{id}/visibility")]
        //[OperationLogger("更新博客可见性状态")]
        //public Result UpdateVisibility([FromRoute] long id, [FromBody] BlogVisibility blogVisibility)
        //{
        //    _blogService.UpdateBlogVisibilityById(id, blogVisibility);
        //    return Result.Ok("操作成功");
        //}

        //[HttpGet("blog")]
        //public Result GetBlog([FromQuery] long id)
        //{
        //    Blog blog = _blogService.GetBlogById(id);
        //    return Result.Ok("获取成功", blog);
        //}

        //[HttpPost("blog")]
        //[OperationLogger("发布博客")]
        //public Result SaveBlog([FromBody] Blog blog)
        //{
        //    return GetResult(blog, "save");
        //}

        //[HttpPut("blog")]
        //[OperationLogger("更新博客")]
        //public Result UpdateBlog([FromBody] Blog blog)
        //{
        //    return GetResult(blog, "update");
        //}

        //private Result GetResult(Blog blog, string type)
        //{
        //    if (StringUtils.IsEmpty(blog.Title, blog.FirstPicture, blog.Content, blog.Description) || blog.Words == null || blog.Words < 0)
        //    {
        //        return Result.Error("参数有误");
        //    }

        //    object cate = blog.Cate;
        //    if (cate == null)
        //    {
        //        return Result.Error("分类不能为空");
        //    }
        //    if (cate is int)
        //    {
        //        Category c = _categoryService.GetCategoryById((long)cate);
        //        blog.Category = c;
        //    }
        //    else if (cate is string)
        //    {
        //        Category category = _categoryService.GetCategoryByName((string)cate);
        //        if (category != null)
        //        {
        //            return Result.Error("不可添加已存在的分类");
        //        }
        //        Category c = new Category { Name = (string)cate };
        //        _categoryService.SaveCategory(c);
        //        blog.Category = c;
        //    }
        //    else
        //    {
        //        return Result.Error("分类不正确");
        //    }

        //    List<object> tagList = blog.TagList;
        //    List<Tag> tags = new List<Tag>();
        //    foreach (var t in tagList)
        //    {
        //        if (t is int)
        //        {
        //            Tag tag = _tagService.GetTagById((long)t);
        //            tags.Add(tag);
        //        }
        //        else if (t is string)
        //        {
        //            Tag tag1 = _tagService.GetTagByName((string)t);
        //            if (tag1 != null)
        //            {
        //                return Result.Error("不可添加已存在的标签");
        //            }
        //            Tag tag = new Tag { Name = (string)t };
        //            _tagService.SaveTag(tag);
        //            tags.Add(tag);
        //        }
        //        else
        //        {
        //            return Result.Error("标签不正确");
        //        }
        //    }

        //    DateTime date = DateTime.Now;
        //    if (blog.ReadTime == null || blog.ReadTime < 0)
        //    {
        //        blog.ReadTime = (int)Math.Round(blog.Words.Value / 200.0);
        //    }
        //    if (blog.Views == null || blog.Views < 0)
        //    {
        //        blog.Views = 0;
        //    }
        //    if ("save".Equals(type))
        //    {
        //        blog.CreateTime = date;
        //        blog.UpdateTime = date;
        //        User user = new User { Id = 1 };
        //        blog.User = user;

        //        _blogService.SaveBlog(blog);
        //        foreach (var t in tags)
        //        {
        //            _blogService.SaveBlogTag(blog.Id, t.Id);
        //        }
        //        return Result.Ok("添加成功");
        //    }
        //    else
        //    {
        //        blog.UpdateTime = date;
        //        _blogService.UpdateBlog(blog);
        //        _blogService.DeleteBlogTagByBlogId(blog.Id);
        //        foreach (var t in tags)
        //        {
        //            _blogService.SaveBlogTag(blog.Id, t.Id);
        //        }
        //        return Result.Ok("更新成功");
        //    }
        //}
    }
}
