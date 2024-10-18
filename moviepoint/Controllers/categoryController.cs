using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using moviepoint.data;

namespace moviepoint.Controllers
{
    public class categoryController : Controller
    {
        ApplicationDbContext context =new ApplicationDbContext();
        public IActionResult Index()
        {
            var name = context.categories.ToList();
            return View(model: name);
        }
        public IActionResult MoviesByCategory(int categoryId)
        {
            var movies = context.movies
                .Include(c=>c.Cinema)
                .Include(m => m.Category) 
                .Where(m => m.CategoryId == categoryId)
                .ToList();

            return View(movies); 
        }
    }
}
