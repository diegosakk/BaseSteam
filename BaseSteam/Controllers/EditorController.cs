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
            db.Add(editor);
            db.SaveChanges();
            //return View();
            return RedirectToAction("Index");
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
            db.Update(editor);
            db.SaveChanges();
            return RedirectToAction("index");
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