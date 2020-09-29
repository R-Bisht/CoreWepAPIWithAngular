using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CoreWepAPI.Model
{
    public class State
    {
        [Key]
        public int STD_ID { get; set; }
        [Column(TypeName = "varchar(250)")]
        [Required]
        public string STD_NAME { get; set; }
        [Column(TypeName = "varchar(250)")]
        public string STD_CREATEDBY { get; set; }

        [Column(TypeName = "Datetime")]
        public DateTime STD_CREATEDDATE { get; set; }


        

    }
}
