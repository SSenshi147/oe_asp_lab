using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace TicketSwap.Shared
{
    public class Ticket
    {
        [Key]
        public string UID { get; set; }

        [StringLength(100)]
        public string EventName { get; set; }

        public DateTime EventDate { get; set; }

        public int EventPrice { get; set; }

        [StringLength(100)]
        public string ContentType { get; set; }

        public byte[] PictureData { get; set; }

        public IdentityUser Seller { get; set; }
    }
}
