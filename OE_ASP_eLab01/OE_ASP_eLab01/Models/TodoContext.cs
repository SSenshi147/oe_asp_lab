using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OE_ASP_eLab01.Models
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> opt) : base(opt)
        {

        }

        // milyen táblák lesznek
        public DbSet<Todo> Todos { get; set; }
    }
}
