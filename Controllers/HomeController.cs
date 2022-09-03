using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewApp.Data;
using NewApp.Models;

namespace NewApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var posts = _context.Posts.ToList();
            return View(posts);
        }

        [HttpGet]
        public IActionResult CreatePost()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePost([Bind("Id,Title,PostBody,DateCreated")] Post post)
        {
            if (ModelState.IsValid)
            {
                _context.Add(post);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }


            return View();
        }

        [HttpGet]
        public async Task<IActionResult> PostDetail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var post = await _context.Posts.FirstOrDefaultAsync(p => p.Id == id);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }
    }
}