using BOOK_STORE.Models;
using System.ComponentModel.DataAnnotations;

namespace BOOK_STORE.ViewModel
{
	public class BookVM
	{
		public int Id { get; set; }
		
		public string Title { get; set; } = null!;
		public string Author { get; set; }
		public string Publisher { get; set; } = null!;
		public DateTime publishDate { get; set; }
		public string ImageUrl { get; set; }
		public string Description { get; set; } = null!;
		public List<string> Catrgories {  get; set; }
		
	}
}	
