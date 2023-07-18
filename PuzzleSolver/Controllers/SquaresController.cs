using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PuzzleSolver.Data;
using PuzzleSolver.Models;

namespace PuzzleSolver.Controllers
{
    public class SquaresController : Controller
    {
        private readonly PuzzleSolverContext _context;

        public SquaresController(PuzzleSolverContext context)
        {
            _context = context;
        }

        // GET: Squares
        public async Task<IActionResult> Index()
        {
              return _context.Square != null ? 
                          View(await _context.Square.ToListAsync()) :
                          Problem("Entity set 'PuzzleSolverContext.Square'  is null.");
        }

        // GET: Squares/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Square == null)
            {
                return NotFound();
            }

            var square = await _context.Square
                .FirstOrDefaultAsync(m => m.Id == id);
            if (square == null)
            {
                return NotFound();
            }

            return View(square);
        }

        // GET: Squares/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Squares/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,X,Y,Value,Solved")] Square square)
        {
            if (ModelState.IsValid)
            {
                _context.Add(square);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(square);
        }

        // GET: Squares/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Square == null)
            {
                return NotFound();
            }

            var square = await _context.Square.FindAsync(id);
            if (square == null)
            {
                return NotFound();
            }
            return View(square);
        }

        // POST: Squares/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,X,Y,Value,Solved")] Square square)
        {
            if (id != square.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(square);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SquareExists(square.Id))
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
            return View(square);
        }

        // GET: Squares/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Square == null)
            {
                return NotFound();
            }

            var square = await _context.Square
                .FirstOrDefaultAsync(m => m.Id == id);
            if (square == null)
            {
                return NotFound();
            }

            return View(square);
        }

        // POST: Squares/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Square == null)
            {
                return Problem("Entity set 'PuzzleSolverContext.Square'  is null.");
            }
            var square = await _context.Square.FindAsync(id);
            if (square != null)
            {
                _context.Square.Remove(square);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SquareExists(int id)
        {
          return (_context.Square?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
