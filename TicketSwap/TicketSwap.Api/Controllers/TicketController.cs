using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TicketSwap.Api.Data;
using TicketSwap.Shared;

namespace TicketSwap.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TicketController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public TicketController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
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
        public async Task<IActionResult> Post([FromBody] Ticket value)
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var myself = await _userManager.GetUserAsync(this.User);

            value.UID = Guid.NewGuid().ToString();
            value.Seller = myself;
            _context.Tickets.Add(value);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]
        public void Put(string id, [FromBody] Ticket value)
        {
            Ticket ticket = _context.Tickets.SingleOrDefault(x => x.UID == id);
            value.UID = ticket.UID;
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
