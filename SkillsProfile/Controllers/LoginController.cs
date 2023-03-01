using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using SkillsProfile.Models.Class;

namespace SkillsProfile.Controllers
{
    public class LoginController : Controller
    {
        Contexts contexts = new Contexts();

        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(AdminUser adminUser)
        {
            var user = contexts.AdminUsers.Where(x => x.Name == adminUser.Name && x.Password == adminUser.Password).FirstOrDefault();
            if (user != null)
            {
                AdminUserİnformation.Id = user.Id;
                AdminUserİnformation.Name = user.Name;
                AdminUserİnformation.Password = user.Password;

                FormsAuthentication.SetAuthCookie(user.Name, false);
                return RedirectToAction("Index", "Admin");
            }

            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}