
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Day3.Models;

namespace Day3.Controllers
{
    public class CategoryController : Controller
    {
        private static readonly List<Category_Id_Name_> _categories =
            new List<Category_Id_Name_>
            {
                new Category_Id_Name_ { Id = 1, Name = "Electronics" },
                new Category_Id_Name_ { Id = 2, Name = "Books" },
                new Category_Id_Name_ { Id = 3, Name = "Clothing" }
            };

        // GET: Category
        public IActionResult Index()
        {
            return View(_categories);
        }

        // GET: Category/Details/5
        public IActionResult Details(int id)
        {
            var category = _categories.FirstOrDefault(c => c.Id == id);

            if (category == null)
                return NotFound();

            return View(category);
        }

        // GET: Category/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category_Id_Name_ category)
        {
            if (ModelState.IsValid)
            {
                int newId = _categories.Any()
                    ? _categories.Max(c => c.Id) + 1
                    : 1;

                category.Id = newId;
                _categories.Add(category);

                return RedirectToAction(nameof(Index));
            }

            return View(category);
        }

        // GET: Category/Edit/5
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var category = _categories.FirstOrDefault(c => c.Id == id);

            if (category == null)
                return NotFound();

            return View(category);
        }

        // POST: Category/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Category_Id_Name_ category)
        {
            if (id != category.Id)
                return BadRequest();

            if (ModelState.IsValid)
            {
                var existingCategory =
                    _categories.FirstOrDefault(c => c.Id == id);

                if (existingCategory == null)
                    return NotFound();

                existingCategory.Name = category.Name;

                return RedirectToAction(nameof(Index));
            }

            return View(category);
        }

        // GET: Category/Delete/5
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var category = _categories.FirstOrDefault(c => c.Id == id);

            if (category == null)
                return NotFound();

            return View(category);
        }

        // POST: Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var category = _categories.FirstOrDefault(c => c.Id == id);

            if (category == null)
                return NotFound();

            _categories.Remove(category);

            return RedirectToAction(nameof(Index));
        }
    }
}
