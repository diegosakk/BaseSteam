using BaseSteam.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace BaseSteam.Controllers
{
    public class DesarrolladorController : Controller
    {
        private BaseSteamContext db = new();
        public IActionResult Index()
        {
            return View(db.Desarrolladors.ToList());

        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Desarrollador desarrollador)
        {
            db.Add(desarrollador);
            db.SaveChanges();
            //return View();
            return RedirectToAction("index");
        }
        public IActionResult Edit(int? id)
        {
            var desarrollador = db.Desarrolladors.Find(id);
            if (id != null)
            {
                return View(desarrollador);
            }
            return RedirectToAction("index");
        }
        [HttpPost]
        public IActionResult Edit(Desarrollador desarrollador)
        {
            db.Update(desarrollador);
            db.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                var desarrollador = db.Desarrolladors.Find(id);
                if (desarrollador != null)
                {
                    db.Desarrolladors.Remove(desarrollador);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("index");
        }
    }
}
