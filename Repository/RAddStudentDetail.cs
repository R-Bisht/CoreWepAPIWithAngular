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

        public async Task<AddStudentDetail> UpdateStudentDetail(AddStudentDetail Student)
       
        {
            


            try
            {
                AddStudentDetail Stud = _Context.addStudentDetails.First(i => i.ASD_Id == Student.ASD_Id);
                Stud.ASD_FirstName = Student.ASD_FirstName;
                Stud.ASD_LastName = Student.ASD_LastName;
                Stud.ASD_FatherName = Student.ASD_FatherName;
                Stud.ASD_MotherName = Student.ASD_MotherName;
                Stud.ASD_PhoneNo = Student.ASD_PhoneNo;
                Stud.ASD_EmailId = Student.ASD_EmailId;
                Stud.ASD_Application_Role = Student.ASD_Application_Role;
                Stud.ASD_UserName = Student.ASD_UserName;
                Stud.ASD_AadharNo = Student.ASD_AadharNo;
                Stud.ASD_State = Student.ASD_State;
                Stud.ASD_Distric = Student.ASD_Distric;
                Stud.ASD_Category = Student.ASD_Category;
                Stud.ASD_DOB = Student.ASD_DOB;
                Stud.ASD_DOJ = Student.ASD_DOJ;
                Stud.ASD_TeacherName = Student.ASD_TeacherName;
                Stud.ASD_PrincipalName = Student.ASD_PrincipalName;
                Stud.ASD_gender = Student.ASD_gender;
                Stud.ASD_PermanentAddress = Student.ASD_PermanentAddress;
                Stud.ASD_TemporaryAddress = Student.ASD_TemporaryAddress;
                Stud.ASD_SignatureName = Student.ASD_SignatureName;
                Stud.ASD_ImageName = Student.ASD_ImageName;
                Stud.ASD_Leaving_Status = Student.ASD_Leaving_Status;
               await  _Context.SaveChangesAsync();

                //    int StudentId = Stud.ASD_Id;

                ApplicationUser ApplicationUser = _Context.ApplicationUsers.SingleOrDefault(x => x.StudentId == Student.ASD_Id);


                ApplicationUser.UserName = Student.ASD_UserName;
                ApplicationUser.Email = Student.ASD_EmailId;
                ApplicationUser.FullName = (Student.ASD_FirstName) + " " + (Student.ASD_LastName);
                ApplicationUser.NormalizedUserName = Student.ASD_UserName;
                ApplicationUser.NormalizedEmail = Student.ASD_EmailId;
                ApplicationUser.LockoutEnabled = true;
                ApplicationUser.PhoneNumberConfirmed = true;
                ApplicationUser.EmailConfirmed = true;
                ApplicationUser.UserRoleID = Student.ASD_Application_Role;
                ApplicationUser.PhoneNumber = Convert.ToString(Student.ASD_PhoneNo);
                await _Context.SaveChangesAsync();

                if (Student.ASD_Application_Role == 4)
                {
                    // _Context.CreateAsync(applicationUser);
                    if (!await _roleManager.RoleExistsAsync(UserRole.User))

                        await _roleManager.CreateAsync(new IdentityRole(UserRole.User));
                    if (await _roleManager.RoleExistsAsync(UserRole.User))
                    {
                        await _userManager.AddToRoleAsync(ApplicationUser, UserRole.User); // .[AspNetUserRoles]

                    }
                }
                else
                {
                    if (!await _roleManager.RoleExistsAsync(UserRole.Admin))

                        await _roleManager.CreateAsync(new IdentityRole(UserRole.Admin));
                    if (await _roleManager.RoleExistsAsync(UserRole.Admin))
                    {
                        await _userManager.AddToRoleAsync(ApplicationUser, UserRole.Admin);

                    }
                }


                return Stud;

            }
            catch(Exception ex)
            {
                throw ex;
            }


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
                            await _userManager.AddToRoleAsync(applicationUser, UserRole.User); // .[AspNetUserRoles]

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

        public IQueryable<Object> GetStudentDataById(int StudentId)
        {
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
                   StudentState = ASD.ASD_State,
                   StudentDistrict = ASD.ASD_Distric,
                   StudentMobileNo = ASD.ASD_MotherName,
                   StudentEmail = ASD.ASD_EmailId,
                   StudentAadharNo = ASD.ASD_AadharNo,
                   StudentDOB = ASD.ASD_DOB.ToString("yyyy-MM-dd"),
                   StudentDOJ = ASD.ASD_DOJ.ToString("yyyy-MM-dd"),
                   StudentPhoneNo=ASD.ASD_PhoneNo,
                   StudentCatergory = ASD.ASD_Category,
                   StudentClass = ASD.ASD_StudentClass,
                   StudentTeacher = ASD.ASD_TeacherName,
                   StudentGender = ASD.ASD_gender, //USE  CASE
                   StudentPAddress = ASD.ASD_PermanentAddress,
                   StudentTAddress = ASD.ASD_TemporaryAddress,
                   StudentRole = ASD.ASD_Application_Role,
                   StudentPrincipal=ASD.ASD_PrincipalName,
                   StudentUserName=ASD.ASD_UserName,
                   StudentPic=ASD.ASD_SignatureName


               });
             if (StudentId != 0)
            {
                StudentDetail = StudentDetail.Where(a => a.StudentId == StudentId);
            }






            return StudentDetail;


        }

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
            //else if(IdentityUserId!=0)
            //{
            //    StudentDetail = StudentDetail.Where(a => a.StudentId == IdentityUserId);
            //}

         



            return StudentDetail;
        }

        public async Task<AddStudentDetail> DeleteStudentByID(int StudentId)
        {
            // return await _Context.Districts.FirstOrDefaultAsync(a => a.DST_STATEID == StateId);

            //var Student= _Context.addStudentDetails.Where(a => a.ASD_Id == StudentId).Single();
            // _Context.Entry(Student).State = EntityState.Deleted;
            //   _Context.SaveChanges();

            var Student = await _Context.addStudentDetails.FirstOrDefaultAsync(a => a.ASD_Id == StudentId);
            var StudentID = await _Context.ApplicationUsers.FirstOrDefaultAsync(a => a.StudentId == StudentId);
            if (Student!=null && StudentID!=null)
            {
                _Context.ApplicationUsers.Remove(StudentID);
                await _Context.SaveChangesAsync();

                _Context.addStudentDetails.Remove(Student);
                 await  _Context.SaveChangesAsync();

               
                

            }
            return Student;


        }

       

        }
}
    //).ToListAsync();

    //    var AsyncStudentDetail = await Task.WhenAll(StudentResult).toListAsync();

    // return StudentResult; 

        
    

