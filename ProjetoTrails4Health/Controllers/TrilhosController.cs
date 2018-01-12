using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoTrails4Health.Data;
using ProjetoTrails4Health.Models;

namespace ProjetoTrails4Health.Controllers
{ 
    public class TrilhosController : Controller
    {
        
        private readonly Trails4HealthDbContext _context;

        public TrilhosController(Trails4HealthDbContext context)
        {
            _context = context;    
        }

        

        // GET: Trilhoes
        public async Task<IActionResult> Index()
        {
            var aplicacaoDbContext = _context.Trilho.Include(t => t.Dificuldade).Include(t => t.Professor);
            return View(await aplicacaoDbContext.ToListAsync());
        }

        // GET: Trilhoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trilho = await _context.Trilho
                .Include(t => t.Dificuldade)
                .Include(t => t.Professor)
                .SingleOrDefaultAsync(m => m.TrilhoId == id);
            if (trilho == null)
            {
                return NotFound();
            }

            return View(trilho);
        }

        // GET: Trilhoes/Create
        [Authorize(Roles = "Professor")]
        public IActionResult Create()
        {
            ViewData["DificuldadeId"] = new SelectList(_context.Set<Dificuldade>(), "DificuldadeId", "DificuldadeId");
            ViewData["ProfessorId"] = new SelectList(_context.Professor, "ProfessorId", "DataNascimento");
            return View();
        }

        // POST: Trilhoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TrilhoId,Nome_Trilho,Local_Inicio_Trilho,Local_Fim_Trilho,Distancia_Total,Duracao_Media,Esta_Ativo,Tempo_Gasto,ProfessorId,DificuldadeId")] Trilho trilho)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trilho);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["DificuldadeId"] = new SelectList(_context.Set<Dificuldade>(), "DificuldadeId", "DificuldadeId", trilho.DificuldadeId);
            ViewData["ProfessorId"] = new SelectList(_context.Professor, "ProfessorId", "DataNascimento", trilho.ProfessorId);
            return View(trilho);
        }

        // GET: Trilhoes/Edit/5
        [Authorize(Roles = "Professor")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trilho = await _context.Trilho.SingleOrDefaultAsync(m => m.TrilhoId == id);
            if (trilho == null)
            {
                return NotFound();
            }
            ViewData["DificuldadeId"] = new SelectList(_context.Set<Dificuldade>(), "DificuldadeId", "DificuldadeId", trilho.DificuldadeId);
            ViewData["ProfessorId"] = new SelectList(_context.Professor, "ProfessorId", "DataNascimento", trilho.ProfessorId);
            return View(trilho);
        }

        // POST: Trilhoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Professor")]
        public async Task<IActionResult> Edit(int id, [Bind("TrilhoId,Nome_Trilho,Local_Inicio_Trilho,Local_Fim_Trilho,Distancia_Total,Duracao_Media,Esta_Ativo,Tempo_Gasto,ProfessorId,DificuldadeId")] Trilho trilho)
        {
            if (id != trilho.TrilhoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trilho);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrilhoExists(trilho.TrilhoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["DificuldadeId"] = new SelectList(_context.Set<Dificuldade>(), "DificuldadeId", "DificuldadeId", trilho.DificuldadeId);
            ViewData["ProfessorId"] = new SelectList(_context.Professor, "ProfessorId", "DataNascimento", trilho.ProfessorId);
            return View(trilho);
        }

        // GET: Trilhoes/Delete/5
        [Authorize(Roles = "Professor")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trilho = await _context.Trilho
                .Include(t => t.Dificuldade)
                .Include(t => t.Professor)
                .SingleOrDefaultAsync(m => m.TrilhoId == id);
            if (trilho == null)
            {
                return NotFound();
            }

            return View(trilho);
        }

        // POST: Trilhoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Professor")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trilho = await _context.Trilho.SingleOrDefaultAsync(m => m.TrilhoId == id);
            _context.Trilho.Remove(trilho);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool TrilhoExists(int id)
        {
            return _context.Trilho.Any(e => e.TrilhoId == id);
        }
    }
}
