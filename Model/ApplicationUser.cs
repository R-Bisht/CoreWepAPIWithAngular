using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWepAPI.Model
{
    //Just install Microsoft.EntityFrameworkCore.Tools package from nuget use migration, Microsoft.Extensions.Configuration.Abstractions

    //prop double tab
    //install package 1-Microsoft.EntityFrameworkCore.SqlServer 2-Microsoft.EntityFrameworkCore.Tools 3-Microsoft.EntityFrameworkCore,4-Microsoft.AspNetCore.Identity.EntityFrameworkCore
    public class ApplicationUser : IdentityUser
    {
        [Column(TypeName ="nvarchar(200)")]
        public string FullName { get; set; }

        [Column(TypeName = "int")]
        public int StudentId { get; set; }

        [Column(TypeName ="int")]
        public int UserRoleID { get; set; }
    }
}

