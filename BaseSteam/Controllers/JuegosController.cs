using BaseSteam.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BaseSteam.Controllers
{
    public class JuegosController : Controller
    {
        private BaseSteamContext db = new();
        public IActionResult Index()
        {
            return View(db.Categoria.ToList());

        }
        public IActionResult Create()
        {
            ViewData["IdCategoria"] = new SelectList(db.Categoria, "Id", "Nombre");
            ViewData["IdDesarrollador"] = new SelectList(db.Desarrolladors, "Id", "Nombre");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Juego juego)
        {
            db.Add(juego);
            db.SaveChanges();
            //return View();
            return RedirectToAction("index");
        }
        public IActionResult Edit(int? id)
        {
            var juego = db.Juegos.Find(id);
            if (id != null)
            {
                return View(juego);
            }
            return RedirectToAction("index");
        }
        [HttpPost]
        public IActionResult Edit(Juego juego)
        {
            db.Update(juego);
            db.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                var juego = db.Juegos.Find(id);
                if (juego != null)
                {
                    db.Juegos.Remove(juego);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("index");
        }
    }
}
