using BaseSteam.Models;
using Microsoft.AspNetCore.Mvc;

namespace BaseSteam.Controllers
{
    public class UsuarioController : Controller
    {
        private BaseSteamContext db = new();
        public IActionResult Index()
        {
            return View(db.Roles.ToList());

        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Role role)
        {
            db.Add(role);
            db.SaveChanges();
            //return View();
            return RedirectToAction("index");
        }
        public IActionResult Edit(int? id)
        {
            var role = db.Roles.Find(id);
            if (id != null)
            {
                return View(role);
            }
            return RedirectToAction("index");
        }
        [HttpPost]
        public IActionResult Edit(Role role)
        {
            db.Update(role);
            db.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                var role = db.Roles.Find(id);
                if (role != null)
                {
                    db.Roles.Remove(role);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("index");
        }
    }
}