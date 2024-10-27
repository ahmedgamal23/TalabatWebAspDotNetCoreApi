using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TalabatWebAspDotNetCoreApi.Data.Model;
using TalabatWebAspDotNetCoreApi.Data.ModelViews;

namespace TalabatWebAspDotNetCoreApi.Data.Repositories.Account
{
    public class Login : IServiceAccount<DtoLogin>
    {
        private readonly AppDbContext _appDbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;

        public Login(AppDbContext appDbContext, UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            _appDbContext = appDbContext;
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<ModelError> Add(DtoLogin model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null)
            {
                bool result = await _userManager.CheckPasswordAsync(user, model.Password);
                if (result)
                {
                    // user is login successed

                    // generate JWT token 
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.UTF8.GetBytes(_configuration.GetSection("JWT:TokenKey").Value!);

                    List<Claim> claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.Email, model.Email));
                    claims.Add(new Claim( ClaimTypes.Role, user.Role ));

                    var tokenDescriptor = new SecurityTokenDescriptor()
                    {
                        Subject = new ClaimsIdentity(claims),
                        Expires = DateTime.UtcNow.AddHours(1),
                        Issuer = _configuration.GetSection("JWT:Issuer").Value,
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };

                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    var tokenString = tokenHandler.WriteToken(token);

                    //...............
                    return new ModelError() { IsError = false, Message = "Login success.....!" , tokenObject = new { Token = tokenString } };
                }
                return new ModelError() { IsError = true, Message = "Invalid Input Email or Password !" };
            }
            return new ModelError() { IsError = true, Message = "this email not exist !" };
        }
    }
}
