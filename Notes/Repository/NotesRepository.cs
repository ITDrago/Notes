using Microsoft.AspNetCore.Identity;
using Notes.Data;
using Notes.Interfaces;
using Notes.Models;
using System.Security.Claims;

namespace Notes.Repository
{
    public class NotesRepository : INotesRepository
    {
        private readonly ApplicationDbContext _context;

        public NotesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(Note note)
        {
            _context.Notes.Add(note);
            return Save();
        }

        public bool Edit(Note note,string comment)
        {
            note!.Content = comment;
            return Save();
        }

        public IEnumerable<Note> GetAll(ClaimsPrincipal user)
        {
            return _context.Notes.Where(note => note.AppUserId == user.FindFirstValue(ClaimTypes.NameIdentifier));
        }
        public string GetUserId (ClaimsPrincipal user)
        {
            return  user.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public Note GetById(int id)
        {
            return _context.Notes.Find(id)!;
        }

        public bool Remove(Note note)
        {
            _context.Notes.Remove(note);
            return Save();
            
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }
    }
}
