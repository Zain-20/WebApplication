using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string EmpName { get; set; }
        public string FathName { get; set; }
        public DateTime JDate { get; set; }

        //public ICollection<Designation> Designations { get; set; }
        //public ICollection<Department> Departments { get; set; }
        public int DesignationId { get; set; }
        public virtual Designation Designation { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
    }
}
