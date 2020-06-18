using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MicrowaveWebMVC.Models;

namespace MicrowaveWebMVC.Controllers
{
    public class ProgramTypesController : Controller
    {
        private readonly MicrowaveWebMVCContext _context;

        public ProgramTypesController(MicrowaveWebMVCContext context)
        {
            _context = context;
        }

        // GET: ProgramTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProgramType.ToListAsync());
        }

        // GET: ProgramTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var programType = await _context.ProgramType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (programType == null)
            {
                return NotFound();
            }

            return View(programType);
        }

        // GET: ProgramTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProgramTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Duration,Potency")] ProgramType programType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(programType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(programType);
        }

        // GET: ProgramTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var programType = await _context.ProgramType.FindAsync(id);
            if (programType == null)
            {
                return NotFound();
            }
            return View(programType);
        }

        // POST: ProgramTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Duration,Potency")] ProgramType programType)
        {
            if (id != programType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(programType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProgramTypeExists(programType.Id))
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
            return View(programType);
        }

        // GET: ProgramTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var programType = await _context.ProgramType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (programType == null)
            {
                return NotFound();
            }

            return View(programType);
        }

        // POST: ProgramTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var programType = await _context.ProgramType.FindAsync(id);
            _context.ProgramType.Remove(programType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProgramTypeExists(int id)
        {
            return _context.ProgramType.Any(e => e.Id == id);
        }
    }
}
