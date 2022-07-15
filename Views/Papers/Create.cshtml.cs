using CPMSwebapp.Data;
using CPMSwebapp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace CPMSwebapp.Views.Papers
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly long _fileSizeLimit;
        private readonly string[] _permittedExtensions = { ".txt" };

        public CreateModel(ApplicationDbContext context, IConfiguration config)
        {
            _context = context;
            _fileSizeLimit = config.GetValue<long>("FileSizeLimit");
        }

        [BindProperty]
        public Paper FileUpload { get; set; }
        public string Result { get; private set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> UploadFile(IFormFile file, int? id)
        {
            if (!ModelState.IsValid)
            {
                Result = "Please correct the form.";

                return Page();
            }

            if (file != null)
            {
                if (file.Length > 0 && file.Length < 300000)
                {
                    var Paper = _context.Paper.Find(id);

                    using (var target = new MemoryStream())
                    {
                        file.CopyTo(target);
                        Paper.FileContent = target.ToArray();
                    }

                    _context.Paper.Update(Paper);
                    await _context.SaveChangesAsync();
                }
            }
            return RedirectToAction("Create", "Papers");

        }

        public async Task<IActionResult> OnPostAsync(IFormFile file, int? id)
        {
            if (!ModelState.IsValid)
            {
                Result = "Please correct the form.";

                return Page();
            }

            if (file != null)
            {
                if (file.Length > 0 && file.Length < 300000)
                {
                    var Paper = _context.Paper.Find(id);

                    using (var target = new MemoryStream())
                    {
                        file.CopyTo(target);
                        Paper.FileContent = target.ToArray();
                    }

                    _context.Add(Paper);
                    await _context.SaveChangesAsync();
                    TempData["success"] = "Paper has been submitted succesfully!";
                }
            }
            return RedirectToAction("Create", "Papers");

        }
    }
}
