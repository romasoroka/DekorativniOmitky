using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebSiteRazorPages.Data;
using WebSiteRazorPages.Models;

namespace WebSiteRazorPages.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public List<Category> Categories { get; set; }
        public IndexModel(ApplicationDbContext db)
        {
            _context = db;
        }
        public void OnGet()
        {
            Categories = _context.Categories.ToList();
        }
    }
}
