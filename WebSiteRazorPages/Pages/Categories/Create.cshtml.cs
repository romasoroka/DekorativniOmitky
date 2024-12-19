using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebSiteRazorPages.Data;
using WebSiteRazorPages.Models;

namespace WebSiteRazorPages.Pages.Categories
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        [BindProperty]
        public Category category { get; set; }
        public CreateModel(ApplicationDbContext db)
        {
            _context = db;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            TempData["success"] = "Successfully created category";
            return RedirectToPage("Index");
        }

    }
}
