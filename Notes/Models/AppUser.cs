using Microsoft.AspNetCore.Identity;

namespace Notes.Models
{
	public class AppUser : IdentityUser
	{
		public ICollection<Note> Notes { get; set; }
	}
}
