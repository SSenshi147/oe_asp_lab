using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OE_ASP_eLab02.Models
{
    public class Teacher
    {
        [Key]
        [Display(Name = "Azonosító")]
        public string UID { get; set; }

        [StringLength(100)]
        [Display(Name = "Keresztnév")]
        public string FirstName { get; set; }

        [StringLength(100)]
        [Display(Name = "Vezetéknév")]
        public string LastName { get; set; }

        public virtual IdentityUser Creator { get; set; }
    }
}
