using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Notes.Data;
using Notes.Interfaces;
using Notes.Models;
using System.Linq;
using System.Security.Claims;

namespace Notes.Controllers
{
    public class NotesController : Controller
    {
        private readonly INotesRepository _notesRepository;
        public NotesController(INotesRepository notesRepository)
        {
            _notesRepository = notesRepository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        public IActionResult AllNotes()
        {
            IEnumerable<Note> notes = _notesRepository.GetAll(User);
            return View(notes);
           
        }
        [HttpPost]
        public IActionResult AddNotes(string comment, string name)
        {
            if(comment!= null && name != null)
            {
                var userId = _notesRepository.GetUserId(User);
                var note = new Note() { Name = name, Content = comment, DataCreated = DateTime.Now, AppUserId = userId};
                _notesRepository.Add(note);
            }
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var note = _notesRepository.GetById(id);
            if (note != null)
            {
                _notesRepository.Remove(note);
            }
            return RedirectToAction("AllNotes");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var note = _notesRepository.GetById(id);
            return View(note);
        }
        [HttpPost]
        public IActionResult Edit(Note model, string comment)
        {
            var note = _notesRepository.GetById(model.Id);
            _notesRepository.Edit(note, comment);
            return RedirectToAction("Edit"); ;
        }
    }
}
