using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CoreWepAPI.Model
{
    public class StudentClass
    {
        [Key]
        [Required]
        public int STC { get; set; }


        [Column(TypeName = "varchar(250)")]
        [Required]
        public string STC_NAME { get; set; }

        [Column(TypeName = "int")]
        public int STC_CREATED_BY { get; set; }


        [Column(TypeName = "datetime")]
        public DateTime STC_CREATED_DATE { get; set; }
    }
}
