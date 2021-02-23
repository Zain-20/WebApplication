using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class EmployeeViewModel
    {
        public EmployeeViewModel()
        {
            JDate = DateTime.Now;
        }
     
        public int Id { get; set; }
        public string EmpName { get; set; }
        public string FathName { get; set; }

        [DataType(DataType.Date)]
        public DateTime JDate { get; set; }


        [Display(Name = "Designation")]
        public string SelectedDesignation { get; set; }
        public List<SelectListItem> DesignationList { get; set; }

        [Display(Name = "Department")]
        public string SelectedDepartment { get; set; }
        public List<SelectListItem> DepartmentList { get; set; }


    }
}

