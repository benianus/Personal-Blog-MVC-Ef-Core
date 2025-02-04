using Microsoft.AspNetCore.Mvc;
using PersonalBlog.Data;
using PersonalBlog.Models;

namespace PersonalBlog.Controllers
{
    public class AdminController : Controller
    {
        private readonly AppDbContext _db;
        public AdminController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Dashboard()
        {
            var articles = _db.Articles.ToList();
            ViewData["Articles"] = articles;
            return View();
        }
        public IActionResult Edit(int? id)
        {
            var article = _db.Articles.ToList().Find(article => article.Id == id);

            if (article == null || id == null)
            {
                return View("NotFound");
            }

            ViewData["Article"] = article;

            return View();
        }
        [HttpPost]
        public IActionResult Edit([Bind("Id", "Title", "Content", "PublishDate")]ArticleModel article)
        {
            if (article == null)
            {
                return View("NotFound");
            }

            _db.Articles.Update(article);
            _db.SaveChanges();

            return RedirectToAction("Dashboard");
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add([Bind("Title", "Content", "PublishDate")]ArticleModel article)
        {
            if (article == null)
            {
                return View("NotFound");
            }

            _db.Articles.Add(article);
            _db.SaveChanges();
            return RedirectToAction("Dashboard");
        }
        [HttpPost]
        public IActionResult Delete(int? id)
        {
            var article = _db.Articles.ToList().FirstOrDefault(article => article.Id == id); 
            
            if (article == null || id == null)
            {
                return View("NotFound");
            }

            _db.Articles.Remove(article);
            _db.SaveChanges();
            return RedirectToAction("Dashboard");
        }
    }
}
