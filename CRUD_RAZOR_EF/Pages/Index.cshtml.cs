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
    public class IndexModel : PageModel
    {
        private readonly CRUD_RAZOR_EF.Models.EmpContext _context;

        public IndexModel(CRUD_RAZOR_EF.Models.EmpContext context)
        {
            _context = context;
        }

        public IList<EmpDetails> EmpDetails { get;set; }

        public async Task OnGetAsync()
        {
            EmpDetails = await _context.EmpDetails.ToListAsync();
        }
    }
}
