using LeaveManagementSystemBL;
using LeaveManagementSystemEntity;
using LeaveManagementSystemProject.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace LeaveManagementSystemProject.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        
        public ActionResult Index()
        {
            return View();
        }
        

    }

}