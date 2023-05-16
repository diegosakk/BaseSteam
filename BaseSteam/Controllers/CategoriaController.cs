using BaseSteam.Models;
using Microsoft.AspNetCore.Mvc;

namespace BaseSteam.Controllers
{
    public class CategoriaController : Controller
    {
        private BaseSteamContext db = new();
        public IActionResult Index()
        {
            return View(db.Categoria.ToList());

        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Categorium categoria)
        {
            db.Add(categoria);
            db.SaveChanges();
            //return View();
            return RedirectToAction("index");
        }
        public IActionResult Edit(int? id)
        {
            var categoria = db.Categoria.Find(id);
            if (id != null)
            {
                return View(categoria);
            }
            return RedirectToAction("index");
        }
        [HttpPost]
        public IActionResult Edit(Categorium categoria)
        {
            db.Update(categoria);
            db.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                var categoria = db.Categoria.Find(id);
                if (categoria != null)
                {
                    db.Categoria.Remove(categoria);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("index");
        }
    }
}
