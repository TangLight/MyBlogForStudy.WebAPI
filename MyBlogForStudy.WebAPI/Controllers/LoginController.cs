using Dm.filter.log;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MyBlog.IService;
using MyBlog.Model;
using MyBlog.Model.vo;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MyBlogForStudy.WebAPI.Controllers
{
    //[Route("/[controller]/[action]")]
    [ApiController]
    public class loginController : ControllerBase
    {
        private readonly IUserService _userService;

        public loginController(IUserService userService)
        {
            _userService = userService;
        }
        
        [HttpGet("admin/hllo")]
        public string hello(string s)
        {
            return s;
        }

        [HttpPost("admin/login")]
        public async Task<IActionResult> login([FromBody] LoginInfo loginInfo)
        {
            var  user = await _userService.FindAsync(c=>c.Username == loginInfo.Username&&c.Password==loginInfo.Password);
            
            if (user == null || user.Role != "ROLE_admin")
            {
                return Ok(Result.Create(403, "无权限"));
            }
            user.Password = null;
            string jwt = GenerateToken(user.Username); // 这里应该是您生成 JWT 令牌的逻辑
            var result = Result.Ok("登录成功", new { user, token = jwt });
            return Ok(result);
        }

        // 这是一个示例方法，用于生成身份验证令牌
        private string GenerateToken(string username)
        {
            // 定义密钥和签名算法
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("qwertyuiopasdfghjklzxcvbnm,qwertyuio")); // 替换为您自己的密钥
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // 创建声明列表，这些声明将被编码到令牌中
            var claims = new[]
            {
        new Claim(JwtRegisteredClaimNames.Sub, username),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        // 您可以添加任何其他的声明，这些声明将存储在令牌的"claims"部分中
    };

            // 创建JWT令牌
            var token = new JwtSecurityToken(
                issuer: "your-issuer", // 发行者
                audience: "your-audience", // 受众
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1), // 令牌过期时间
                signingCredentials: creds
            );

            // 将JWT令牌序列化为字符串
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
