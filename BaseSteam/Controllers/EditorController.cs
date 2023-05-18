using BaseSteam.Models;
using Microsoft.AspNetCore.Mvc;

namespace BaseSteam.Controllers
{
    public class EditorController : Controller
    {
        private BaseSteamContext db = new();
        public IActionResult Index()
        {
            return View(db.Editors.ToList());

        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Editor editor)
        {

            var existe = db.Editors.Any(c => c.Nombre == editor.Nombre);
            if (existe)
            {
                // Mostrar Sweet Alert con mensaje de error
                TempData["ErrorMessage"] = "Ya existe un editor con el mismo nombre.";
                return RedirectToAction("Create");
            }

            db.Add(editor);
            db.SaveChanges();
            TempData["SuccessMessage"] = "editor creado exitosamente.";

            return RedirectToAction("Create");
        }
        public IActionResult Edit(int? id)
        {
            var editor = db.Editors.Find(id);
            if (id != null)
            {
                return View(editor);
            }
            return RedirectToAction("index");
        }
        [HttpPost]
        public IActionResult Edit(Editor editor)
        {

            var existe = db.Editors.Any(c => c.Nombre == editor.Nombre);
            if (existe)
            {
                // Mostrar Sweet Alert con mensaje de error
                TempData["ErrorMessage"] = "Ya existe un editor con el mismo nombre.";
                return RedirectToAction("Edit");
            }

            db.Update(editor);
            db.SaveChanges();
            TempData["SuccessMessage"] = "editor modificado exitosamente.";

            return RedirectToAction("Edit");
        }
        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                var editor = db.Editors.Find(id);
                if (editor != null)
                {
                    db.Editors.Remove(editor);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("index");
        }
    }
}