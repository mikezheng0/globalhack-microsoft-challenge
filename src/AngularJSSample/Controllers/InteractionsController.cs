using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AngularJSSample.Models;

namespace AngularJSSample.Controllers
{
    public class InteractionsController : Controller
    {
        private readonly CameraContext _context;

        public InteractionsController(CameraContext context)
        {
            _context = context;    
        }

        // GET: Interactions
        public async Task<IActionResult> Index()
        {
            return View(await _context.Interaction.ToListAsync());
        }

        // GET: Interactions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var interaction = await _context.Interaction
                .SingleOrDefaultAsync(m => m.Id == id);
            if (interaction == null)
            {
                return NotFound();
            }

            return View(interaction);
        }

        // GET: Interactions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Interactions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Image,CustomerId,Time")] Interaction interaction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(interaction);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(interaction);
        }

        // GET: Interactions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var interaction = await _context.Interaction.SingleOrDefaultAsync(m => m.Id == id);
            if (interaction == null)
            {
                return NotFound();
            }
            return View(interaction);
        }

        // POST: Interactions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Image,CustomerId,Time")] Interaction interaction)
        {
            if (id != interaction.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(interaction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InteractionExists(interaction.Id))
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
            return View(interaction);
        }

        // GET: Interactions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var interaction = await _context.Interaction
                .SingleOrDefaultAsync(m => m.Id == id);
            if (interaction == null)
            {
                return NotFound();
            }

            return View(interaction);
        }

        // POST: Interactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var interaction = await _context.Interaction.SingleOrDefaultAsync(m => m.Id == id);
            _context.Interaction.Remove(interaction);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool InteractionExists(int id)
        {
            return _context.Interaction.Any(e => e.Id == id);
        }
    }
}
