using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Notes.Data;
using Notes.Models;
using System.Linq;
using System.Security.Claims;

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
            IEnumerable<Note> notes = _context.Notes.Where(note => note.AppUserId == User.FindFirstValue(ClaimTypes.NameIdentifier));
            return View(notes);
           
        }
        [HttpPost]
        public IActionResult AddNotes(string comment, string name)
        {
            if(comment!= null && name != null)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var note = new Note() { Name = name, Content = comment, DataCreated = DateTime.Now, AppUserId = userId};
                
                _context.Notes.Add(note);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var note = _context.Notes.Find(id);
            if (note != null)
            {
                _context.Notes.Remove(note);
                _context.SaveChanges();
            }
            return RedirectToAction("AllNotes");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var note = _context.Notes.Find(id);
            return View(note);
        }
        [HttpPost]
        public IActionResult Edit(Note model, string comment)
        {
            var note = _context.Notes.Find(model.Id);
            note!.Content = comment;
            _context.SaveChanges();
            return RedirectToAction("Edit"); ;
        }


    }
}
