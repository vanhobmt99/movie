using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebApplication1.Models;

namespace FutureValueModel.Controllers
{
    public class HomeController : Controller
    {
      private MovieContext context { get; set; }
        public HomeController (MovieContext ctx)
        {
            context = ctx;
        }
        public ActionResult Index ()
        {
            var movies = context.Movies.Include(m=> m.Genre) .OrderBy(m => m.Name).ToList();
            return View(movies);
        }
        public ActionResult Privacy()
        {
            
            return View();
        }

        [HttpGet]
        public ActionResult Add ()
        {
            ViewBag.Action = "Add";
            ViewBag.Genres = context.Genres.OrderBy(g=>g.Name).ToList();
            return View("Edit",new Movie());
        }
        [HttpGet]
        public ActionResult Edit (int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Genres = context.Genres.OrderBy(g =>g.Name ).ToList();
            var movie = context.Movies.Find((id));
            return View(movie);
        }
        [HttpPost]
        public ActionResult Edit (Movie movie)
        {
            if(ModelState.IsValid)
            {
                if (movie.MovieID == 0)
                {
                    context.Add(movie);
                }
                else
                    context.Update(movie);
                context.SaveChanges();
                return RedirectToAction("Index", "Home");

            }
            else
            {
                ViewBag.Action = (movie.MovieID==0) ? "Add" : "Edit";
                return View(movie);
            }
        }
        [HttpGet]
        public ActionResult Delete (int id)
        {
            var movie = context.Movies.Find(id);
            return View(movie);
        }
        [HttpPost]
        public ActionResult Delete (Movie movie)
        {
            context.Movies.Remove(movie);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Details(int id)
        {
            var movie = context.Movies.Find(id);
            return View(movie);
        }



    }
}
