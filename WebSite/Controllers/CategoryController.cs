using Microsoft.AspNetCore.Mvc;
using WebSite.Data;
using WebSite.Models;

namespace WebSite.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db) { _db = db; }
        public IActionResult Index()
        {
            var categories = _db.Categories.ToList(); 
            return View(categories);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            //if(obj.Name == "test")
            //{
            //    ModelState.AddModelError("","testing");
            //}
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Successfully created category";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var category = _db.Categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {

            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Successfully edited category";
                return RedirectToAction("Index");

            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var category = _db.Categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {

            if (ModelState.IsValid)
            {
                if (id == null || id == 0)
                {
                    return NotFound();
                }
                Category? category = _db.Categories.Find(id);
                if (category == null)
                {
                    return NotFound();
                }

                _db.Categories.Remove(category);
                _db.SaveChanges();
                TempData["success"] = "Successfully removed category";
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
