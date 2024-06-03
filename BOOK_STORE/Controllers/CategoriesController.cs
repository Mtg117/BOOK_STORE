using BOOK_STORE.Data;
using BOOK_STORE.Models;
using BOOK_STORE.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace BOOK_STORE.Controllers
{
	public class CategoriesController : Controller
	{
		private readonly ApplicationDbContext context;

		public CategoriesController(ApplicationDbContext context)
		{
			this.context = context;
		}
		public IActionResult Index()
		{
            var categoriesVm = context.Categories.ToList().Select(category => new CategoryVm
            {
                Id = category.Id,
                Name = category.Name,
    
            }).ToList();
            return View(categoriesVm);
        }

		[HttpGet]
		public IActionResult Create()
		{

			return View();
		}
		[HttpPost]
		public IActionResult Create(CategoryVm categoryVM)
		{
			if(!ModelState.IsValid)
			{
				return View("Create",categoryVM);
			}
			var category = new Category()
			{
				Name = categoryVM.Name
			};
			try
			{
             context.Categories.Add(category);
			context.SaveChanges();
			return RedirectToAction("Index");
			}
			catch
			{
				ModelState.AddModelError("Name", "category name already exists");
				return View(categoryVM);
			}
			

		}

        [HttpGet]
        public IActionResult Edit(int id)
        {

            var category = context.Categories.Find(id);
            if (category is null)
            {
                return NotFound();
            }
            var viewModel = new CategoryVm
            {
                Id = id,
                Name = category.Name
            };
            return View("Create", viewModel);
        }
        [HttpPost]
        public IActionResult Edit(CategoryVm categoryVM)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", categoryVM);
            }
            var category = context.Categories.Find(categoryVM.Id);
            if (category is null)
            {
                return NotFound();
            }
            category.Name = categoryVM.Name;
            category.UpdatedOn = DateTime.Now;
            context.SaveChanges();
            return RedirectToAction("Index");

        }

        public IActionResult Details(int id)
        {
            var category = context.Categories.Find(id);
            if (category is null)
            {
                return NotFound();
            }
            var viewModel = new CategoryVm
            {
                Id = category.Id,
                Name = category.Name,
                CreatedOn = category.CreatedOn,
                UpdatedOn = category.UpdatedOn
            };
            return View(viewModel);

        }

        public IActionResult Delete(int id)
        {
            var category = context.Categories.Find(id);
            if (category is null)
            {
                return NotFound();
            }
            context.Categories.Remove(category);
            context.SaveChanges();
            return Ok();
        }
    }
}
