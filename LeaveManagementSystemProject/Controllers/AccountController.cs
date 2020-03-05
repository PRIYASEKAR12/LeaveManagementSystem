using LeaveManagementSystemProject.Models;
using LeaveManagementSystemEntity;
using LeaveManagementSystemDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeaveManagementSystemProject.Controllers
{
    public class AccountController : Controller
    {
        EmployeeRepository repository;
        // GET: Login
        
        [ActionName("Login")]
        public ActionResult Login_Get()
        {
            return View();
        }
        [HttpPost]
        [ActionName("Login")]
        public ActionResult Login_Post(AccountModel account)
        {
            Account accountEntity = new Account()
            {
                UserName = account.UserName,
                Password = account.Password,
            };
            repository = new EmployeeRepository();
            Account checkRole = repository.CheckLogin(accountEntity);
            if(checkRole.Role=="Admin")
            {
                return RedirectToAction("CreateEmployee","Home");
            }
            else if(checkRole.Role=="User")
            {
                return RedirectToAction("Display","Home");
            }


            return View();
        }



    }
}