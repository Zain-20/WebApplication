﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Department Name")]
        public string DepartmentName { get; set; }
        public ICollection<Employee> Employees { get; set; }

        //public int EmployeeId { get; set; }
    }
}
