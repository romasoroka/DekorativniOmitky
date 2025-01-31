using Microsoft.AspNetCore.Mvc;
using WebSite.Data;
using WebSite.DataAccess.Repository.IRepository;
using WebSite.Models;


namespace WebSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork db) { _unitOfWork = db; }
        public IActionResult Index()
        {
            var categories = _unitOfWork.Category.GetAll().ToList();
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
                _unitOfWork.Category.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Successfully created category";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var category = _unitOfWork.Category.Get(c => c.Id == id);
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
                _unitOfWork.Category.Update(obj);
                _unitOfWork.Save();
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
            var category = _unitOfWork.Category.Get(c => c.Id == id);
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
                Category? category = _unitOfWork.Category.Get(c => c.Id == id);
                if (category == null)
                {
                    return NotFound();
                }

                _unitOfWork.Category.Remove(category);
                _unitOfWork.Save();
                TempData["success"] = "Successfully removed category";
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
