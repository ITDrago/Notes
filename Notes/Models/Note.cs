using System.ComponentModel.DataAnnotations;

namespace Notes.Models
{
	public class Note
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public string Content { get; set; }
		public string? AppUserId { get; set; }
		public AppUser? AppUser { get; set; }
	}
}
