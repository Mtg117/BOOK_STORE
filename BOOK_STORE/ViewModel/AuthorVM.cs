﻿namespace BOOK_STORE.ViewModel
{
	public class AuthorVM
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public DateTime CreatedOn { get; set; } = DateTime.Now;
		public DateTime UpdatedOn { get; set; } = DateTime.Now;
	}
}
