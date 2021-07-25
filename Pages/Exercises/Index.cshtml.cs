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
    public class IndexModel : PageModel
    {
        private readonly SoftwareIntegration.Data.ExerciseContext _context;

        public IndexModel(SoftwareIntegration.Data.ExerciseContext context)
        {
            _context = context;
        }

        public IList<Exercise> Exercise { get;set; }

        public async Task OnGetAsync()
        {
            Exercise = await _context.Exercise.ToListAsync();
        }
    }
}
