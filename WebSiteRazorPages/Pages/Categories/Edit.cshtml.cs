using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebSiteRazorPages.Data;
using WebSiteRazorPages.Models;

namespace WebSiteRazorPages.Pages.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        [BindProperty]
        public Category category { get; set; }
        public EditModel(ApplicationDbContext db)
        {
            _context = db;
        }
        public void OnGet(int? id)
        {
            if (id != null && id != 0)
            {
                category = _context.Categories.Find(id);
            }
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Update(category);
                _context.SaveChanges();
                TempData["success"] = "Successfully edited category";
                return RedirectToPage("Index");

            }
            return Page();
        }
    }
}
