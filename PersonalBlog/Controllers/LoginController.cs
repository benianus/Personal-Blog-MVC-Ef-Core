using Microsoft.AspNetCore.Mvc;
using PersonalBlog.Data;
using PersonalBlog.Models;

namespace PersonalBlog.Controllers
{
    public class LoginController : Controller
    {
        private readonly AppDbContext _db;
        public LoginController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Auth(string? username, string? password)
        {
            var author = _db.Authors.ToList().FirstOrDefault(author => author.Username == username && author.Password == password);

            if (author == null)
            {
                ViewData["Message"] = "Wrong password or username, try again";
                return View("NotFound");
            }

            return RedirectToAction("Dashboard","Admin");
        }
    }
}
