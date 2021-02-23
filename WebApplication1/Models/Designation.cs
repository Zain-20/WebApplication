using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Designation
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Designation Name")]
        public string DesignationName { get; set; }
        //public int EmployeeId { get; set; }
        public ICollection<Employee> Employees { get; set; }

    }
}
