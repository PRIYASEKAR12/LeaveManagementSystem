using System;
using LeaveManagementSystemBL;
using LeaveManagementSystemEntity;
using LeaveManagementSystemProject.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeaveManagementSystemProject.Controllers
{
   
    public class AdminController : Controller
    {
        IEmployeeBL employeeBL;
        IDepartmentBL departmentBL;
        public AdminController()
        {
            departmentBL = new DepartmentBL();
            employeeBL = new EmployeeBL();
        }
        Employee employee = new Employee();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        //create Department
        [HttpGet]
        public ActionResult Create()                         
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(DepartmentModel departmentModel)
        {

            if (ModelState.IsValid)
            {
                Department department = new Department();
                department.DepartmentName = departmentModel.DepartmentName;
                departmentBL.AddDepartment(department);
                return RedirectToAction("DisplayDepartment");
            }
            return View();
        }
        //Retrieve the Department Details
        public ActionResult DisplayDepartment()                        
        {
            IEnumerable<Department> departmentList = departmentBL.GetDepartment();
            return View(departmentList);
        }
        //DELETE THE DEPARTMENT DETAILS
        public ActionResult DeleteDepartment(int id)
        {
            departmentBL.DeleteDepartment(id);
            return RedirectToAction("DisplayDepartment");
        }
        //EDIT THE DEPARTMENT DETAILS
        public ViewResult EditDepartment(int id)
        {
            DepartmentModel departmentModel = new DepartmentModel();
            Department department = departmentBL.GetDepartmentId(id);
            departmentModel.DepartmentId = department.DepartmentId;
            departmentModel.DepartmentName = department.DepartmentName;
            return View(departmentModel);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult UpdateDepartment(DepartmentModel departmentmodel)
        {
            if (ModelState.IsValid)
            {
                Department department = new Department();
                department.DepartmentId = departmentmodel.DepartmentId;
                department.DepartmentName = departmentmodel.DepartmentName;
                departmentBL.UpdateDepartment(department);
                return RedirectToAction("DisplayDepartment");

            }
            return View();
        }
        //ADD THE EMPLOYEE DETAILS

        public ActionResult CreateEmployee()
        {
            ViewBag.Departments = new SelectList(departmentBL.GetDepartment(), "DepartmentId", "DepartmentName");
            ViewBag.Managers = new SelectList(employeeBL.GetManager(), "ManagerId", "ManagerName");
            ViewBag.Designations = new SelectList(employeeBL.GetDesignation(), "DesignationId", "DesignationName");
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult CreateEmployee(EmployeeModel employeeModel)
        {
            ViewBag.Departments = new SelectList(departmentBL.GetDepartment(), "DepartmentId", "DepartmentName");
            ViewBag.Managers = new SelectList(employeeBL.GetManager(), "ManagerId", "ManagerName");
            ViewBag.Designations = new SelectList(employeeBL.GetDesignation(), "DesignationId", "DesignationName");
            if (ModelState.IsValid)
            {
                
                var employee = AutoMapper.Mapper.Map<EmployeeModel, Employee>(employeeModel);
                employeeBL.AddEmployee(employee);
                Account(employeeModel);
                //Employee employee = new Employee();
                //employee.EmployeeName = employeeModel.EmployeeName;
                //employee.EmployeeAge = employeeModel.EmployeeAge;
                //employee.EmployeePhoneNumber = employeeModel.EmployeePhoneNumber;
                //employee.EmployeeEmail = employeeModel.EmployeeEmail;
                //employee.DepartmentId = employeeModel.DepartmentId;
                //employee.DesignationId = employeeModel.DesignationId;
                //employee.ManagerId = employeeModel.ManagerId;            
                

                return RedirectToAction("DisplayEmployee");
            }
            return View();
        }
        //RETRIEVE THE EMPLOYEE DETAILS
        public ActionResult DisplayEmployee()
        {
            IEnumerable<Employee> employeeList = employeeBL.GetEmployee();
            return View(employeeList);
        }
        //DELETE THE EMPLOYEE DETAILS
        public ActionResult Delete(int id)
        {
            employeeBL.DeleteEmployee(id);
            return RedirectToAction("DisplayEmployee");
        }
        //EDIT THE EMPLOYEE DETAILS
        public ViewResult Edit(int id)
        {
            ViewBag.Departments = new SelectList(departmentBL.GetDepartment(), "DepartmentId", "DepartmentName");
            ViewBag.Managers = new SelectList(employeeBL.GetManager(), "ManagerId", "ManagerName");
            ViewBag.Designations = new SelectList(employeeBL.GetDesignation(), "DesignationId", "DesignationName");
            EmployeeModel employeeModel = new EmployeeModel();
            employee = employeeBL.GetEmployeeId(id);
            employeeModel.EmployeeId = employee.EmployeeId;
            employeeModel.EmployeeName = employee.EmployeeName;
            employeeModel.EmployeeAge = employee.EmployeeAge;
            employeeModel.EmployeeEmail = employee.EmployeeEmail;
            employeeModel.EmployeeGender = employee.EmployeeGender;
            employeeModel.EmployeePhoneNumber = employee.EmployeePhoneNumber;
            employeeModel.DesignationId = employee.DesignationId;
            employeeModel.DepartmentId = employee.DepartmentId;
            employeeModel.ManagerId = employee.ManagerId;
            return View(employeeModel);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Update(EmployeeModel employeemodel)
        {
            if (ModelState.IsValid)
            {
               
                employee.EmployeeName = employeemodel.EmployeeName;
                employee.EmployeeAge = employeemodel.EmployeeAge;
                employee.EmployeeEmail = employeemodel.EmployeeEmail;
                employee.EmployeePhoneNumber = employeemodel.EmployeePhoneNumber;
                employee.EmployeeGender = employeemodel.EmployeeGender;
                employee.DepartmentId = employeemodel.DepartmentId;
                employee.DesignationId = employeemodel.DesignationId;
                employee.ManagerId = employeemodel.ManagerId;
                employeeBL.UpdateEmployee(employee);
                return RedirectToAction("DisplayEmployee");

            }
            return View();
        }
        //ADD THE MANAGER DETAILS
        public ActionResult CreateManager()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult CreateManager(ManagerModel managerModel)
        {

            if (ModelState.IsValid)
            {
                Manager manager = new Manager();
                manager.ManagerName = managerModel.ManagerName;
                employeeBL.AddManager(manager);
                return RedirectToAction("DisplayManager");
            }
            return View();
        }
        //RETRIEVE THE MANAGER DETAILS
        public ActionResult DisplayManager()
        {
            IEnumerable<Manager> managerList = employeeBL.GetManager();
            return View(managerList);
        }
        //DELETE THE MANAGER DETAILS
        public ActionResult DeleteManager(int id)
        {
            employeeBL.DeleteManager(id);
            return RedirectToAction("DisplayManager");
        }
        //EDIT AND UPDATE THE MANAGER DETAILS
        public ViewResult EditManager(int id)
        {
            ManagerModel managerModel = new ManagerModel();
            Manager manager = employeeBL.GetManagerId(id);
            managerModel.ManagerId = manager.ManagerId;
            managerModel.ManagerName = manager.ManagerName;
            return View(managerModel);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult UpdateManager(ManagerModel managermodel)
        {
            if (ModelState.IsValid)
            {
                Manager manager = new Manager();
                manager.ManagerId = managermodel.ManagerId;
                manager.ManagerName = managermodel.ManagerName;
                employeeBL.UpdateManager(manager);
                return RedirectToAction("DisplayManager");

            }
            return View();
        }
        //ADD THE DESIGNATION 
        public ActionResult CreateDesignation()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult CreateDesignation(DesignationModel designationModel)
        {
            if (ModelState.IsValid)
            {
                Designation designation = new Designation();
                designation.DesignationName = designationModel.DesignationName;
                employeeBL.AddDesignation(designation);
                return RedirectToAction("DisplayDesignation");
            }
            return View();
        }
        //RETRIEVE THE DESIGNATION DETAILS
        public ActionResult DisplayDesignation()
        {
            IEnumerable<Designation> designationList = employeeBL.GetDesignation();
            return View(designationList);
        }
        //DELETE THE DESIGNATION DETAILS
        public ActionResult DeleteDesignation(int id)
        {
            employeeBL.DeleteDesignation(id);
            return RedirectToAction("DisplayDesignation");
        }
        //EDIT AND UPDATE THE DESIGNATION DETAILS
        public ViewResult EditDesignation(int id)
        {
            DesignationModel designationModel = new DesignationModel();
            Designation designation = employeeBL.GetDesignationId(id);
            designationModel.DesignationId = designation.DesignationId;
            designationModel.DesignationName = designation.DesignationName;
            return View(designationModel);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult UpdateDesignation(DesignationModel designationmodel)
        {
            if (ModelState.IsValid)
            {
                Designation designation = new Designation();
                designation.DesignationId = designationmodel.DesignationId;
                designation.DesignationName = designationmodel.DesignationName;
                employeeBL.UpdateDesignation(designation);
                return RedirectToAction("DisplayDesignation");
            }
            return View();
        }
        //Account creation for employee,admin,manager
        public ActionResult Account(EmployeeModel employeeModel)
        {
            Account account = new Account();
            account.EmployeeId = employeeBL.SetEmployeeId(employeeModel.EmployeeEmail);
            account.UserName = employeeModel.EmployeeEmail;
            account.Password = employeeBL.Password(employeeModel.EmployeeName, Convert.ToString(employeeModel.EmployeePhoneNumber));
            account.Role = employeeBL.Role(employeeModel.DesignationId);
            employeeBL.AddAccount(account);
            return View();
        }

    }
}