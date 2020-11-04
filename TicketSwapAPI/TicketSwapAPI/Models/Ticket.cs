using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TicketSwapAPI.Models
{
    public class Ticket
    {
        [Key]
        public string UID { get; set; }

        [StringLength(100)]
        public string EventName { get; set; }

        public DateTime EventDate { get; set; }

        public int EventPrice { get; set; }
    }
}
