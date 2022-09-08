using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EADS.Demo.Models;

namespace EADS.Demo.Controllers
{
    public class DemoPresentationObjectDatabaseReferencesController : Controller
    {
        private readonly EADSDemoContext _context;

        public DemoPresentationObjectDatabaseReferencesController(EADSDemoContext context)
        {
            _context = context;
        }

        // GET: DemoPresentationObjectDatabaseReferences
        public async Task<IActionResult> Index()
        {
              return _context.DemoPresentationObjectDatabaseReferences != null ? 
                          View(await _context.DemoPresentationObjectDatabaseReferences.ToListAsync()) :
                          Problem("Entity set 'EADSDemoContext.DemoPresentationObjectDatabaseReferences'  is null.");
        }

        // GET: DemoPresentationObjectDatabaseReferences/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.DemoPresentationObjectDatabaseReferences == null)
            {
                return NotFound();
            }

            var demoPresentationObjectDatabaseReference = await _context.DemoPresentationObjectDatabaseReferences
                .FirstOrDefaultAsync(m => m.Id == id);
            if (demoPresentationObjectDatabaseReference == null)
            {
                return NotFound();
            }

            return View(demoPresentationObjectDatabaseReference);
        }

        // GET: DemoPresentationObjectDatabaseReferences/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DemoPresentationObjectDatabaseReferences/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PassPhrase,DataStoreKey,Id")] DemoPresentationObjectDatabaseReference demoPresentationObjectDatabaseReference)
        {
            if (ModelState.IsValid)
            {
                _context.Add(demoPresentationObjectDatabaseReference);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(demoPresentationObjectDatabaseReference);
        }

        // GET: DemoPresentationObjectDatabaseReferences/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.DemoPresentationObjectDatabaseReferences == null)
            {
                return NotFound();
            }

            var demoPresentationObjectDatabaseReference = await _context.DemoPresentationObjectDatabaseReferences.FindAsync(id);
            if (demoPresentationObjectDatabaseReference == null)
            {
                return NotFound();
            }
            return View(demoPresentationObjectDatabaseReference);
        }

        // POST: DemoPresentationObjectDatabaseReferences/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("PassPhrase,DataStoreKey,Id")] DemoPresentationObjectDatabaseReference demoPresentationObjectDatabaseReference)
        {
            if (id != demoPresentationObjectDatabaseReference.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(demoPresentationObjectDatabaseReference);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DemoPresentationObjectDatabaseReferenceExists(demoPresentationObjectDatabaseReference.Id))
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
            return View(demoPresentationObjectDatabaseReference);
        }

        // GET: DemoPresentationObjectDatabaseReferences/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.DemoPresentationObjectDatabaseReferences == null)
            {
                return NotFound();
            }

            var demoPresentationObjectDatabaseReference = await _context.DemoPresentationObjectDatabaseReferences
                .FirstOrDefaultAsync(m => m.Id == id);
            if (demoPresentationObjectDatabaseReference == null)
            {
                return NotFound();
            }

            return View(demoPresentationObjectDatabaseReference);
        }

        // POST: DemoPresentationObjectDatabaseReferences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.DemoPresentationObjectDatabaseReferences == null)
            {
                return Problem("Entity set 'EADSDemoContext.DemoPresentationObjectDatabaseReferences'  is null.");
            }
            var demoPresentationObjectDatabaseReference = await _context.DemoPresentationObjectDatabaseReferences.FindAsync(id);
            if (demoPresentationObjectDatabaseReference != null)
            {
                _context.DemoPresentationObjectDatabaseReferences.Remove(demoPresentationObjectDatabaseReference);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DemoPresentationObjectDatabaseReferenceExists(string id)
        {
          return (_context.DemoPresentationObjectDatabaseReferences?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
