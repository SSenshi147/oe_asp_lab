using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OE_ASP_eLab01.Models
{
    public class TodoMemory
    {
        private TodoContext ctx;
        public TodoMemory(TodoContext ctx)
        {
            this.ctx = ctx;
        }

        public void Add(string todoName)
        {
            this.ctx.Todos.Add(new Todo() { UID = Guid.NewGuid().ToString(), TodoName = todoName, CreationDate=DateTime.Now });
            this.ctx.SaveChanges();
        }

        public List<string> GetAll()
        {
            return this.ctx.Todos.OrderBy(x => x.CreationDate).Select(x => x.TodoName).ToList();
        }
    }
}
