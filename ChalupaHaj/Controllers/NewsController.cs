using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ChalupaHaj.Data;
using ChalupaHaj.Models;
using Microsoft.AspNetCore.Authorization;

namespace ChalupaHaj.Controllers
{
    //controller for admnistator - edits news articles
    [Authorize]
    public class NewsController : Controller
    {

        //creates local database context
        private readonly ApplicationDbContext _context;


        //creates instance of database context
        public NewsController(ApplicationDbContext context)
        {
            _context = context;
        }


        //returns page with news content
        public async Task<IActionResult> Index()
        {
            return View(await _context.News.ToListAsync());
          
        }


        //returns page which shows details of news article
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.News == null)
            {
                return NotFound();
            }

            var news = await _context.News
                .FirstOrDefaultAsync(m => m.Id == id);
            if (news == null)
            {
                return NotFound();
            }

            return View(news);
        }


        //returns page where administrator creates news
        public IActionResult Create()
        {
            return View();
        }


        //creates new news article and saves it to the database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Price")] News news)
        {
            if (ModelState.IsValid)
            {
                _context.Add(news);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(news);
        }


        //return page where administrator can edit news
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.News == null)
            {
                return NotFound();
            }

            var news = await _context.News.FindAsync(id);
            if (news == null)
            {
                return NotFound();
            }
            return View(news);
        }


        //edits article in news database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Price")] News news)
        {
            if (id != news.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(news);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewsExists(news.Id))
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
            return View(news);
        }


        //returns page where administrator can delte article
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.News == null)
            {
                return NotFound();
            }

            var news = await _context.News
                .FirstOrDefaultAsync(m => m.Id == id);
            if (news == null)
            {
                return NotFound();
            }

            return View(news);
        }


        //Delets news article from database
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.News == null)
            {
                return Problem("Entity set 'ApplicationDbContext.News'  is null.");
            }
            var news = await _context.News.FindAsync(id);
            if (news != null)
            {
                _context.News.Remove(news);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        //returns bool if news contains any news article
        private bool NewsExists(int id)
        {
          return _context.News.Any(e => e.Id == id);
        }
    }
}
