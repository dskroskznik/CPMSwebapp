using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CPMSwebapp.Data; 
using CPMSwebapp.Models;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace CPMSwebapp.Controllers
{
    public class PapersController : Controller
    {
        private readonly ApplicationDbContext _context;
        public PapersController(ApplicationDbContext context) => _context = context;

        // GET: Papers
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Paper.Include(p => p.Author);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Papers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Paper == null)
            {
                return NotFound();
            }

            var paper = await _context.Paper
                .Include(p => p.Author)
                .FirstOrDefaultAsync(m => m.PaperId == id);
            if (paper == null)
            {
                return NotFound();
            }

            return View(paper);
        }

        // GET: Papers/Create
        public IActionResult Create()
        {
            ViewData["AuthorId"] = new SelectList(_context.Author, "AuthorId", "Address");
            return View();
        }

        // POST: Papers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PaperId,AuthorId,Active,FilenameOriginal,Filename,Title,Certification,NotesToReviewers,AnalysisOfAlgorithms,Applications,Architecture,ArtificialIntelligence,ComputerEngineering,Curriculum,DataStructures,Databases,DistanceLearning,DistributedSystems,EthicalSocietalIssues,FirstYearComputing,GenderIssues,GrantWriting,GraphicsImageProcessing,HumanComputerInteraction,LaboratoryEnvironments,Literacy,MathematicsInComputing,Multimedia,NetworkingDataCommunications,NonMajorCourses,ObjectOrientedIssues,OperatingSystems,ParallelsProcessing,Pedagogy,ProgrammingLanguages,Research,Security,SoftwareEngineering,SystemsAnalysisAndDesign,UsingTechnologyInTheClassroom,WebAndInternetProgramming,Other,OtherDescription")] Paper paper)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paper);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorId"] = new SelectList(_context.Author, "AuthorId", "Address", paper.AuthorId);
            return View(paper);
        }

        // GET: Papers/Create
        //UPLOAD FILE TO CREATE


        public IList<Paper> Paper { get; set; }
                public void OnGet()
                {
                    if (_context.Paper != null)
                    {
                        Paper = _context.Paper.ToList();
                    }
                }

        //GET: Paper/Create
        //DOWNLOAD FILE
        public async Task<IActionResult> OnPostDownloadAsync(int? id)
        {
            var paper = await _context.Paper.FirstOrDefaultAsync(x => x.PaperId == id);
            if (paper == null)
            {
                return NotFound();
            }
            if (paper.FileContent == null)
            {
                return View();
            }
            else
            {
                byte[] byteArray = paper.FileContent;
                string fileType = "application/pdf";
                return new FileContentResult(byteArray, fileType)
                {
                    FileDownloadName = $"Paper File {paper.FilenameOriginal}.pdf"
                };
            }

        }
        //GET: Paper/Create
        //DELETE FILE

        public async Task<IActionResult> OnPostDeleteAsync(int? id)
        {
            var paper = await _context.Paper.FirstOrDefaultAsync(x => x.PaperId == id);
            if (paper == null)
            {
                return NotFound();
            }
            if (paper.FileContent == null)
            {
                return View();
            }
            else
            {
                paper.FileContent = null;
                _context.Update(paper);
                await _context.SaveChangesAsync();

            }

            Paper = await _context.Paper.ToListAsync();
            return View();
        }

        // GET: Papers/Edit/5
        public async Task<IActionResult> Edit(int? id)
    {
        if (id == null || _context.Paper == null)
        {
            return NotFound();
        }

        var paper = await _context.Paper.FindAsync(id);
        if (paper == null)
        {
            return NotFound();
        }
        ViewData["AuthorId"] = new SelectList(_context.Author, "AuthorId", "Address", paper.AuthorId);
        return View(paper);
    }


        // POST: Papers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PaperId,AuthorId,Active,FilenameOriginal,Filename,Title,Certification,NotesToReviewers,AnalysisOfAlgorithms,Applications,Architecture,ArtificialIntelligence,ComputerEngineering,Curriculum,DataStructures,Databases,DistanceLearning,DistributedSystems,EthicalSocietalIssues,FirstYearComputing,GenderIssues,GrantWriting,GraphicsImageProcessing,HumanComputerInteraction,LaboratoryEnvironments,Literacy,MathematicsInComputing,Multimedia,NetworkingDataCommunications,NonMajorCourses,ObjectOrientedIssues,OperatingSystems,ParallelsProcessing,Pedagogy,ProgrammingLanguages,Research,Security,SoftwareEngineering,SystemsAnalysisAndDesign,UsingTechnologyInTheClassroom,WebAndInternetProgramming,Other,OtherDescription")] Paper paper)
        {
            if (id != paper.PaperId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paper);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaperExists(paper.PaperId))
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
            ViewData["AuthorId"] = new SelectList(_context.Author, "AuthorId", "Address", paper.AuthorId);
            return View(paper);
        }

        // GET: Papers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Paper == null)
            {
                return NotFound();
            }

            var paper = await _context.Paper
                .Include(p => p.Author)
                .FirstOrDefaultAsync(m => m.PaperId == id);
            if (paper == null)
            {
                return NotFound();
            }

            return View(paper);
        }

        // POST: Papers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Paper == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Paper'  is null.");
            }
            var paper = await _context.Paper.FindAsync(id);
            if (paper != null)
            {
                _context.Paper.Remove(paper);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaperExists(int id)
        {
          return (_context.Paper?.Any(e => e.PaperId == id)).GetValueOrDefault();
        }


    }
}
