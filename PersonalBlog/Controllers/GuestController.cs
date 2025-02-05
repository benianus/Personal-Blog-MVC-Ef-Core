using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PersonalBlog.Data;

namespace PersonalBlog.Controllers
{
    public class GuestController : Controller
    {
        private readonly AppDbContext _db;
        public GuestController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Home()
        {
            var article = _db.Articles.ToList();
            ViewData["Articles"] = article;
            return View();
        }
        public IActionResult Article(int? id)
        {
            var article = _db.Articles.ToList().FirstOrDefault(article => article.Id == id);
            if (article == null || id == null)
            {
                return View("NotFound");
            }
            ViewData["Article"] = article;
            return View();
        }
    }
}
