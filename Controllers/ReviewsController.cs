﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CPMSwebapp.Data;
using CPMSwebapp.Models;

namespace CPMSwebapp.Controllers
{
    public class ReviewsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReviewsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Reviews
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Review.Include(r => r.Paper).Include(r => r.Reviewer);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Reviews/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Review == null)
            {
                return NotFound();
            }

            var review = await _context.Review
                .Include(r => r.Paper)
                .Include(r => r.Reviewer)
                .FirstOrDefaultAsync(m => m.ReviewId == id);
            if (review == null)
            {
                return NotFound();
            }

            return View(review);
        }

        // GET: Reviews/Create
        public IActionResult Create()
        {
            ViewData["PaperId"] = new SelectList(_context.Paper, "PaperId", "Certification");
            ViewData["ReviewerId"] = new SelectList(_context.Set<Reviewer>(), "ReviewerId", "Address");
            return View();
        }

        // POST: Reviews/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReviewId,PaperId,ReviewerId,AppropriatenessOfTopic,TimelinessOfTopic,SupportiveEvidence,TechnicalQuality,ScopeOfCoverage,CitationOfPreviousWork,Originality,ContentComments,OrganizationOfPaper,ClarityOfMainMessage,Mechanics,WrittenDocumentComments,SuitabilityForPresentation,PotentialInterestInTopic,PotentialForOralPresentationComments,OverallRating,OverallRatingComments,ComfortLevelTopic,ComfortLevelAcceptability,Complete")] Review review)
        {
            if (ModelState.IsValid)
            {
                _context.Add(review);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PaperId"] = new SelectList(_context.Paper, "PaperId", "Certification", review.PaperId);
            ViewData["ReviewerId"] = new SelectList(_context.Set<Reviewer>(), "ReviewerId", "Address", review.ReviewerId);
            return View(review);
        }

        // GET: Reviews/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Review == null)
            {
                return NotFound();
            }

            var review = await _context.Review.FindAsync(id);
            if (review == null)
            {
                return NotFound();
            }
            ViewData["PaperId"] = new SelectList(_context.Paper, "PaperId", "Certification", review.PaperId);
            ViewData["ReviewerId"] = new SelectList(_context.Set<Reviewer>(), "ReviewerId", "Address", review.ReviewerId);
            return View(review);
        }

        // POST: Reviews/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReviewId,PaperId,ReviewerId,AppropriatenessOfTopic,TimelinessOfTopic,SupportiveEvidence,TechnicalQuality,ScopeOfCoverage,CitationOfPreviousWork,Originality,ContentComments,OrganizationOfPaper,ClarityOfMainMessage,Mechanics,WrittenDocumentComments,SuitabilityForPresentation,PotentialInterestInTopic,PotentialForOralPresentationComments,OverallRating,OverallRatingComments,ComfortLevelTopic,ComfortLevelAcceptability,Complete")] Review review)
        {
            if (id != review.ReviewId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(review);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReviewExists(review.ReviewId))
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
            ViewData["PaperId"] = new SelectList(_context.Paper, "PaperId", "Certification", review.PaperId);
            ViewData["ReviewerId"] = new SelectList(_context.Set<Reviewer>(), "ReviewerId", "Address", review.ReviewerId);
            return View(review);
        }

        // GET: Reviews/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Review == null)
            {
                return NotFound();
            }

            var review = await _context.Review
                .Include(r => r.Paper)
                .Include(r => r.Reviewer)
                .FirstOrDefaultAsync(m => m.ReviewId == id);
            if (review == null)
            {
                return NotFound();
            }

            return View(review);
        }

        // POST: Reviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Review == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Review'  is null.");
            }
            var review = await _context.Review.FindAsync(id);
            if (review != null)
            {
                _context.Review.Remove(review);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReviewExists(int id)
        {
          return (_context.Review?.Any(e => e.ReviewId == id)).GetValueOrDefault();
        }
    }
}