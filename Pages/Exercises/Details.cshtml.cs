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
    public class DetailsModel : PageModel
    {
        private readonly SoftwareIntegration.Data.ExerciseContext _context;

        public DetailsModel(SoftwareIntegration.Data.ExerciseContext context)
        {
            _context = context;
        }

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
    }
}
