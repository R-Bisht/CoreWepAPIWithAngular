using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWepAPI.Model
{
    public class AddSubject
    {
       [Key]
        public int Subject_ID { get; set; }

        [Column(TypeName="varchar(250)")]
        public string Subject_Name { get; set; }

        [Column(TypeName = "varchar(250)")]
        public string Subject_Level { get; set; }

        [Column(TypeName = "int")]
        public int Subject_CreateBy { get; set; }

        [Column(TypeName = "DateTime")]
        public DateTime Subject_CreateDate { get; set; }


    }
}
