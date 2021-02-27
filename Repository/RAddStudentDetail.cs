using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreWepAPI.Infrastructure;
using CoreWepAPI.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using Twilio.TwiML;
using Twilio.AspNet.Core;
using Microsoft.AspNetCore.Http;

namespace CoreWepAPI.Repository
{
    public class RAddStudentDetail : IAddStudentDetail
    {

        private readonly SMSApplication _SMSSettings;

        private readonly RoleManager<IdentityRole> _roleManager;
        
       private readonly UserManager<ApplicationUser> _userManager;

        private readonly IConfiguration _configuration;
        private readonly AuthenticationContext _Context;

        public RAddStudentDetail(AuthenticationContext Context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager,IConfiguration configuration, IOptions<SMSApplication> SMSSettings)
        {
            _Context = Context;
           this._userManager = userManager ;
            this._roleManager = roleManager;
            _configuration = configuration;
            _SMSSettings = SMSSettings.Value;

        }

        public async Task<AddStudentDetail> AddStudentDetail(AddStudentDetail Student)
        {
            // _Context.Districts.Where(a => a.DST_STATEID == StateId).ToListAsync();
            // var StudentEmail= _userManager.FindByNameAsync()
            

            ApplicationUser ExistStudentUserId = await _Context.ApplicationUsers.SingleOrDefaultAsync(x => x.UserName == Student.ASD_UserName);
           // ApplicationUser ExistStudentEmailId = await _Context.ApplicationUsers.SingleOrDefaultAsync(y => y.Email == Student.ASD_EmailId);
           // ApplicationUser ExistStudentMobileNo = await _Context.ApplicationUsers.SingleOrDefaultAsync(z => z.PhoneNumber == Convert.ToString(Student.ASD_PhoneNo));

            if (ExistStudentUserId == null)
            {
                

                    try
                    {
                        var resultstudent = await _Context.addStudentDetails.AddAsync(Student);
                        await _Context.SaveChangesAsync();
                        var StudentIds = resultstudent.Entity;


                        var applicationUser = new ApplicationUser()
                        {
                            UserName = Student.ASD_UserName,
                            Email = Student.ASD_EmailId,
                            FullName = (Student.ASD_FirstName) + " " + (Student.ASD_LastName),
                            NormalizedUserName = Student.ASD_UserName,
                            NormalizedEmail = Student.ASD_EmailId,
                            LockoutEnabled = true,
                            PhoneNumberConfirmed = true,
                            EmailConfirmed = true,
                            UserRoleID = Student.ASD_Application_Role,
                            PhoneNumber = Convert.ToString(Student.ASD_PhoneNo),
                            StudentId = StudentIds.ASD_Id,

                        };


                        var result = _Context.ApplicationUsers.AddAsync(applicationUser);
                        await _Context.SaveChangesAsync();

                        var accountsid = _SMSSettings.UserName;//"ACdb6c8eb26449187c76afe22fc845631d"; //ConfigurationManager.AppSettings["UserName"];
                        var authtoken = _SMSSettings.Password; //"616af29b7ea8a863ada5cf1c0cf8fb02"; //_SMSSettings.Password; 

                        TwilioClient.Init(accountsid, authtoken);
                        var to = new PhoneNumber("+91" + Student.ASD_PhoneNo);
                        var from = new PhoneNumber(_SMSSettings.FromNumber);

                        var message = MessageResource.Create(
                            to: to,
                            from: from,
                            body: "Dear Student Your Registration No :" + Student.ASD_UserName + ".Please Create Your Password");


                    if (Student.ASD_Application_Role == 4)
                    {
                        // _Context.CreateAsync(applicationUser);
                        if (!await _roleManager.RoleExistsAsync(UserRole.User))

                            await _roleManager.CreateAsync(new IdentityRole(UserRole.User));
                        if (await _roleManager.RoleExistsAsync(UserRole.User))
                        {
                            await _userManager.AddToRoleAsync(applicationUser, UserRole.User);

                        }
                    }
                    else
                    {
                        if (!await _roleManager.RoleExistsAsync(UserRole.Admin))

                           await _roleManager.CreateAsync(new IdentityRole(UserRole.Admin));
                        if (await _roleManager.RoleExistsAsync(UserRole.Admin))
                        {
                          await _userManager.AddToRoleAsync(applicationUser, UserRole.Admin);

                          }
                    }

                    return resultstudent.Entity;
                    }
                    catch (Exception e)
                    {
                        throw e;
                      //  return StatusCode(StatusCodes.Status500InternalServerError, "Error in Save Data");
                    }

              
            }
            else
            {
                return null;
                //Student DataResult = 0;

                //return Student. DataResult;



            }
        }



        //  public async Task<IEnumerable<AddStudentDetail>> GetStudentList()

        public IQueryable<Object> GetStudentList(int IdentityUserRole, int IdentityUserId)

        {

            // return await _Context.addStudentDetails.ToListAsync();



            var StudentDetail = (
                 from ASD in _Context.addStudentDetails
                 join STD in _Context.States on ASD.ASD_State equals STD.STD_ID
                 join DST in _Context.Districts on ASD.ASD_Distric equals DST.DST_Id
                 join CTG in _Context.Categories on ASD.ASD_Category equals CTG.CTG
                 join STC in _Context.studentClasses on ASD.ASD_StudentClass equals STC.STC
                 select new
                 {
                     StudentId = ASD.ASD_Id,
                     StudentFirst = ASD.ASD_FirstName,
                     StudentLast = ASD.ASD_LastName,
                     StudentFatherName = ASD.ASD_FatherName,
                     StudentMotherName = ASD.ASD_MotherName,
                     StudentState = STD.STD_NAME,
                     StudentDistrict = DST.DST_DISTICT,
                     StudentMobileNo = ASD.ASD_MotherName,
                     StudentEmail = ASD.ASD_EmailId,
                     StudentAadharNo = ASD.ASD_AadharNo,
                     StudentDOB = ASD.ASD_DOB,            

                     StudentDOJ = ASD.ASD_DOJ,
                     StudentCatergory = CTG.CTG_NAME,
                     StudentClass = STC.STC_NAME,
                     StudentTeacher = ASD.ASD_TeacherName,
                     StudentGender = (ASD.ASD_gender == 1 ? "Male" : ASD.ASD_gender == 2 ? "Female" : "Other"), //USE  CASE
                     StudentAddress = ASD.ASD_PermanentAddress,
                     StudentRole=ASD.ASD_Application_Role


                 });
            if(IdentityUserRole == 4 && IdentityUserId!=0)
            {
                StudentDetail = StudentDetail.Where(a => a.StudentId == IdentityUserId);
            }

         



            return StudentDetail;
        }
    }
}
    //).ToListAsync();

    //    var AsyncStudentDetail = await Task.WhenAll(StudentResult).toListAsync();

    // return StudentResult; 

        
    

