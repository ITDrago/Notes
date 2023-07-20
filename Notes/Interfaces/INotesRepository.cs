using Notes.Models;
using System.Security.Claims;

namespace Notes.Interfaces
{
    public interface INotesRepository
    {
        IEnumerable<Note> GetAll(ClaimsPrincipal user);
        bool Add(Note note);
        bool Remove(Note note);
        Note GetById(int id);
        string GetUserId(ClaimsPrincipal user);
        bool Edit(Note note, string comment);
        bool Save();
    }
}
