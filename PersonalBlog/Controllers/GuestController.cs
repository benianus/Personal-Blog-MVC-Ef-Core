using Microsoft.AspNetCore.Mvc;
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
            ViewData["Article"] = article;
            return View();
        }
    }
}
