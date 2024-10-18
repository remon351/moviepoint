using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using moviepoint.data;
using moviepoint.Models;

namespace moviepoint.Controllers
{
    public class CinemaController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        public IActionResult Index()
        {
            var name = context.cinemas.ToList();
            return View(model: name);
        }
        public IActionResult MoviesByCinema(int cinemaId)
        {
            var movies = context.movies.Include(x => x.Cinema).Include(y => y.Category).Where(e=> e.CinemaId== cinemaId).ToList();
            return View(movies);
        }
    }
}
