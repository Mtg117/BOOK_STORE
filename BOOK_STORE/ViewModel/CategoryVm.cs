using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BOOK_STORE.ViewModel
{
	public class CategoryVm
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Plz emp")]
		[MaxLength(30)]
		[Remote("cheakName", null, ErrorMessage = "existsssssssssssss")]
		public string Name { get; set; }

		public DateTime CreatedOn { get; set; } = DateTime.Now;
		public DateTime UpdatedOn { get; set; } = DateTime.Now;
	}
}
