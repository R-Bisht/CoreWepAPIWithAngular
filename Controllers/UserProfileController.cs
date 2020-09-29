using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using CoreWepAPI.Model;

namespace CoreWepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;
        public UserProfileController(UserManager<ApplicationUser> usermanager)
        {
            _userManager = usermanager;
        }

        [HttpGet]

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]


        public async Task<Object> GetUserProfile()
        {
            string UserId = User.Claims.First(c => c.Type == "Userid").Value;
            var user = await _userManager.FindByIdAsync(UserId);
            return new
            {
                user.FullName,
                user.Email,
                user.UserName
            };

        }
    }
}