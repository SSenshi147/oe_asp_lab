using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OE_ASP_eLab01.Models;

namespace OE_ASP_eLab01.Controllers
{
    public class HomeController : Controller
    {
        TodoMemory items;

        public HomeController(TodoMemory items)
        {
            this.items = items;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Random(int min = 0, int max = 100)
        {
            Random rnd = new Random();
            int vel = rnd.Next(min, max);

            return View(vel);
        }

        public IActionResult Setup()
        {
            return View();
        }

        public IActionResult NewTodo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddTodo(string todoname)
        {
            items.Add(todoname);
            return RedirectToAction(nameof(ListTodo));
        }

        public IActionResult ListTodo()
        {
            return View(items.GetAll());
        }
    }
}
