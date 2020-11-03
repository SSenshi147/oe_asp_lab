using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OE_ASP_eLab01.Models
{
    // tábla felépítése
    public class Todo
    {
        [Key]
        public string UID { get; set; }

        [StringLength(100)]
        public string TodoName { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
