using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Notes.Data;
using Notes.Models;

namespace Notes.Controllers
{
    public class NotesController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ApplicationDbContext _context;
        public NotesController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ApplicationDbContext context)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AllNotes()
        {
            IEnumerable<Note> notes = _context.Notes.ToList();
            return View(notes);
           
        }
        [HttpPost]
        public IActionResult AddNotes(string comment, string name)
        {
            if(comment!= null && name != null)
            {
                var note = new Note() { Name = name, Content = comment};
                _context.Notes.Add(note);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}
