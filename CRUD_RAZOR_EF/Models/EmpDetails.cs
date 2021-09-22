using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_RAZOR_EF.Models
{
    public class EmpDetails
    {
        [Key]
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string Email { get; set; }
        public decimal Salary { get; set; }

    }
}
