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
    public class tela_de_loginController : Controller
    {
        private readonly Contexto _context;

        public tela_de_loginController(Contexto context)
        {
            _context = context;
        }

        // GET: tela_de_login
        public async Task<IActionResult> Index()
        {
              return _context.tela_de_login != null ? 
                          View(await _context.tela_de_login.ToListAsync()) :
                          Problem("Entity set 'Contexto.tela_de_login'  is null.");
        }

        // GET: tela_de_login/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.tela_de_login == null)
            {
                return NotFound();
            }

            var tela_de_login = await _context.tela_de_login
                .FirstOrDefaultAsync(m => m.NomeUsuario == id);
            if (tela_de_login == null)
            {
                return NotFound();
            }

            return View(tela_de_login);
        }

        // GET: tela_de_login/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: tela_de_login/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NomeUsuario,Senha")] tela_de_login tela_de_login)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tela_de_login);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tela_de_login);
        }

        // GET: tela_de_login/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.tela_de_login == null)
            {
                return NotFound();
            }

            var tela_de_login = await _context.tela_de_login.FindAsync(id);
            if (tela_de_login == null)
            {
                return NotFound();
            }
            return View(tela_de_login);
        }

        // POST: tela_de_login/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("NomeUsuario,Senha")] tela_de_login tela_de_login)
        {
            if (id != tela_de_login.NomeUsuario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tela_de_login);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tela_de_loginExists(tela_de_login.NomeUsuario))
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
            return View(tela_de_login);
        }

        // GET: tela_de_login/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.tela_de_login == null)
            {
                return NotFound();
            }

            var tela_de_login = await _context.tela_de_login
                .FirstOrDefaultAsync(m => m.NomeUsuario == id);
            if (tela_de_login == null)
            {
                return NotFound();
            }

            return View(tela_de_login);
        }

        // POST: tela_de_login/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.tela_de_login == null)
            {
                return Problem("Entity set 'Contexto.tela_de_login'  is null.");
            }
            var tela_de_login = await _context.tela_de_login.FindAsync(id);
            if (tela_de_login != null)
            {
                _context.tela_de_login.Remove(tela_de_login);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tela_de_loginExists(string id)
        {
          return (_context.tela_de_login?.Any(e => e.NomeUsuario == id)).GetValueOrDefault();
        }
    }
}
