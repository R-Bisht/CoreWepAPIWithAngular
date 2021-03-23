using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWepAPI.Model
{
    public class AddTeacherDetail
    {
        [Key]
        public int TeacherId { get; set; }

        [Column(TypeName = "varchar(250)")]      
        public string Teacher_FirstName { get; set; }

        [Column(TypeName = "varchar(250)")]
        public string Teacher_LastName { get; set; }

        [Column(TypeName = "bigint")]
        public long Teacher_PhoneNo { get; set; }

        [Column(TypeName ="varchar(250)")]
        public long Teacher_Email { get; set; }

        [Column(TypeName = "varchar(250)")]
        public string Teacher_AssignClass { get; set; }

        [Column(TypeName = "int")]
        public int Teacher_ClassTeacher { get; set; }

        [Column(TypeName = "varchar(250)")]
        public string Teacher_Education { get; set; }

        [Column(TypeName = "varchar(250)")]
        public string Teacher_Address { get; set; }

        [Column(TypeName = "varchar(250)")]
        public string Teacher_SubjectTeacher { get; set; }

        [Column(TypeName = "varchar(250)")]
        public string Teacher_ImageName { get; set; }

        [Column(TypeName = "varchar(250)")]
        public string Teacher_SignatureName { get; set; }

        [Column(TypeName = "int")]
        public int Teacher_CreateBy { get; set; }

        [Column(TypeName = "DateTime")]
        public DateTime Teacher_CreatedDate { get; set; }



    }
}
