using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RishabhWeeb.Data;
using RishabhWeeb.Models;
using System.Security.Cryptography.X509Certificates;

namespace RishabhWeeb.Controllers
{

    public class CategoriesController : Controller
    {

        private readonly ApplicationDbContext _context;

        public IEnumerable<Category> Category { get; set; }

        public CategoriesController(ApplicationDbContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
            var data = _context.category.ToList();
            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            Category category = new Category();
            return View(category);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError(string.Empty, "The Display Order Cannot Exactly match the Name");
            }
            if (ModelState.IsValid)
            {
                await _context.category.AddAsync(category);
                await _context.SaveChangesAsync();
                TempData[SD.Success] = " Category Created Successfully ";

                // Handle successful registration (e.g., redirect to login page)
                return RedirectToAction("Index", "Categories");

            }
            else
            {
                TempData[SD.Error] = "Field needs filling";
            }

            // If registration fails, return to the registration view with error messages

            return View(category);

        }
        public IActionResult Edit(int id)
        {
            var Category = _context.category.Find(id);
            return View(Category);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Category category)
        {
            if (ModelState.IsValid)
            {
                var Category = _context.category.Find(id);
                if (Category == null)
                {
                    TempData[SD.Error] = "Field needs filling";

                }
                Category.Name = category.Name;
                Category.DisplayOrder = category.DisplayOrder;
                _context.SaveChangesAsync();
                TempData[SD.Success] = "Category Updated Successfully";
                return RedirectToAction("Index", "Categories");

            }
            else
            {
                TempData[SD.Error] = "Field needs filling";
            }

            return View(category);
        }
       
        [HttpPost]
        public  IActionResult Delete(int id ,Category category)
        {            
                var DbData = _context.category.Find(id);
                _context.category.Remove(DbData);
                _context.SaveChanges();
                TempData[SD.Success] = "Category Deleted Successfully";
                return RedirectToAction("Index");              
            
        }
        
    }
}
