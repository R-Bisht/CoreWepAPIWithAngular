using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWepAPI.Model
{
    public class ApplicationRole
    {
        [Key]
        public int AR_Id { get; set; }

        [Column(TypeName ="varchar(250)")]
        public string  AR_ApplicationDiscriminator { get; set; }

        [Column(TypeName = "int")]
        public int AR_CreateBy { get; set; }

        [Column(TypeName = "DateTime")]
        public DateTime AR_CreatedDate { get; set; }




    }
}
