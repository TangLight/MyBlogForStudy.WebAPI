using Microsoft.AspNetCore.Mvc;

namespace MyBlogForStudy.WebAPI.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
