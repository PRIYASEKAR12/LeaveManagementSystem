using LeaveManagementSystemBL;
using System.Web.Mvc;
using System.Collections;
using LeaveManagementSystemEntity;
using System.Collections.Generic;
using LeaveManagementSystemProject.Models;

namespace LeaveManagementSystemProject.Controllers
{
    public class ManagerController : Controller
    {
        IEmployeeBL employeeBL;
        public ManagerController()
        {
            employeeBL = new EmployeeBL();
        }
        public ActionResult Index()
        {
            return View();
        }
        //manager view the leave request of an employees
        public ActionResult DisplayRequest()
        {
            string name = employeeBL.GetEmployeeNameByGmail(User.Identity.Name);
            int id = employeeBL.GetManagerIdByName(name);

            List<Employee> employee = employeeBL.GetEmployeeByManagerId(id);
            List<Leave> leaves = employeeBL.GetLeaveRequestByManager(employee);
            List<LeaveModel> leaveModels = new List<LeaveModel>();
            foreach (Leave leave in leaves)
            {
                var leaveModel = AutoMapper.Mapper.Map<Leave, LeaveModel>(leave);
                leaveModel.EmployeeName = employeeBL.GetEmployeeNameById(leaveModel.EmployeeId);
                leaveModels.Add(leaveModel);
            }
            return View(leaveModels);
        }
        //If manager accept the leave request
        public ActionResult AcceptRequest(LeaveModel Leave)
        {
            employeeBL.AcceptRequest(Leave.LeaveId);
            return RedirectToAction("DisplayRequest");
        }
        //If manager decline the leave request
        public ActionResult DeclineRequest(int LeaveId)
        {
            employeeBL.DeclineRequest(LeaveId);
            return RedirectToAction("DisplayRequest");
        }
    }
}