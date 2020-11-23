using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LeaveManagementSystemProject.Models
{
    public class DesignationModel
    {
        public int DesignationId { get; set; }
        [Required(ErrorMessage = "DesignationName is required")]
        [Display(Name = "Designation")]
        [RegularExpression("^[a-zA-Z][a-zA-Z\\s]+$", ErrorMessage = "Please Enter Valid Designation")]
        public string DesignationName { get; set; }
    }
}