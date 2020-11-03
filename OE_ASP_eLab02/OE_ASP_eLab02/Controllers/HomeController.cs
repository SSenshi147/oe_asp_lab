using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OE_ASP_eLab02.Data;
using OE_ASP_eLab02.Models;

namespace OE_ASP_eLab02.Controllers
{
    public class HomeController : Controller
    {
        private UserManager<IdentityUser> userManager;
        private RoleManager<IdentityRole> roleManager;
        private ApplicationDbContext context;
        
        public HomeController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.context = context;
        }

        // segéd method: első user lesz az admin
        public async Task<IActionResult> Init()
        {
            var first = userManager.Users.First();
            IdentityRole adminRole = new IdentityRole()
            {
                Name = "admin"
            };
            if (await roleManager.FindByNameAsync("admin") == null)
            {
                await roleManager.CreateAsync(adminRole);
                await userManager.AddToRoleAsync(first, "admin");
            }

            return RedirectToAction(nameof(Index));
        }
        
        public IActionResult Index()
        {
            return View();
        }

        
        [HttpGet]
        [Authorize]
        public IActionResult AddTeacher()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddTeacher(Teacher newTeacher)
        {
            newTeacher.UID = Guid.NewGuid().ToString();
            
            var myself = this.User; // ki küldte el ezt a requestet
            var userObj = this.userManager.GetUserAsync(myself).Result;
            newTeacher.Creator = userObj;
            
            this.context.Teachers.Add(newTeacher);
            this.context.SaveChanges();
            
            return RedirectToAction(nameof(ListTeachers));
        }

        public IActionResult ListTeachers()
        {
            return View(this.context.Teachers.OrderBy(x => x.FirstName).AsEnumerable());
        }

        [Authorize(Roles = "admin")]
        public IActionResult DeleteTeacher(string uid)
        {
            var teacherToDelete = this.context.Teachers.FirstOrDefault(x => x.UID == uid);
            this.context.Teachers.Remove(teacherToDelete);
            this.context.SaveChanges();

            return RedirectToAction(nameof(Admin));
        }

        [Authorize(Roles = "admin")]
        public IActionResult Admin()
        {
            return View(this.context.Teachers.OrderBy(x => x.FirstName).AsEnumerable());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
