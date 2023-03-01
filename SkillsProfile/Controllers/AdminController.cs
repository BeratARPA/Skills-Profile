using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using SkillsProfile.Controllers;
using SkillsProfile.Models.Class;
using System.Web.UI;

namespace SkillsProfile.Controllers
{
    public class AdminController : Controller
    {
        Contexts contexts = new Contexts();

        // GET: Admin
        [Authorize]
        public ActionResult Index()
        {
            var skills = contexts.Skills.ToList();

            return View(skills);
        }

        [Authorize]
        [HttpGet]
        public ActionResult YeniYetenekEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniYetenekEkle(Skill skill)
        {
            contexts.Skills.Add(skill);
            contexts.Entry(skill).State = EntityState.Added;
            contexts.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult YetenekSil(int id)
        {
            var skill = contexts.Skills.Where(x => x.Id == id).FirstOrDefault();
            contexts.Entry(skill).State = EntityState.Deleted;
            contexts.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult YetenekGetir(int id)
        {
            var skill = contexts.Skills.Where(x => x.Id == id).FirstOrDefault();

            return View("YetenekGetir", skill);
        }

        [HttpPost]
        public ActionResult YetenekGetir(Skill skill)
        {
            var _skill = contexts.Skills.Where(x => x.Id == skill.Id).FirstOrDefault();
            _skill.Description = skill.Description;
            _skill.Value = skill.Value;
            contexts.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}