using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebSiteRazorPages.Data;
using WebSiteRazorPages.Models;

namespace WebSiteRazorPages.Pages.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        [BindProperty]
        public Category category { get; set; }
        public DeleteModel(ApplicationDbContext db)
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

            _context.Categories.Remove(category);
            _context.SaveChanges();
            TempData["success"] = "Successfully deleted category";
            return RedirectToPage("Index");
        }
    }
}
