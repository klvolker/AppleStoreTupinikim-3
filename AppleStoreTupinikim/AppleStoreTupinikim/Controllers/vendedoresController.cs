using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppleStoreTupinikim.Models;

namespace AppleStoreTupinikim.Controllers
{
    public class vendedoresController : Controller
    {
        private readonly Contexto _context;

        public vendedoresController(Contexto context)
        {
            _context = context;
        }

        // GET: vendedores
        public async Task<IActionResult> Index()
        {
              return _context.vendedores != null ? 
                          View(await _context.vendedores.ToListAsync()) :
                          Problem("Entity set 'Contexto.vendedores'  is null.");
        }

        // GET: vendedores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.vendedores == null)
            {
                return NotFound();
            }

            var vendedores = await _context.vendedores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vendedores == null)
            {
                return NotFound();
            }

            return View(vendedores);
        }

        // GET: vendedores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: vendedores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RazaoSocial,CNPJ,Email,Site,Telefone")] vendedores vendedores)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vendedores);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vendedores);
        }

        // GET: vendedores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.vendedores == null)
            {
                return NotFound();
            }

            var vendedores = await _context.vendedores.FindAsync(id);
            if (vendedores == null)
            {
                return NotFound();
            }
            return View(vendedores);
        }

        // POST: vendedores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RazaoSocial,CNPJ,Email,Site,Telefone")] vendedores vendedores)
        {
            if (id != vendedores.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vendedores);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!vendedoresExists(vendedores.Id))
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
            return View(vendedores);
        }

        // GET: vendedores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.vendedores == null)
            {
                return NotFound();
            }

            var vendedores = await _context.vendedores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vendedores == null)
            {
                return NotFound();
            }

            return View(vendedores);
        }

        // POST: vendedores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.vendedores == null)
            {
                return Problem("Entity set 'Contexto.vendedores'  is null.");
            }
            var vendedores = await _context.vendedores.FindAsync(id);
            if (vendedores != null)
            {
                _context.vendedores.Remove(vendedores);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool vendedoresExists(int id)
        {
          return (_context.vendedores?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
