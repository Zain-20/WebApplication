using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DbEFCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class EmployeeManagement : Controller
    {
        private ApplicationContext _context;

        public EmployeeManagement(ApplicationContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var emp = _context.Employees.Select(x=> new EmployeeViewModel { FathName = x.FathName,
            EmpName=x.EmpName,
            SelectedDepartment = x.Department.DepartmentName,
            SelectedDesignation= x.Designation.DesignationName,
            }).ToList();
            //var emp = (from item in _context.Employees
            //           select new { item.Department.DepartmentName, item.Designation.DesignationName, item.EmpName, item.JDate }).ToList();
            return View(emp);
        }

        [HttpGet]
        public IActionResult AddNewDepartment()
        {
            return PartialView("_AddNewDepartment");
        }
        [HttpPost]
        public IActionResult AddNewDepartment(Department department)
        {
            _context.Departments.Add(department);
            _context.SaveChanges();
            return Json(new { status=true});
        }

        [HttpGet]
        public IActionResult AddNewDesignation()
        {
            return PartialView("_AddNewDesignation");
        }

        [HttpPost]
        public IActionResult AddNewDesignation(Designation designation)
        {
            _context.Designations.Add(designation);
            _context.SaveChanges();
            return Json(new { status = true });
        }


        [HttpGet]
        public IActionResult AddNewEmployee()
        {
            List<SelectListItem> dpt = _context.Departments.OrderBy(x => x.DepartmentName).Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.DepartmentName
            }).ToList();

            List<SelectListItem> des = _context.Designations.OrderBy(x => x.DesignationName).Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.DesignationName
            }).ToList();

            EmployeeViewModel employeeViewModel = new EmployeeViewModel()
            {
                DesignationList = des,
                DepartmentList = dpt
            };
            return View(employeeViewModel);
        }

        [HttpPost]
        public IActionResult AddNewEmployee(EmployeeViewModel employeeViewModel)
        {
            Employee employee = new Employee()
            {
                FathName = employeeViewModel.FathName,
                DepartmentId = Convert.ToInt32(employeeViewModel.SelectedDepartment),
                DesignationId = Convert.ToInt32(employeeViewModel.SelectedDesignation),
                JDate = employeeViewModel.JDate,
                EmpName = employeeViewModel.EmpName
            };
            _context.Employees.Add(employee);
            _context.SaveChanges();
           return RedirectToAction("Index");
        }


    }
}
