using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using moviepoint.data;
using moviepoint.Models;
using System.Diagnostics;

namespace moviepoint.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext context=new ApplicationDbContext();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var name = context.movies.Include(e => e.Cinema).Include(e=>e.Category).ToList();
            return View(model:name);
        }
        public IActionResult viewmore(int movieId)
        {
            var more = context.movies
            .Include(m => m.Cinema)
            .Include(m => m.Category)
            .Include(m => m.Actors)
            .FirstOrDefault(m => m.Id == movieId);

            return View(model: more);
        }
        public IActionResult ActorDetails(int actorId)
        {
            var actor = context.actors.Find(actorId);
            return View(actor);
        }
        public IActionResult Search(string query)
        {
            var movies = context.movies
                .Where(m => m.Name.Contains(query) || m.Description.Contains(query)) 
                .ToList();

            return View( movies); 
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
