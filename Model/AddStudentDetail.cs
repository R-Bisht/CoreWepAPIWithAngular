using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace CoreWepAPI.Model
{
    public class AddStudentDetail
    {
        [Key]
        public int ASD_Id { get; set; }
        

        [Column(TypeName ="varchar(200)")]
        [Required]
        public string ASD_FirstName { get; set; }

        [Column(TypeName = "varchar(250)")]
        [Required]
        public string ASD_LastName { get; set; }

        [Column(TypeName = "varchar(250)")]
        [Required]
        public string ASD_FatherName { get; set; }

        [Column(TypeName = "varchar(250)")]
        [Required]
        public string ASD_MotherName { get; set; }

        [Column(TypeName = "bigint")]
        public long ASD_PhoneNo { get; set; }

        [Column(TypeName = "varchar(250)")]
        public string ASD_EmailId { get; set; }

        [Column(TypeName = "bigint")]
        [Required]
        public long ASD_AadharNo { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime ASD_DOB { get; set; }

        [Column(TypeName = "int")]
        public int ASD_State { get; set; }

        [Column(TypeName = "int")]
        public int ASD_Distric { get; set; }

        [Column(TypeName = "int")]
        public int ASD_Category { get; set; }

        [Column(TypeName = "int")]
        public int ASD_StudentClass { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime ASD_DOJ { get; set; }

        [Column(TypeName = "int")]
        public int ASD_gender { get; set; }

        [Column(TypeName = "varchar(200)")]
        public string ASD_PrincipalName { get; set; }

        [Column(TypeName = "varchar(200)")]
        public string ASD_TeacherName { get; set; }

        [Column(TypeName = "int")]
        public int ASD_Leaving_Status { get; set; }

        [Column(TypeName = "varchar(250)")]
        public string ASD_PermanentAddress { get; set; }

        [Column(TypeName = "varchar(250)")]
        public string ASD_TemporaryAddress { get; set; }

        [Column(TypeName = "varchar(250)")]
        public string ASD_ImageName { get; set; }

        [Column(TypeName = "varchar(250)")]
        public string ASD_SignatureName { get; set; }

        [Column(TypeName = "int")]
        public int ASD_Application_Role { get; set; }

        [Column(TypeName = "varchar(200)")]
        public string ASD_UserName { get; set; }

        [Column(TypeName = "int")]
        public int ASD_CreateBy { get; set; }

        [Column(TypeName = "DateTime")]
        public DateTime ASD_CreatedDate { get; set; }


    }
}
