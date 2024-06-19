using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Expense_Tracker.Models;

namespace Expense_Tracker.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Category
        public async Task<IActionResult> Index()
        {
            return _context.Categories != null ? View(await _context.Categories.ToListAsync()) : Problem("Entity set 'ApplicationDbContext.Categories' is null.");
            /*return View(await _context.Categories.ToListAsync());*/
        }

        // GET: Category/AddOrEdit
        public IActionResult AddOrEdit(int id = 0) //can add or edit using this one function
        {
            if (id == 0)
            {
                return View(new Category()); //  new Category() is created 
            }
            else
            {
                return View(_context.Categories.Find(id));
            }

        }

        // POST: Category/AddOrEdit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("CategoryId,Title,Icon,Type")] Category category)
        {
            if (ModelState.IsValid)
            {
                if (category.CategoryId == 0)
                    _context.Add(category);
                else
                    _context.Update(category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // POST: Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Categories == null) //check if it is null list or not.
            {
                return Problem("Entity set 'ApplicationDbContext.Categories'  is null.");
            }
            var category = await _context.Categories.FindAsync(id); //if not null retrieve the corresponding records
            if (category != null)
            {
                _context.Categories.Remove(category); //if there is a record the record will be deleted here.
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));   //redirected to index page
        }


    }
}