using LeaveManagementSystemBL;
using LeaveManagementSystemEntity;
using LeaveManagementSystemProject.Models;
using System;
using System.Web.Mvc;

namespace LeaveManagementSystemProject.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        EmployeeBL employeeBL = new EmployeeBL();
        DepartmentBL departmentBL = new DepartmentBL();
        Employee employee = new Employee();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(DepartmentModel departmentModel)
        {
            DepartmentBL departmentBL = new DepartmentBL();
            if (ModelState.IsValid)
            {
                Department department = new Department();
                department.DepartmentName = departmentModel.DepartmentName;
                departmentBL.AddDepartment(department);
            }
            return View();
        }
        public ActionResult CreateEmployee()
        {
            ViewBag.Departments = new SelectList(departmentBL.GetDepartment(),"DepartmentId","DepartmentName");   
            ViewBag.Managers = new SelectList(employeeBL.GetManager(), "ManagerId", "ManagerName");
            ViewBag.Designations = new SelectList(employeeBL.GetDesignation(), "DesignationId", "DesignationName");
            return View();
        }
        [HttpPost]
        public ActionResult CreateEmployee(EmployeeModel employeeModel)
        {
            ViewBag.Departments = new SelectList(departmentBL.GetDepartment(), "DepartmentId", "DepartmentName");
            ViewBag.Managers = new SelectList(employeeBL.GetManager(), "ManagerId", "ManagerName");
            ViewBag.Designations = new SelectList(employeeBL.GetDesignation(), "DesignationId", "DesignationName");
            if (ModelState.IsValid)
            {
                var employee = AutoMapper.Mapper.Map<EmployeeModel, Employee>(employeeModel);
                //Employee employee = new Employee();
                //employee.EmployeeName = employeeModel.EmployeeName;
                //employee.EmployeeAge = employeeModel.EmployeeAge;
                //employee.EmployeePhoneNumber = employeeModel.EmployeePhoneNumber;
                //employee.EmployeeEmail = employeeModel.EmployeeEmail;
                //employee.DepartmentId = employeeModel.DepartmentId;
                //employee.DesignationId = employeeModel.DesignationId;
                //employee.ManagerId = employeeModel.ManagerId;            
                employeeBL.AddEmployee(employee);
                Account(employeeModel);
                return RedirectToAction("Display");
            }
            return View();
        }
        public ActionResult Account(EmployeeModel employeeModel)
        {
            Account account = new Account();
            account.UserName = employeeModel.EmployeeEmail;
            account.Password = employeeBL.Password(employeeModel.EmployeeName,Convert.ToString(employeeModel.EmployeePhoneNumber));
            account.Role = "User";
            employeeBL.AddAccount(account);
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Employee employee)
        {
            return View();
        }
        public ActionResult Display()
        {
            TempData["Employees"] = employeeBL.GetEmployee();
            return View();
        }
        public ActionResult Delete(int id)
        {
            employeeBL.DeleteEmployee(id);
            return RedirectToAction("Display");
        }
        public ViewResult Edit(int id)
        {
            ViewBag.Departments = new SelectList(departmentBL.GetDepartment(), "DepartmentId", "DepartmentName");
            ViewBag.Managers = new SelectList(employeeBL.GetManager(), "ManagerId", "ManagerName");
            ViewBag.Designations = new SelectList(employeeBL.GetDesignation(), "DesignationId", "DesignationName");
            EmployeeModel employeeModel = new EmployeeModel();
            employee=employeeBL.GetEmployeeId(id);
            employeeModel.EmployeeId = employee.EmployeeId;
            employeeModel.EmployeeName = employee.EmployeeName;
            employeeModel.EmployeeAge = employee.EmployeeAge;
            employeeModel.EmployeePhoneNumber = employee.EmployeePhoneNumber;
            employeeModel.DesignationId = employee.DesignationId;
            employeeModel.DepartmentId = employee.DepartmentId;
            employeeModel.ManagerId = employee.ManagerId;
            return View(employeeModel);
        }
        [HttpPost]
        public ActionResult Update(EmployeeModel employeemodel)
        {
            if (ModelState.IsValid)
            {
                employee.EmployeeId = employeemodel.EmployeeId;
                employee.EmployeeName = employeemodel.EmployeeName;
                employee.EmployeeAge = employeemodel.EmployeeAge;
                employee.EmployeePhoneNumber = employeemodel.EmployeePhoneNumber;
                employee.DepartmentId = employeemodel.DepartmentId;
                employee.DesignationId = employeemodel.DesignationId;
                employee.ManagerId = employeemodel.ManagerId;
                employeeBL.UpdateEmployee(employee);
                return RedirectToAction("Display");

            }
            return View();
        }


    }

}