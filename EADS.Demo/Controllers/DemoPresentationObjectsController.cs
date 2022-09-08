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
    public class DemoPresentationObjectsController : Controller
    {
        private readonly EADSDemoContext _context;

        public DemoPresentationObjectsController(EADSDemoContext context)
        {
            _context = context;
        }

        // GET: DemoPresentationObjects
        public async Task<IActionResult> Index()
        {
              return _context.DemoPresentationObjectDatabaseReferences != null ? 
                          View(await _context.DemoPresentationObjectDatabaseReferences.ToListAsync()) :
                          Problem("Entity set 'EADSDemoContext.DemoPresentationObject'  is null.");
        }

        // GET: DemoPresentationObjects/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.DemoPresentationObject == null)
            {
                return NotFound();
            }

            var demoPresentationObject = await _context.DemoPresentationObject
                .FirstOrDefaultAsync(m => m.Id == id);
            if (demoPresentationObject == null)
            {
                return NotFound();
            }

            return View(demoPresentationObject);
        }

        // GET: DemoPresentationObjects/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DemoPresentationObjects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description,PhoneNumber,FileContent,SSN,Id")] DemoPresentationObject demoPresentationObject)
        {
            if (ModelState.IsValid)
            {
                _context.Add(demoPresentationObject);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(demoPresentationObject);
        }

        // GET: DemoPresentationObjects/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.DemoPresentationObject == null)
            {
                return NotFound();
            }

            var demoPresentationObject = await _context.DemoPresentationObject.FindAsync(id);
            if (demoPresentationObject == null)
            {
                return NotFound();
            }
            return View(demoPresentationObject);
        }

        // POST: DemoPresentationObjects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Name,Description,PhoneNumber,FileContent,SSN,Id")] DemoPresentationObject demoPresentationObject)
        {
            if (id != demoPresentationObject.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(demoPresentationObject);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DemoPresentationObjectExists(demoPresentationObject.Id))
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
            return View(demoPresentationObject);
        }

        // GET: DemoPresentationObjects/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.DemoPresentationObject == null)
            {
                return NotFound();
            }

            var demoPresentationObject = await _context.DemoPresentationObject
                .FirstOrDefaultAsync(m => m.Id == id);
            if (demoPresentationObject == null)
            {
                return NotFound();
            }

            return View(demoPresentationObject);
        }

        // POST: DemoPresentationObjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.DemoPresentationObject == null)
            {
                return Problem("Entity set 'EADSDemoContext.DemoPresentationObject'  is null.");
            }
            var demoPresentationObject = await _context.DemoPresentationObject.FindAsync(id);
            if (demoPresentationObject != null)
            {
                _context.DemoPresentationObject.Remove(demoPresentationObject);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DemoPresentationObjectExists(string id)
        {
          return (_context.DemoPresentationObject?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
