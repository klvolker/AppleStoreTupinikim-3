﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppleStoreTupinikim.Models;

namespace AppleStoreTupinikim.Controllers
{
    public class VendedoresController : Controller
    {
        private readonly Contexto _context;

        public VendedoresController(Contexto context)
        {
            _context = context;
        }

        // GET: Vendedores
        public async Task<IActionResult> Index()
        {
              return _context.Vendedores != null ? 
                          View(await _context.Vendedores.ToListAsync()) :
                          Problem("Entity set 'Contexto.Vendedores'  is null.");
        }

        // GET: Vendedores/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Vendedores == null)
            {
                return NotFound();
            }

            var vendedores = await _context.Vendedores
                .FirstOrDefaultAsync(m => m.cnpj == id);
            if (vendedores == null)
            {
                return NotFound();
            }

            return View(vendedores);
        }

        // GET: Vendedores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vendedores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("razaoSocial,cnpj,email,site,telefone")] Vendedores vendedores)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vendedores);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vendedores);
        }

        // GET: Vendedores/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Vendedores == null)
            {
                return NotFound();
            }

            var vendedores = await _context.Vendedores.FindAsync(id);
            if (vendedores == null)
            {
                return NotFound();
            }
            return View(vendedores);
        }

        // POST: Vendedores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("razaoSocial,cnpj,email,site,telefone")] Vendedores vendedores)
        {
            if (id != vendedores.cnpj)
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
                    if (!VendedoresExists(vendedores.cnpj))
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

        // GET: Vendedores/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Vendedores == null)
            {
                return NotFound();
            }

            var vendedores = await _context.Vendedores
                .FirstOrDefaultAsync(m => m.cnpj == id);
            if (vendedores == null)
            {
                return NotFound();
            }

            return View(vendedores);
        }

        // POST: Vendedores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Vendedores == null)
            {
                return Problem("Entity set 'Contexto.Vendedores'  is null.");
            }
            var vendedores = await _context.Vendedores.FindAsync(id);
            if (vendedores != null)
            {
                _context.Vendedores.Remove(vendedores);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VendedoresExists(string id)
        {
          return (_context.Vendedores?.Any(e => e.cnpj == id)).GetValueOrDefault();
        }
    }
}
