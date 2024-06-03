using System.ComponentModel.DataAnnotations;

namespace BOOK_STORE.ViewModel
{
	public class AuthorFormVM
	{
		public int Id { get; set; }
		[MaxLength(50,ErrorMessage ="The name field can't exceed 50 characters")]
		public string Name { get; set; }
	}
}
