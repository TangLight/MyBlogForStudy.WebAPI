using Microsoft.AspNetCore.Mvc;
using MyBlog.IService;
using MyBlog.Model.vo;
using MyBlog.Model.entity;
using MyBlogForStudy.WebAPI.utils;
using MyBlogForStudy.WebAPI.constant;

namespace MyBlogForStudy.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService _blogService;
        private readonly IUserService _userService;

        public BlogController(IBlogService blogService, IUserService userService)
        {
            _blogService = blogService;
            _userService = userService;
        }

        [HttpGet("blogs")]

        //public async Task<Result> GetBlogs([FromQuery] int pageNum = 1)
        //{
        //    var pageResult = await _blogService.GetBlogInfoListByIsPublished(pageNum);
        //    return Result.Ok("请求成功", pageResult);
        //}
        public async Task<Result> GetBlogs([FromQuery] int pageNum = 1)
        {
            var pageResult = await _blogService.QueryAsync(pageNum, 10, 0);
            return Result.Ok("请求成功", pageResult);
        }

        [HttpGet("blog")]
        //[VisitLogger(VisitBehavior.BLOG)]
        public async Task<Result> GetBlog([FromQuery] long id, [FromHeader(Name = "Authorization")] string jwt = "")
        {
            //var blogDetail = await _blogService.GetBlogByIdAndIsPublished(id);
            var blogDetail = await _blogService.FindAsync(c=>c.Id == id);
            // 校验密码保护的文章
            if (!string.IsNullOrEmpty(blogDetail.Password))
            {
                if (JwtUtils.JudgeTokenIsExist(jwt))
                {
                    try
                    {
                        var principal = JwtUtils.GetTokenBody(jwt);
                        var subject = principal.Claims.FirstOrDefault(c => c.Type == "sub")?.Value;

                        
                        if (subject.StartsWith(JwtConstants.ADMIN_PREFIX))
                        {
                            var username = subject.Replace(JwtConstants.ADMIN_PREFIX, "");
                            //var admin = (User)await _userService.LoadUserByUsername(username);
                            var admin = (User)await _userService.FindAsync(c=>c.Username == username);
                            if (admin == null)
                            {
                                return Result.Create(403, "博主身份Token已失效，请重新登录！");
                            }
                        }
                        else
                        {
                            var tokenBlogId = long.Parse(subject);
                            if (!tokenBlogId.Equals(id))
                            {
                                return Result.Create(403, "Token不匹配，请重新验证密码！");
                            }
                        }
                    }
                    catch
                    {
                        return Result.Create(403, "Token已失效，请重新验证密码！");
                    }
                }
                else
                {
                    return Result.Create(403, "此文章受密码保护，请验证密码！");
                }
                blogDetail.Password = "";
            }
            //await _blogService.UpdateViewsToRedis(id);
            return Result.Ok("获取成功", blogDetail);
        }

        //    [HttpPost("checkBlogPassword")]
        //    [VisitLogger(VisitBehavior.CHECK_PASSWORD)]
        //    public Result CheckBlogPassword([FromBody] BlogPassword blogPassword)
        //    {
        //        var password = _blogService.GetBlogPassword(blogPassword.BlogId);
        //        if (password.Equals(blogPassword.Password))
        //        {
        //            var jwt = JwtUtils.GenerateToken(blogPassword.BlogId.ToString(), 1000 * 3600 * 24 * 30);
        //            return Result.Ok("密码正确", jwt);
        //        }
        //        else
        //        {
        //            return Result.Create(403, "密码错误");
        //        }
        //    }

        //    [HttpGet("searchBlog")]
        //    [VisitLogger(VisitBehavior.SEARCH)]
        //    public Result SearchBlog([FromQuery] string query)
        //    {
        //        if (string.IsNullOrEmpty(query) || StringUtils.HasSpecialChar(query) || query.Trim().Length > 20)
        //        {
        //            return Result.Error("参数错误");
        //        }
        //        var searchBlogs = _blogService.GetSearchBlogListByQueryAndIsPublished(query.Trim());
        //        return Result.Ok("获取成功", searchBlogs);
        //    }
        //}
    }
}
