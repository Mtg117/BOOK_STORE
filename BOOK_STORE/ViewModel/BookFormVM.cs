﻿using BOOK_STORE.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace BOOK_STORE.ViewModel
{
    public class BookFormVM
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Title { get; set; } = null!;
        [Display(Name ="Author")]
        public int AuthorId { get; set; }
        public List<SelectListItem>?Authors { get; set; }
		public string Publisher { get; set; } = null!;
		[Display(Name = "publish-Date")]
		public DateTime publishDate { get; set; }= DateTime.Now;
        [Display(Name ="Plz choose image.......")]
		public IFormFile? ImageUrl { get; set; }
		public string Description { get; set; } = null!;
        public List<int> SelectedCategories { get; set; }= new List<int>();
        public List<SelectListItem>?Categories { get; set; }


	}
}
