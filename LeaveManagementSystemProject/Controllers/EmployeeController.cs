using System;
using System.Collections.Generic;
using System.Linq;
using LeaveManagementSystemProject.Models;
using LeaveManagementSystemEntity;
using System.Web.Mvc;
using LeaveManagementSystemBL;

namespace LeaveManagementSystemProject.Controllers
{
    public class EmployeeController : Controller
    {
        IEmployeeBL employeeBL;
        public EmployeeController()
        {
            employeeBL = new EmployeeBL();
        }
        // GET: Employee
        public ActionResult Index()
        { 

            return View();
        }
        //Employee give a leave request to their manager
        public ActionResult LeaveRequest()
        {
            LeaveModel leaveModel = new LeaveModel();
            leaveModel.EmployeeId = employeeBL.GetEmployeeIdByGmail(User.Identity.Name);
            return View(leaveModel);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult LeaveRequest(LeaveModel leaveModel)
        {
            leaveModel.Status = "Pending";
            var leaveRequest = AutoMapper.Mapper.Map<LeaveModel, Leave>(leaveModel);
            employeeBL.AddLeaveRequest(leaveRequest);
            return View();
        }

    }
}