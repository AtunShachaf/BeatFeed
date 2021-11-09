﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BeatFeed.Data;
using BeatFeed.Models;
using Microsoft.AspNetCore.Authorization;


namespace BeatFeed.Controllers
{
    public class SongsController : Controller
    {
        private readonly BeatFeedContext _context;

        public SongsController(BeatFeedContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "User")]
        public async Task<IActionResult> GetSongsOfArtistAjax(int? id)
        {

            // Get the artist
            var artistId= id.ToString();
            
            // Get the albums that belong to the artist
            var listOfalbums = (from n in _context.Album where n.ArtistId.ToString() == artistId select n.Id);

            // Get the all the songs that belong to the artist
            var query = from song in _context.Song
                        where listOfalbums.Contains(song.AlbumId)
                        join album in _context.Album on song.AlbumId equals album.Id    
                        select new
                        {
                           songId = song.Id,
                           name = song.Name,
                           songLink = song.LinkToPlay,
                           album = song.Album.Name,
                           imgLink = song.Album.ImageLink,
                           clipURL = song.ClipURL
                            
                        };

            var songs = await query.ToListAsync();
            return Json(new { Songs = songs });

        }

        [Authorize(Roles = "Admin")]
        // GET: Songs
        public async Task<IActionResult> Index()
        {
            var BeatFeedContext = _context.Song.Include(s => s.Album);
            return View(await BeatFeedContext.ToListAsync());
        }

        [Authorize(Roles = "Admin")]
        // GET: Songs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var song = await _context.Song
                .Include(s => s.Album)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (song == null)
            {
                return NotFound();
            }

            return View(song);
        }

        [Authorize(Roles = "Admin")]
        // GET: Songs/Create
        public IActionResult Create()
        {
            ViewData["AlbumId"] = new SelectList(_context.Set<Album>(), "Id", "Name");
            return View();
        }

        // POST: Songs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,CounterPlayed,LinkToPlay,AlbumId")] Song song)
        {
            if (ModelState.IsValid)
            {
                song.ClipURL = song.LinkToPlay.Replace("watch?v=", "embed/");
                _context.Add(song);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AlbumId"] = new SelectList(_context.Set<Album>(), "Id", "Name", song.AlbumId);
            return View(song);
        }

        [Authorize(Roles = "Admin")]

        // GET: Songs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var song = await _context.Song.FindAsync(id);
            if (song == null)
            {
                return NotFound();
            }
            ViewData["AlbumId"] = new SelectList(_context.Set<Album>(), "Id", "Name", song.AlbumId);
            return View(song);
        }

        // POST: Songs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CounterPlayed,LinkToPlay,ClipURL,AlbumId")] Song song)
        {
            if (id != song.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(song);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SongExists(song.Id))
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
            ViewData["AlbumId"] = new SelectList(_context.Set<Album>(), "Id", "Name", song.AlbumId);
            return View(song);
        }

        [Authorize(Roles = "Admin")]
        // GET: Songs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var song = await _context.Song
                .Include(s => s.Album)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (song == null)
            {
                return NotFound();
            }

            return View(song);
        }

        // POST: Songs/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var song = await _context.Song.FindAsync(id);
            _context.Song.Remove(song);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SongExists(int id)
        {
            return _context.Song.Any(e => e.Id == id);
        }
    }
}
