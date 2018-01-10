using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoTrails4Health.Data;
using ProjetoTrails4Health.Models;
using ProjetoTrails4Health.Models.ViewModels;

namespace ProjetoTrails4Health.Controllers
{
    public class TuristasController : Controller
    {
        public int PageSize = 4;
        private readonly Trails4HealthDbContext _context;

        public TuristasController(Trails4HealthDbContext context)
        {
            _context = context;    
        }


        public ViewResult Index(int page = 1)
        {
            


            return View(
                new TuristaListViewModel
                {
                    Turistas = _context.Turista
                        .OrderBy(p => p.TuristaId)
                        .Skip(PageSize * (page - 1))
                        .Take(PageSize).ToListAsync().Result,

            
            PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = _context.Turista.Count()
                    }
                }
            );
        }


        // GET: Turistas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turista = await _context.Turista
                .SingleOrDefaultAsync(m => m.TuristaId == id);
            if (turista == null)
            {
                return NotFound();
            }

            return View(turista);
        }

        // GET: Turistas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Turistas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TuristaId,Nome,Password,Morada,CodPostal,Email,Telemovel,DataNascimento,NIF")] Turista turista)
        {
            if (ModelState.IsValid)
            {
                _context.Add(turista);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(turista);
        }

        // GET: Turistas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turista = await _context.Turista.SingleOrDefaultAsync(m => m.TuristaId == id);
            if (turista == null)
            {
                return NotFound();
            }
            return View(turista);
        }

        // POST: Turistas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TuristaId,Nome,Password,Morada,CodPostal,Email,Telemovel,DataNascimento,NIF")] Turista turista)
        {
            if (id != turista.TuristaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(turista);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TuristaExists(turista.TuristaId))
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
            return View(turista);
        }

        // GET: Turistas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turista = await _context.Turista
                .SingleOrDefaultAsync(m => m.TuristaId == id);
            if (turista == null)
            {
                return NotFound();
            }

            return View(turista);
        }

        // POST: Turistas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var turista = await _context.Turista.SingleOrDefaultAsync(m => m.TuristaId == id);
            _context.Turista.Remove(turista);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool TuristaExists(int id)
        {
            return _context.Turista.Any(e => e.TuristaId == id);
        }
    }
}
