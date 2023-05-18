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
          
            var existe = db.Categoria.Any(c => c.Nombre == categoria.Nombre);
            if (existe)
            {
                // Mostrar Sweet Alert con mensaje de error
                TempData["ErrorMessage"] = "Ya existe una categoria con el mismo nombre.";
                return RedirectToAction("Create");
            }

            db.Add(categoria);
            db.SaveChanges();
            TempData["SuccessMessage"] = "Categoria creado exitosamente.";

            return RedirectToAction("Create");
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
            var existe = db.Categoria.Any(c => c.Nombre == categoria.Nombre);
            if (existe)
            {
                // Mostrar Sweet Alert con mensaje de error
                TempData["ErrorMessage"] = "Ya existe una categoria con el mismo nombre.";
                return RedirectToAction("Edit");
            }
            else
            {
                db.Update(categoria);
                db.SaveChanges();
                TempData["SuccessMessage"] = "Categoria modficiada exitosamente.";
            }
            
            return RedirectToAction("Edit");
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
