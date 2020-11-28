using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketSwap.Api.Data;
using TicketSwap.Shared;

namespace TicketSwap.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TicketController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Ticket> Get()
        {
            return _context.Tickets;
        }

        [HttpGet("{id}")]
        public Ticket Get(string id)
        {
            return _context.Tickets.SingleOrDefault(x => x.UID == id);
        }

        [HttpPost]
        public void Post([FromBody] Ticket value)
        {
            _context.Tickets.Add(value);
            _context.SaveChanges();
        }

        [HttpPut("{id}")]
        public void Put(string id, [FromBody] Ticket value)
        {
            Ticket ticket = _context.Tickets.SingleOrDefault(x => x.UID == id);
            _context.Tickets.Remove(ticket);
            _context.Tickets.Add(value);
            _context.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            Ticket ticket = _context.Tickets.SingleOrDefault(x => x.UID == id);
            _context.Tickets.Remove(ticket);
            _context.SaveChanges();
        }
    }
}
