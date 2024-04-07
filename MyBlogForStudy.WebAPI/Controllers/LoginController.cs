using Dm.filter.log;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MyBlog.IService;
using MyBlog.Model.DTO;
using MyBlog.Model.vo;
using MyBlog.WebApi.Utility.ApiResult;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MyBlogForStudy.WebAPI.Controllers
{
    //[Route("/admin/[action]")]
    [ApiController]
    public class loginController : ControllerBase
    {
        private readonly IUserService _userService;

        public loginController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("admin/login")]
        public async Task<ActionResult> login([FromBody] LoginInfoDTO loginInfo)
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
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("SDMC-CJAS1-SAD-DFSFA-SADHJVF-VF-CDFS")); // 替换为您自己的密钥


            // 创建声明列表，这些声明将被编码到令牌中
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                // 您可以添加任何其他的声明，这些声明将存储在令牌的"claims"部分中

            };
            // 创建JWT令牌
            var token = new JwtSecurityToken(
                   issuer: "http://localhost:6060",
                   audience: "http://localhost:5000",
                   claims: claims,
                   notBefore: DateTime.Now,
                   expires: DateTime.Now.AddHours(24),
                   signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
               );

            // 将JWT令牌序列化为字符串
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
