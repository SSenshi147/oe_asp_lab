using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TicketSwapAPI.Data;
using TicketSwapAPI.Models;

namespace TicketSwapAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public TicketController(ApplicationDbContext context)
        {
            this.context = context;
        }
        
        [HttpGet]
        public IEnumerable<Ticket> Get()
        {
            return this.context.Tickets;
        }

        [HttpGet("{id}")]
        public Ticket Get(string id)
        {
            return this.context.Tickets.FirstOrDefault(t => t.UID == id);
        }

        [HttpPost]
        public void Post([FromBody] Ticket value)
        {
            value.UID = Guid.NewGuid().ToString();
            this.context.Tickets.Add(value);
            this.context.SaveChanges();
        }

        [HttpPut("{id}")]
        public void Put(string id, [FromBody] Ticket value)
        {
            var old = this.context.Tickets.FirstOrDefault(t => t.UID == id);
            this.context.Tickets.Remove(old);
            this.context.Add(value);
            this.context.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            var old = this.context.Tickets.FirstOrDefault(t => t.UID == id);
            this.context.Tickets.Remove(old);
            this.context.SaveChanges();
        }
    }
}
