using Microsoft.EntityFrameworkCore;

namespace BOOK_STORE.Models
{
	[Index(nameof(Name), IsUnique = true)]
	public class Author
	{

		public int Id { get; set; }
		public string Name { get; set; }

		public DateTime CreatedOn { get; set; } = DateTime.Now;
		public DateTime UpdatedOn { get; set; } = DateTime.Now;
	}
}
