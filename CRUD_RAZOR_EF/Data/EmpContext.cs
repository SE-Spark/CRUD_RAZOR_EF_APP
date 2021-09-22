using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CRUD_RAZOR_EF.Models
{
    public class EmpContext : DbContext
    {
        public EmpContext (DbContextOptions<EmpContext> options)
            : base(options)
        {
        }

        public DbSet<CRUD_RAZOR_EF.Models.EmpDetails> EmpDetails { get; set; }
    }
}
