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
    public class TagAdminController : ControllerBase
    {
        private readonly IBlogService _blogService;
        private readonly ITagService _tagService;
        private readonly IBlog_TagService _blog_tagService;
        public TagAdminController(IBlogService blogService, ITagService tagService, IBlog_TagService blog_tagService)
        {
            _blogService = blogService;
            _tagService = tagService;
            _blog_tagService = blog_tagService;
        }

        [HttpGet("tags")]
        public async Task<Result> Tags(int pageNum = 1, int pageSize = 10)
        {
            RefAsync<int> total=0;
            string orderBy = "id desc";
            PageInfo<Tag> pageInfo = new PageInfo<Tag>(await _tagService.QueryAsync(pageNum, pageSize,total));
            return Result.Ok("请求成功", pageInfo);
        }

        [HttpPost("tag")]
        public async Task<Result> SaveTag([FromBody] Tag tag)
        {
            return await GetResult(tag, "save");
        }

        [HttpPut("tag")]
        public async Task<Result> UpdateTag([FromBody] Tag tag)
        {
            return await GetResult(tag, "update");
        }

        private async Task<Result> GetResult(Tag tag, string type)
        {
            if (string.IsNullOrEmpty(tag.Name))
            {
                return Result.Error("参数不能为空");
            }

            //Tag tag1 = _tagService.GetTagByName(tag.Name);
            Tag tag1 =await _tagService.FindAsync(c=>c.Name==tag.Name);
            if (tag1 != null && tag1.Id != tag.Id)
            {
                return Result.Error("该标签已存在");
            }

            if (type == "save")
            {
                //_tagService.SaveTag(tag);
                await _tagService.CreateAsync(tag);
                return Result.Ok("添加成功");
            }
            else
            {
                //_tagService.UpdateTag(tag);
                await _tagService.EditAsync(tag);
                return Result.Ok("更新成功");
            }
        }

        [HttpDelete("tag")]
        public async Task<Result> Delete([FromQuery] long id)
        {
            var _blog_taglist = await _blog_tagService.QueryAsync(c=>c.TagId==id);
            int num = 0;
            
            foreach (var _blog_tag in _blog_taglist)
            {
                if (_blog_tag.TagId== id)
                {
                    num++;
                }
            }
            //int num = _blogService.CountBlogByTagId(id);
            if (num != 0)
            {
                return Result.Error("已有博客与此标签关联，不可删除");
            }

            //_tagService.DeleteTagById(id);
            await _tagService.DeleteAsync(id);
            return Result.Ok("删除成功");
        }
    }
}
