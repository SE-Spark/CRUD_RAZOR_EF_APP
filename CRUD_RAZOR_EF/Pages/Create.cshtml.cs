using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CRUD_RAZOR_EF.Models;

namespace CRUD_RAZOR_EF.Pages
{
    public class CreateModel : PageModel
    {
        private readonly CRUD_RAZOR_EF.Models.EmpContext _context;

        public CreateModel(CRUD_RAZOR_EF.Models.EmpContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public EmpDetails EmpDetails { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.EmpDetails.Add(EmpDetails);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}