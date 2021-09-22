using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CRUD_RAZOR_EF.Models;

namespace CRUD_RAZOR_EF.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly CRUD_RAZOR_EF.Models.EmpContext _context;

        public DeleteModel(CRUD_RAZOR_EF.Models.EmpContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            EmpDetails = await _context.EmpDetails.FindAsync(id);

            if (EmpDetails != null)
            {
                _context.EmpDetails.Remove(EmpDetails);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
