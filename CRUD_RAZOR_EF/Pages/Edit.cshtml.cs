using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUD_RAZOR_EF.Models;

namespace CRUD_RAZOR_EF.Pages
{
    public class EditModel : PageModel
    {
        private readonly CRUD_RAZOR_EF.Models.EmpContext _context;

        public EditModel(CRUD_RAZOR_EF.Models.EmpContext context)
        {
            _context = context;
        }

        [BindProperty]
        public EmpDetails EmpDetails { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            EmpDetails = await _context.EmpDetails.FirstOrDefaultAsync(m => m.EmpId == id);

            if (EmpDetails == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(EmpDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpDetailsExists(EmpDetails.EmpId))
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

        private bool EmpDetailsExists(int id)
        {
            return _context.EmpDetails.Any(e => e.EmpId == id);
        }
    }
}
