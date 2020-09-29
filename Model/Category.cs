using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace CoreWepAPI.Model
{
    public class Category
    {

        [Key]
        [Required]
        public int CTG { get; set; }

      
        [Column(TypeName = "varchar(250)")]
        public string CTG_NAME { get; set; }

        [Column(TypeName = "int")]
        public int CTG_CREATED_BY { get; set; }


        [Column(TypeName = "datetime")]
        public DateTime CTG_CREATED_DATE { get; set; }
    }
}
