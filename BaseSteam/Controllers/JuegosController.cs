using BaseSteam.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BaseSteam.Controllers
{
    public class JuegosController : Controller
    {
        private BaseSteamContext db = new();
        public IActionResult Index()
        {
            var juegos = db.Juegos.Include(p => p.IdCategoriaNavigation)
                    .Include(p => p.IdDesarrolladorNavigation)
                    .Include(p => p.IdEditorNavigation);
            return View(juegos);

        }
        public IActionResult Create()
        {
            ViewData["IdCategoria"] = new SelectList(db.Categoria, "Id", "Nombre");
            ViewData["IdDesarrollador"] = new SelectList(db.Desarrolladors, "Id", "Nombre");
            ViewData["IdEditor"] = new SelectList(db.Editors, "Id", "Nombre");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Juego juego)
        {
            db.Add(juego);
            db.SaveChanges();
            //return View();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int? id)
        {
            var juego = db.Juegos.Find(id);
            if (id != null)
            {
                return View(juego);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Edit(Juego juego)
        {
            db.Update(juego);
            db.SaveChanges();
            return RedirectToAction("Index");
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
            return RedirectToAction("Index");
        }
    }
}
