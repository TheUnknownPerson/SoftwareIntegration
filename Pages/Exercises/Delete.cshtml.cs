using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SoftwareIntegration.Data;
using SoftwareIntegration.Models;

namespace SoftwareIntegration.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly SoftwareIntegration.Data.ExerciseContext _context;

        public DeleteModel(SoftwareIntegration.Data.ExerciseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Exercise Exercise { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Exercise = await _context.Exercise.FirstOrDefaultAsync(m => m.id == id);

            if (Exercise == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Exercise = await _context.Exercise.FindAsync(id);

            if (Exercise != null)
            {
                _context.Exercise.Remove(Exercise);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
