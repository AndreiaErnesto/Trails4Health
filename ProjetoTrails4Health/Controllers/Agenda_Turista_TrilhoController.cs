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
    
    public class Agenda_Turista_TrilhoController : Controller
    {
        
        private readonly Trails4HealthDbContext _context;

        public Agenda_Turista_TrilhoController(Trails4HealthDbContext context)
        {
            _context = context;    
        }

        // GET: Agenda_Turista_Trilho
        [Authorize(Roles = "Professor,Turista")]
        public async Task<IActionResult> Index()
        {
            var aplicacaoDbContext = _context.Agenda_Turista_Trilho.Include(a => a.Trilho);
            return View(await aplicacaoDbContext.ToListAsync());
        }

        // GET: Agenda_Turista_Trilho/Details/5
        [Authorize(Roles = "Professor,Turista")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agenda_Turista_Trilho = await _context.Agenda_Turista_Trilho
                .Include(a => a.Trilho)
                .Include(a => a.Turista)
                .SingleOrDefaultAsync(m => m.Agenda_Turista_TrilhoId == id);
            if (agenda_Turista_Trilho == null)
            {
                return NotFound();
            }

            return View(agenda_Turista_Trilho);
        }

        // GET: Agenda_Turista_Trilho/AgendarTrilho
        [Authorize(Roles = "Professor,Turista")]
        public IActionResult AgendarTrilho (int ? id)
        {
            var agendamento = new Agenda_Turista_Trilho();
            agendamento.Trilho = _context.Trilho.SingleOrDefault(t => t.TrilhoId == id);
            //ViewData["Trilhos"] = trilhos;
            //ViewData["TrilhoId"] = new SelectList(_context.Set<Trilho>(), "TrilhoId", "Nome");
            //ViewData["DificuldadeId"] = new SelectList(_context.Set<Dificuldade>(), "DificuldadeId", "NomeDificuldade");
            return View(agendamento);
        }

        public IActionResult SelecionaTrilhoAgendar()
        {
            var trilhos = _context.Trilho.ToList();
           
            return View(trilhos);
        }

        // POST: Agenda_Turista_Trilho/AgendarTrilho
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Turista")]
        public async Task<IActionResult> AgendarTrilho([Bind("TrilhoId,Data_Prevista_Inicio_Trilho")] Agenda_Turista_Trilho agenda_Turista_Trilho)
        {
            if (ModelState.IsValid)
            {
                //Saber qual Turista que fez o agendamento de um determinado trilho
                //var nomeUser = User.Identity.Name;
                //var turista = await _context.Turista.SingleOrDefaultAsync(t => t.Nome == nomeUser);
                //agenda_Turista_Trilho.Turista = turista;
                agenda_Turista_Trilho.Turista = await _context.Turista.SingleOrDefaultAsync(t => t.TuristaId == 1);
                agenda_Turista_Trilho.Dificuldade = await _context.Dificuldade.SingleOrDefaultAsync(d => d.DificuldadeId==1);
                if (agenda_Turista_Trilho.Turista == null)
                {
                    return NotFound();
                }

                _context.Add(agenda_Turista_Trilho);

                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["TrilhoId"] = new SelectList(_context.Set<Trilho>(), "TrilhoId", "Nome", agenda_Turista_Trilho.TrilhoId);
           // ViewData["TuristaId"] = new SelectList(_context.Set<Turista>(), "TuristaId", "DataNascimento", agenda_Turista_Trilho.TuristaId);
            return View(agenda_Turista_Trilho);
        }

        // GET: Agenda_Turista_Trilho/Edit/5
        [Authorize(Roles = "Turista")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agenda_Turista_Trilho = await _context.Agenda_Turista_Trilho.SingleOrDefaultAsync(m => m.Agenda_Turista_TrilhoId == id);
            if (agenda_Turista_Trilho == null)
            {
                return NotFound();
            }
            ViewData["TrilhoId"] = new SelectList(_context.Set<Trilho>(), "TrilhoId", "Nome", agenda_Turista_Trilho.TrilhoId);
            ViewData["TuristaId"] = new SelectList(_context.Set<Turista>(), "TuristaId", "Nome", agenda_Turista_Trilho.TuristaId);
            return View(agenda_Turista_Trilho);
        }

        // POST: Agenda_Turista_Trilho/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Turista")]
        public async Task<IActionResult> Edit(int id, [Bind("TrilhoId,Tempo_Gasto,TuristaId,Data_Reserva,Data_Prevista_Inicio_Trilho,Estado_Agendamento,Data_Estado_Agendamento")] Agenda_Turista_Trilho agenda_Turista_Trilho)
        {
            //agenda_Turista_Trilho.Turista = await _context.Turista.SingleOrDefaultAsync(t => t.TuristaId == 1);
            //agenda_Turista_Trilho.Dificuldade = await _context.Dificuldade.SingleOrDefaultAsync(d => d.DificuldadeId == 1);
            if (id != agenda_Turista_Trilho.Agenda_Turista_TrilhoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(agenda_Turista_Trilho);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Agenda_Turista_TrilhoExists(agenda_Turista_Trilho.Agenda_Turista_TrilhoId))
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
            ViewData["TrilhoId"] = new SelectList(_context.Set<Trilho>(), "TrilhoId", "Nome", agenda_Turista_Trilho.TrilhoId);
            ViewData["TuristaId"] = new SelectList(_context.Set<Turista>(), "TuristaId", "Nome", agenda_Turista_Trilho.TuristaId);
            return View(agenda_Turista_Trilho);
        }

        // GET: Agenda_Turista_Trilho/Delete/5
        [Authorize(Roles = "Professor,Turista")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agenda_Turista_Trilho = await _context.Agenda_Turista_Trilho
                .Include(a => a.Trilho)
                .Include(a => a.Turista)
                .SingleOrDefaultAsync(m => m.Agenda_Turista_TrilhoId == id);
            if (agenda_Turista_Trilho == null)
            {
                return NotFound();
            }

            return View(agenda_Turista_Trilho);
        }

        // POST: Agenda_Turista_Trilho/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Professor,Turista")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var agenda_Turista_Trilho = await _context.Agenda_Turista_Trilho.SingleOrDefaultAsync(m => m.Agenda_Turista_TrilhoId == id);
            _context.Agenda_Turista_Trilho.Remove(agenda_Turista_Trilho);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool Agenda_Turista_TrilhoExists(int id)
        {

            return _context.Agenda_Turista_Trilho.Any(e => e.Agenda_Turista_TrilhoId == id);
        }
    }
}
