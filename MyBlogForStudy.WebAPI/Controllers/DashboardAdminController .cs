//namespace MyBlogForStudy.WebAPI.Controllers
//{
//    using Microsoft.AspNetCore.Mvc;
//    using MyBlog.IService;
//    using MyBlog.Model.vo;
//    using System.Collections.Generic;
//    using System.Linq;

//    [Route("admin")]
//    [ApiController]
//    public class DashboardAdminController : ControllerBase
//    {
//        private readonly IDashboardService _dashboardService;
//        //private readonly IRedisService _redisService;

//        //public DashboardAdminController(IDashboardService dashboardService, IRedisService redisService)
//        //{
//        //    _dashboardService = dashboardService;
//        //    _redisService = redisService;
//        //}
//        public DashboardAdminController(IDashboardService dashboardService)
//        {
//            _dashboardService = dashboardService;
//        }
//        [HttpGet("dashboard")]
//        public ActionResult<Result> Dashboard()
//        {
//            int todayPV = _dashboardService.CountVisitLogByToday();
//            //int todayUV = _redisService.CountBySet(RedisKeyConstants.IDENTIFICATION_SET);
//            int todayUV = 0;
//            int blogCount = _dashboardService.GetBlogCount();
//            int commentCount = _dashboardService.GetCommentCount();
//            Dictionary<string, List<object>> categoryBlogCountMap = _dashboardService.GetCategoryBlogCountMap();
//            Dictionary<string, List<object>> tagBlogCountMap = _dashboardService.GetTagBlogCountMap();
//            Dictionary<string, List<object>> visitRecordMap = _dashboardService.GetVisitRecordMap();
//            List<CityVisitor> cityVisitorList = _dashboardService.GetCityVisitorList();

//            var map = new Dictionary<string, object>()
//        {
//            { "pv", todayPV },
//            { "uv", todayUV },
//            { "blogCount", blogCount },
//            { "commentCount", commentCount },
//            { "category", categoryBlogCountMap },
//            { "tag", tagBlogCountMap },
//            { "visitRecord", visitRecordMap },
//            { "cityVisitor", cityVisitorList }
//        };

//            return Result.Ok("获取成功", map);
//        }
//    }

//}
