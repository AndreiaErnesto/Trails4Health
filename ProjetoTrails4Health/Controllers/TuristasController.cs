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

        [Authorize(Roles = "Professor")]
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
        [Authorize(Roles = "Professor")]
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
        [Authorize(Roles = "Professor, Turista")]
        public async Task<IActionResult> Create([Bind("TuristaId,Nome,Morada,CodPostal,Email,Telemovel,DataNascimento,NIF")] Turista turista)
        {
            if (ModelState.IsValid)
            {

                if (IsValidContrib(turista.NIF) == false)
                {
                    ModelState.AddModelError("NIF", "O Nif está incorreto.");
                    return View();
                }
                else
                {
                    _context.Add(turista);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return View(turista);
        }

        public bool IsValidContrib(string Contrib)
        {
            bool functionReturnValue = false;
            functionReturnValue = false;
            string[] s = new string[9];
            string Ss = null;
            string C = null;
            int i = 0;
            long checkDigit = 0;

            s[0] = Convert.ToString(Contrib[0]);
            s[1] = Convert.ToString(Contrib[1]);
            s[2] = Convert.ToString(Contrib[2]);
            s[3] = Convert.ToString(Contrib[3]);
            s[4] = Convert.ToString(Contrib[4]);
            s[5] = Convert.ToString(Contrib[5]);
            s[6] = Convert.ToString(Contrib[6]);
            s[7] = Convert.ToString(Contrib[7]);
            s[8] = Convert.ToString(Contrib[8]);

            if (Contrib.Length == 9)
            {
                C = s[0];
                if (s[0] == "1" || s[0] == "2" || s[0] == "5" || s[0] == "6" || s[0] == "9")
                {
                    checkDigit = Convert.ToInt32(C) * 9;
                    for (i = 2; i <= 8; i++)
                    {
                        checkDigit = checkDigit + (Convert.ToInt32(s[i - 1]) * (10 - i));
                    }
                    checkDigit = 11 - (checkDigit % 11);
                    if ((checkDigit >= 10))
                        checkDigit = 0;
                    Ss = s[0] + s[1] + s[2] + s[3] + s[4] + s[5] + s[6] + s[7] + s[8];
                    if ((checkDigit == Convert.ToInt32(s[8])))
                        functionReturnValue = true;
                }
            }
            return functionReturnValue;
        }

        // GET: Turistas/Edit/5
        [Authorize(Roles = "Professor,Turista")]
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
        [Authorize(Roles = "Professor,Turista")]
        public async Task<IActionResult> Edit(int id, [Bind("TuristaId,Nome,Morada,CodPostal,Email,Telemovel,DataNascimento,NIF")] Turista turista)
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
        [Authorize(Roles = "Professor,Turista")]
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
        [Authorize(Roles = "Professor,Turista")]
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
