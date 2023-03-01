using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using SkillsProfile.Models.Class;

namespace SkillsProfile.Controllers
{
    public class DefaultController : Controller
    {
        Contexts contexts = new Contexts();

        // GET: Default
        public ActionResult Index()
        {
            var skills = contexts.Skills.ToList();

            return View(skills);
        }
    }
}