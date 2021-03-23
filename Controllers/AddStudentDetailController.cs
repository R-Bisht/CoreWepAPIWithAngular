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
using CoreWepAPI.Repository;
using CoreWepAPI.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
namespace CoreWepAPI.Controllers
{
   
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AddStudentDetailController : ControllerBase
    {

        private readonly IAddStudentDetail _IAddStudentDetail;
        public AddStudentDetailController(IAddStudentDetail IRRAddStudentDetail)
        {
            _IAddStudentDetail = IRRAddStudentDetail;
        }


        [Route("UpdateStudent")]
        [HttpPost]


        public async Task<ActionResult<AddStudentDetail>> UpdateStudentDetail(AddStudentDetail model)
        {
            try
            {
                var result = await _IAddStudentDetail.UpdateStudentDetail(model);
                return Ok(result.ASD_Id);

            }
            catch
            {
                return Ok("0");
                //return StatusCode(StatusCodes.Status500InternalServerError, "Error in Save Data");
            }

        }


        [Route("SaveStudentDetail")]
        [HttpPost]
       

        public async Task<ActionResult<AddStudentDetail>> PostStudentDetail(AddStudentDetail model)
        {
            try
            {
                var result = await _IAddStudentDetail.AddStudentDetail(model);
                return Ok(result.ASD_Id);

            }
            catch
            {
                return Ok("0");
                //return StatusCode(StatusCodes.Status500InternalServerError, "Error in Save Data");
            }
           
        }

        [Route("StudentList")]
        [HttpGet]
        // public async Task<ActionResult> GetStudentList()

        public IQueryable<Object> GetStudentList(int IdentityUserRole,int IdentityUserId) 
        {
            
                    return  _IAddStudentDetail.GetStudentList(IdentityUserRole,  IdentityUserId);
           

        }
        [Route("StudentGetDataByID/{studentid}")]
        [HttpGet]
        public IQueryable<Object> StudentGetDataByID(int studentid)
        {

            return _IAddStudentDetail.GetStudentDataById(studentid);


        }


        [Route("DeleteStudent/{StudentId}")]
        [HttpGet]
        //  [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<AddStudentDetail>> DeleteStudent(int StudentId)
        {
            try
            {

            var DeleteStudentData=  await _IAddStudentDetail.DeleteStudentByID(StudentId);

                if(DeleteStudentData==null)
                {
                    return NotFound(0);
                }
                else
                {
                    await _IAddStudentDetail.DeleteStudentByID(StudentId);
                    return Ok(12);

                }
               
                //return Ok("1");
            }
            catch
            {
               return StatusCode(StatusCodes.Status500InternalServerError, "Error in Delete Data");
            }
        }
    }
}