using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    public class SealContactsController : Controller
    {
        private readonly MvcSealContactContext _context;

        public SealContactsController(MvcSealContactContext context)
        {
            _context = context;
        }

        // GET: SealContacts
        public async Task<IActionResult> Index()
        {
            return View(await _context.SealContact.ToListAsync());
        }

        // GET: SealContacts/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sealContact = await _context.SealContact
                .FirstOrDefaultAsync(m => m.ID == id);
            if (sealContact == null)
            {
                return NotFound();
            }

            return View(sealContact);
        }

        // GET: SealContacts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SealContacts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,SEAL_ID,EMAIL,FIRST_NAME,LAST_NAME,REPRESENTATIVE_TYPE,SID")] SealContact sealContact)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sealContact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sealContact);
        }

        // GET: SealContacts/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sealContact = await _context.SealContact.FindAsync(id);
            if (sealContact == null)
            {
                return NotFound();
            }
            return View(sealContact);
        }

        // POST: SealContacts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ID,SEAL_ID,EMAIL,FIRST_NAME,LAST_NAME,REPRESENTATIVE_TYPE,SID")] SealContact sealContact)
        {
            if (id != sealContact.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sealContact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SealContactExists(sealContact.ID))
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
            return View(sealContact);
        }

        // GET: SealContacts/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sealContact = await _context.SealContact
                .FirstOrDefaultAsync(m => m.ID == id);
            if (sealContact == null)
            {
                return NotFound();
            }

            return View(sealContact);
        }

        // POST: SealContacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var sealContact = await _context.SealContact.FindAsync(id);
            _context.SealContact.Remove(sealContact);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SealContactExists(string id)
        {
            return _context.SealContact.Any(e => e.ID == id);
        }
    }
}
