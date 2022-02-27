using BusinessModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ProviderService.IDataProvider;
using SessionProvider.IProvider;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Ng_Admin.Controllers
{
    [Route("webapi/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserMasterProvider _context;
        private ISessionProviderService _sessionProvider;

        public AuthController(IUserMasterProvider userMasterProvider, ISessionProviderService sessionProvider)
        {
            this._context = userMasterProvider;
            this._sessionProvider = sessionProvider;
        }

        [HttpPost]
        public IActionResult Login([FromBody] AuthModel auth)
        {
            IActionResult response = Unauthorized();
            AuthResModel res = _context.Authentication(auth);
            if (res.IsSuccess)
            {
                res.Token = GenerateJSONWebToken(res);
                res.UserId = 0;
                res.Username = null;
                response = Ok(res);
            }
            else
            {
                return Ok(res.Message);
            }
            return response;
        }
        protected string GenerateJSONWebToken(AuthResModel authRes)
        {
            var claims = new[] {
                new Claim("UserId", authRes.UserId.ToString()),
                new Claim("Username",authRes.Username.ToString()),
               
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("950D1E04AB1F4C7CBB10938B0BB864B0"));

            var token = new JwtSecurityToken(
              issuer: null,
              audience: null,
              claims: claims,
              notBefore: new DateTimeOffset(DateTime.Now).DateTime,
              expires: new DateTimeOffset(DateTime.Now.AddDays(1)).DateTime,//expires: new DateTimeOffset(DateTime.Now.AddDays(1)).DateTime,
              signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256));
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
