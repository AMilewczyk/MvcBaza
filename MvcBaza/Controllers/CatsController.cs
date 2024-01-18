using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcBaza.Data;
using MvcBaza.Models;

namespace MvcBaza.Controllers
{
    public class CatsController : Controller
    {
        private readonly MvcBazaContext _context;

        public CatsController(MvcBazaContext context)
        {
            _context = context;
        }

        // GET: Cats
        // dodane index

        
        public async Task<IActionResult> Index(string searchString)
        {
            if (_context.Cat == null)
            {
                return Problem("Entity set 'MvcBazaContext.Cat'  is null.");
            }

            var cats = from m in _context.Cat
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                cats = cats.Where(s => s.Genre!.Contains(searchString));
            }

            return View(await cats.ToListAsync());
        }

        

        // GET: Movies

        // GET: Movies

        /*
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cat.ToListAsync());
        }
        */

        /*
        public async Task<IActionResult> Index(string movieGenre, string searchString)
        {
            if (_context.Cat == null)
            {
                return Problem("Entity set 'MvcMovieContext.Movie'  is null.");
            }

            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from c in _context.Cat
                                            orderby c.Genre
                                            select c.Genre;
            var cats = from c in _context.Cat
                         select c;

            if (!string.IsNullOrEmpty(searchString))
            {
                cats = cats.Where(s => s.Genre!.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(catGenre))
            {
                cats = cats.Where(x => x.Genre == catGenre);
            }

            var catGenreVM = new CatGenreViewModel
            {
                Genres = new SelectList(await genreQuery.Distinct().ToListAsync()),
                Cats = await cats.ToListAsync()
            };

            return View(catGenreVM);
        }

        */

        // GET: /Cat/Welcome/ 
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cat == null)
            {
                return NotFound();
            }

            var cat = await _context.Cat
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cat == null)
            {
                return NotFound();
            }

            return View(cat);
        }

        // GET: Cats/Create
        public IActionResult Create()
        {
            Console.WriteLine("test Cat");
            return View();
        }

        // POST: Cats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Years,Genre,Behawior")] Cat cat)
        {
            Console.WriteLine("test Cat");
            if (ModelState.IsValid)
            {
                _context.Add(cat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cat);
        }

        // GET: Cats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cat == null)
            {
                return NotFound();
            }

            var cat = await _context.Cat.FindAsync(id);
            if (cat == null)
            {
                return NotFound();
            }
            return View(cat);
        }

        // POST: Cats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Year,Genre,Behawior")] Cat cat)
        {
            if (id != cat.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatExists(cat.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cat);
        }

        // GET: Cats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cat == null)
            {
                return NotFound();
            }

            var cat = await _context.Cat
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cat == null)
            {
                return NotFound();
            }

            return View(cat);
        }

        // POST: Cats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cat == null)
            {
                return Problem("Entity set 'MvcBazaContext.Cat'  is null.");
            }
            var cat = await _context.Cat.FindAsync(id);
            if (cat != null)
            {
                _context.Cat.Remove(cat);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatExists(int id)
        {
          return (_context.Cat?.Any(e => e.Id == id)).GetValueOrDefault();
        }

       

    }
}
