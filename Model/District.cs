using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CoreWepAPI.Model
{
    public class District
    {
        [Key]
        public int DST_Id { get; set; }

        [Column(TypeName = "varchar(250)")]
        [Required]
        public string DST_DISTICT { get; set; }

        [Column(TypeName = "int")]
       
        public int DST_STATEID { get; set; }

        [Column(TypeName = "varchar(250)")]
        public string DST_CREATEDBY { get; set; }

        [Column(TypeName = "Datetime")]
        public DateTime DST_CREATEDDATE { get; set; }

      
    }
}
