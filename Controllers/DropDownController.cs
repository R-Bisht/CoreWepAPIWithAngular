using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CoreWepAPI.Model;
using CoreWepAPI.Repository;
using CoreWepAPI.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace CoreWepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DropDownController : ControllerBase
    {
        //  private readonly AuthenticationContext _Context;
        private readonly IDropDown _IRDropDown;
        public DropDownController(IDropDown IRDropDown)
        {
            _IRDropDown = IRDropDown;
        }

        [Route("State")]
        [HttpGet]

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> GetStateName()
        {
            //var result= await _Context.States.ToListAsync();
            //return Ok(result);
            try
            {
                return Ok(await _IRDropDown.GetStates());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Retrieving Data");
            }

        }

        [Route("District/{StateId}")]
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> GetDistrictName(int StateId)
        {
            try
            {
                return Ok(await _IRDropDown.GetDistrict(StateId));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Retrieving Data");
            }
        }
    }
}