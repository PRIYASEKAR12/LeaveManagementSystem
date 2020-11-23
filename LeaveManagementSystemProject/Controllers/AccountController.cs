using LeaveManagementSystemProject.Models;
using LeaveManagementSystemEntity;
using LeaveManagementSystemDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;


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
        public ActionResult Login_Post(AccountModel account)                  //for login operation
        {
            Account accountEntity = new Account()
            {
                UserName = account.UserName,
                Password = account.Password,
            };
            repository = new EmployeeRepository();
            Account checkRole = repository.CheckLogin(accountEntity);
            if (checkRole != null)
            {                                
                    FormsAuthentication.SetAuthCookie(checkRole.UserName, false);
                    var authTicket = new FormsAuthenticationTicket(1, checkRole.UserName, DateTime.Now, DateTime.Now.AddMinutes(20), false, checkRole.Role);
                    string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                    var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                    HttpContext.Response.Cookies.Add(authCookie);
                    return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.message = "UserId & Password is incorrect";
            }
            return View();
        }
        public ActionResult LogOff()                           //for log off operation
        {
           
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        
    }
}