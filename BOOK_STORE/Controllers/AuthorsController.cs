using BOOK_STORE.Data;
using BOOK_STORE.Models;
using BOOK_STORE.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BOOK_STORE.Controllers
{
	public class AuthorsController : Controller
	{
		private readonly ApplicationDbContext context;

		public AuthorsController(ApplicationDbContext context)
		{
			this.context = context;
		}
		public IActionResult Index()
		{
            var authorsVM = context.Authors.ToList().Select(author => new AuthorVM
            {
                 Id = author.Id,
                 Name = author.Name,
                 CreatedOn = author.CreatedOn,
                 UpdatedOn = author.UpdatedOn,
             }).ToList();
            return View(authorsVM);
        }
		[HttpGet]
		public IActionResult Create()
		{
			return View("Form");
		}
		[HttpPost]
		public IActionResult Create(AuthorFormVM authorFormVM)
		{
			if (!ModelState.IsValid)
			{
				return View("Create", authorFormVM);
			}
			var authors = new Author()
			{
				Name = authorFormVM.Name,
			};
			try
			{
				context.Authors.Add(authors);
				context.SaveChanges();
				return RedirectToAction("Index");
			}
			catch
			{
				ModelState.AddModelError("Name", "Author name already exists");
				return View(authorFormVM);
			}


		}

        [HttpGet]
        public IActionResult Edit(int id)
        {

            var author = context.Authors.Find(id);
            if (author is null)
            {
                return NotFound();
            }
            var viewModel = new AuthorFormVM
            {
                Id = id,
                Name = author.Name
            };
            return View("Form", viewModel);
        }
        [HttpPost]
        public IActionResult Edit(AuthorFormVM authorFormVM)
        {
            if (!ModelState.IsValid)
            {
                return View("Form", authorFormVM);
            }
            var author = context.Authors.Find(authorFormVM.Id);
            if (author is null)
            {
                return NotFound();
            }
            author.Name = authorFormVM.Name;
            author.UpdatedOn = DateTime.Now;
            context.SaveChanges();
            return RedirectToAction("Index");

        }

        public IActionResult Details(int id)
        {
            var author = context.Authors.Find(id);
            if (author is null)
            {
                return NotFound();
            }
            var viewModel = new AuthorVM
            {
                Id = author.Id,
                Name = author.Name,
                CreatedOn = author.CreatedOn,
                UpdatedOn = author.UpdatedOn
            };
            return View(viewModel);

        }

        public IActionResult Delete(int id)
		{
			var author = context.Authors.Find(id);
			if (author is null)
			{
				return NotFound();
			}
			context.Authors.Remove(author);
			context.SaveChanges();
			return Ok();
		}
	}
}
