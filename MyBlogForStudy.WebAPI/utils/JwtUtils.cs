//using Microsoft.IdentityModel.Tokens;
//using System.IdentityModel.Tokens.Jwt;
//using System.Security.Claims;
//using System.Text;

//namespace MyBlogForStudy.WebAPI.utils
//{
//    public class JwtUtils
//    {
//        private static string _secretKey;
//        private static long _expireTime;

//        public JwtUtils(IConfiguration configuration)
//        {
//            _secretKey = configuration["Token:SecretKey"];
//            _expireTime = Convert.ToInt64(configuration["Token:ExpireTime"]);
//        }

//        public void setSecretKey(String secretKey)
//        {
//            _secretKey = secretKey;
//        }
        

//        public static bool JudgeTokenIsExist(string token)
//        {
//            return !string.IsNullOrEmpty(token) && token != "null";
//        }

//        public static string GenerateToken(string subject)
//        {
//            var tokenHandler = new JwtSecurityTokenHandler();
//            var key = Encoding.ASCII.GetBytes(_secretKey);
//            var tokenDescriptor = new SecurityTokenDescriptor
//            {
//                Subject = new ClaimsIdentity(new[] { new Claim("sub", subject) }),
//                Expires = DateTime.UtcNow.AddMilliseconds(_expireTime),
//                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
//            };
//            var token = tokenHandler.CreateToken(tokenDescriptor);
//            return tokenHandler.WriteToken(token);
//        }
//         /**
//	     * 生成带角色权限的token
//	     *
//	     * @param subject
//	     * @param authorities
//	     * @return
//	     */
//        public static string GenerateToken(string subject, ICollection<Claim> claims)
//        {
//            var tokenHandler = new JwtSecurityTokenHandler();
//            var key = Encoding.ASCII.GetBytes(_secretKey);
//            var tokenDescriptor = new SecurityTokenDescriptor
//            {
//                Subject = new ClaimsIdentity(new[] { new Claim("sub", subject) }),
//                Expires = DateTime.UtcNow.AddMilliseconds(_expireTime),
//                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature),
//                Claims = new Dictionary<string, object> { ["claims"] = claims }
//            };
//            var token = tokenHandler.CreateToken(tokenDescriptor);
//            return tokenHandler.WriteToken(token);
//        }

//        public static string GenerateToken(string subject, long expireTime)
//        {
//            var tokenHandler = new JwtSecurityTokenHandler();
//            var key = Encoding.ASCII.GetBytes(_secretKey);
//            var tokenDescriptor = new SecurityTokenDescriptor
//            {
//                Subject = new ClaimsIdentity(new[] { new Claim("sub", subject) }),
//                Expires = DateTime.UtcNow.AddMilliseconds(expireTime),
//                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
//            };
//            var token = tokenHandler.CreateToken(tokenDescriptor);
//            return tokenHandler.WriteToken(token);
//        }

//        public static ClaimsPrincipal GetTokenBody(string token)
//        {
//            var tokenHandler = new JwtSecurityTokenHandler();
//            var key = Encoding.ASCII.GetBytes(_secretKey);
//            var validationParameters = new TokenValidationParameters
//            {
//                ValidateIssuerSigningKey = true,
//                IssuerSigningKey = new SymmetricSecurityKey(key),
//                ValidateIssuer = false,
//                ValidateAudience = false,
//                ClockSkew = TimeSpan.Zero
//            };
//            SecurityToken validatedToken;
//            var principal = tokenHandler.ValidateToken(token, validationParameters, out validatedToken);
//            return principal;
//        }
//    }
//}
