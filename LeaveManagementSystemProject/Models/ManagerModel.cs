using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LeaveManagementSystemProject.Models
{
    public class ManagerModel
    {
        public int ManagerId { get; set; }
        [Required(ErrorMessage = "ManagerName is required")]
        [Display(Name = "Manager")]
        [RegularExpression("[a-zA-Z]*$", ErrorMessage = "Please Enter Valid Manager")]
        public string ManagerName { get; set; }
    }
}