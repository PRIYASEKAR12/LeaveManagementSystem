using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LeaveManagementSystemProject.Models
{
    public class DepartmentModel
    {
        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "DepartmentName is required")]
        [Display(Name = "Department")]
        [RegularExpression("^[a-zA-Z0-9 ,.'@]+$", ErrorMessage = "Please Enter Valid Department")]
        public string DepartmentName { get; set; }
    }
}