
using CoreWepAPI.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using CoreWepAPI.Model;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.Extensions.Options;

namespace CoreWepAPI.Repository
{
    public class RApplicationUser : IApplicationUser
    {
        public void UserLogin()
        {
            throw new NotImplementedException();
        }
    }
}
