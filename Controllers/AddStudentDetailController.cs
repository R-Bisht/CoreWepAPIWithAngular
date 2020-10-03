using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CoreWepAPI.Model;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.Extensions.Options;
using CoreWepAPI.Infrastructure;

namespace CoreWepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddStudentDetailController : ControllerBase
    {

    }
}