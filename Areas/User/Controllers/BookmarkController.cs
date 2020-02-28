﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScriptsBookmark.Models;
using scriptsbookmarks.Data;

namespace ScriptsBookmark.Areas.User
{
    //[Authorize]
    [Area("User")]
    public class BookmarkController : Controller
    {
        private readonly ApplicationDbContext _db;

        public BookmarkController(ApplicationDbContext db)
        {
            _db = db;
        }

        //Index - GET
        public async Task<IActionResult> Index()
        {
            return View(await _db.Bookmark.ToListAsync());
        }

        //Create - GET
        public IActionResult Create()
        {
            return View();
        }

        //Create - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Bookmark bookmark)
        {
            if (ModelState.IsValid)
            {
                _db.Add(bookmark);
                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(bookmark);
        }

        //Edit -GET
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookmark = await _db.Bookmark.FindAsync(id);

            if (bookmark == null)
            {
                return NotFound();
            }

            return View(bookmark);

        }

    }
}