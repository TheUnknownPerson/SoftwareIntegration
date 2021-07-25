using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SoftwareIntegration.Data;
using SoftwareIntegration.Models;

namespace SoftwareIntegration.Pages
{
    public class EditModel : PageModel
    {
        private readonly SoftwareIntegration.Data.ExerciseContext _context;

        public EditModel(SoftwareIntegration.Data.ExerciseContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Exercise).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExerciseExists(Exercise.id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ExerciseExists(int id)
        {
            return _context.Exercise.Any(e => e.id == id);
        }
    }
}
