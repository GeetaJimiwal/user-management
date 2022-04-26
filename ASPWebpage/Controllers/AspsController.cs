#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASPWebpage.Data;
using ASPWebpage.Models;

namespace ASPWebpage.Controllers
{
    public class AspsController : Controller
    {
        private readonly ASPWebpageApplicationDbContext _context;

        public AspsController(ASPWebpageApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Asps
        public async Task<IActionResult> Index()
        {
            return View(await _context.Asp.ToListAsync());
        }


        // GET: Asps searchform
        public async Task<IActionResult> ShowearchForm()
        {
            return View("ShowearchForm");
        }

        // Post: Asps searchResult
        public async Task<IActionResult> ShowSearchResult(string SearchPhrase)
        {
            return View("Index", await _context.Asp.ToListAsync());
        }
        // GET: Asps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asp = await _context.Asp
                .FirstOrDefaultAsync(m => m.Id == id);
            if (asp == null)
            {
                return NotFound();
            }

            return View(asp);
        }

        // GET: Asps/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Asps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Jockquestion,Jockanswer")] Asp asp)
        {
            if (ModelState.IsValid)
            {
                _context.Add(asp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(asp);
        }

        // GET: Asps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asp = await _context.Asp.FindAsync(id);
            if (asp == null)
            {
                return NotFound();
            }
            return View(asp);
        }

        // POST: Asps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Jockquestion,Jockanswer")] Asp asp)
        {
            if (id != asp.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(asp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AspExists(asp.Id))
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
            return View(asp);
        }

        // GET: Asps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asp = await _context.Asp
                .FirstOrDefaultAsync(m => m.Id == id);
            if (asp == null)
            {
                return NotFound();
            }

            return View(asp);
        }

        // POST: Asps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var asp = await _context.Asp.FindAsync(id);
            _context.Asp.Remove(asp);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AspExists(int id)
        {
            return _context.Asp.Any(e => e.Id == id);
        }
    }
}
