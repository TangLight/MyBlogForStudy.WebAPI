using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyBlog.IService;
using MyBlog.Model.DTO;
using MyBlog.Model.entity;
using MyBlog.Model.vo;
using MyBlog.Service;
using MyBlogForStudy.WebAPI.PageHelper;
using SqlSugar;
using System.Diagnostics.Eventing.Reader;

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
        private readonly IBlog_TagService _blog_TagService;

        public BlogAdminController(IBlogService blogService, ICategoryService categoryService, ITagService tagService, ICommentService commentService, IBlog_TagService blog_TagService)
        {
            _blogService = blogService;
            _categoryService = categoryService;
            _tagService = tagService;
            _commentService = commentService;
            _blog_TagService = blog_TagService;
        }

        [HttpGet("blogs")]
        public async Task<ActionResult> Blogs([FromQuery] string title = "", [FromQuery] int categoryId = 0, [FromQuery] int pageNum = 1, [FromQuery] int pageSize = 10)
        {
            RefAsync<int> total = 0;
            string orderBy = "create_time desc";

            PageInfo<Blog> pageInfo = new PageInfo<Blog>(await _blogService.QueryAsync());
            RefAsync<int> tota1all = (RefAsync<int>)pageInfo.Total;
            if (categoryId == 0&& title == "")
            {
                 pageInfo = new PageInfo<Blog>(await _blogService.QueryAsync(pageNum, pageSize, total));
                
            }
            else if(categoryId == 0 && title != "")
            {
                 pageInfo = new PageInfo<Blog>(await _blogService.QueryAsync(c => c.Title.Contains(title), pageNum, pageSize, total));
            }
            else if(categoryId != 0 && title == "")
            {
                 pageInfo = new PageInfo<Blog>(await _blogService.QueryAsync(c => c.Category.Id == categoryId, pageNum, pageSize, total));
            }
            else if (categoryId != 0 && title != "")
            {
                 pageInfo = new PageInfo<Blog>(await _blogService.QueryAsync(c => c.Title.Contains(title) && c.Category.Id == categoryId, pageNum, pageSize, total));
            }


                var categories = await _categoryService.QueryAsync();

            pageInfo.Total = tota1all;
            Dictionary<string, object> map = new  Dictionary<string, object>
            {
                { "blogs", pageInfo },
                { "categories", categories }
            };
            var result= Result.Ok("ok", map);
            return Ok(result);
        }




        [HttpDelete("blog")]
        //[OperationLogger("删除博客")]
        public Result Delete([FromQuery] long id)
        {
            //_blogService.DeleteBlogTagByBlogId(id);
            //_blogService.DeleteBlogById(id);
            //_commentService.DeleteCommentsByBlogId(id);
            _blogService.DeleteAsync(id);
            _blog_TagService.DeleteAsync(c=>c.BlogId==id);
            _commentService.DeleteAsync(c=>c.BlogId==id);
            return Result.Ok("删除成功");
        }

        [HttpGet("categoryAndTag")]
        public async Task<Result> CategoryAndTag()
        {
            //List<Category> categories = _categoryService.GetCategoryList();
            List<Category> categories = await _categoryService.QueryAsync();
            //List <Tag> tags = _tagService.GetTagList();
            List<Tag> tags = await _tagService.QueryAsync();
            Dictionary<string, object> map = new Dictionary<string, object>
            {
                { "categories", categories },
                { "tags", tags }
            };
            return Result.Ok("请求成功", map);
        }

        [HttpPut("blog/top")]
        //[OperationLogger("更新博客置顶状态")]
        public async Task<Result> UpdateTop([FromQuery] long id, [FromQuery] bool top)
        {
            //_blogService.UpdateBlogTopById(id, top);
            Blog blog=await _blogService.FindAsync(id);
            blog.Top = top;
            await _blogService.EditAsync(blog);
            return Result.Ok("操作成功");
        }

        [HttpPut("blog/recommend")]
        //[OperationLogger("更新博客推荐状态")]
        public async Task<Result> UpdateRecommend([FromQuery] long id, [FromQuery] bool recommend)
        {
            //_blogService.UpdateBlogRecommendById(id, recommend);
            Blog blog = await _blogService.FindAsync(id);
            blog.Recommend = recommend;
            await _blogService.EditAsync(blog);
            return Result.Ok("操作成功");
        }

        //[HttpPut("blog/{id}/visibility")]
        ////[OperationLogger("更新博客可见性状态")]
        //public async Task<Result> UpdateVisibility([FromRoute] long id, [FromBody] BlogVisibility blogVisibility)
        //{
        //    //_blogService.UpdateBlogVisibilityById(id, blogVisibility);

        //    return Result.Ok("操作成功");
        //}

        
        [HttpGet("blog")]
        public async Task<Result> GetBlog([FromServices] IMapper imapper,[FromQuery] long id)
        {

            var bloglist = await _blogService.QueryAsync(c => c.Id == id);
            var blog = bloglist.Find(c => c.Id == id);
            return Result.Ok("获取成功", blog);
        }

        [HttpPost("blog")]
        public async Task<Result> SaveBlog([FromServices] IMapper imapper, [FromBody] BlogDTO blogDTO)
        {
            Blog blog = imapper.Map<Blog>( blogDTO);
            await _blogService.CreateAsync(blog);

            return  Result.Ok("创建成功", blog);
        }


        //[HttpPut("blog")]
        //[OperationLogger("更新博客")]
        //public Result UpdateBlog([FromBody] Blog blog)
        //{
        //    return GetResult(blog, "update");
        //}
        [HttpPut("blog")]
        //[OperationLogger("更新博客")]
        public async Task<Result> UpdateBlog([FromQuery] long id,[FromServices] IMapper imapper, [FromBody] BlogDTO blogDTO )
        {
            if (id == 0&& blogDTO.ID!=0)
            {
                id = blogDTO.ID;
            }
            Blog blog = imapper.Map<Blog>(blogDTO);
            blog.Id = id;
            await _blogService.EditAsync(blog);
            return Result.Ok("更新成功", blog);
        }

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
