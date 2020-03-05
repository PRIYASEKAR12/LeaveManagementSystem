using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LeaveManagementSystemProject.Models
{
    public class DepartmentModel
    {
        [Required]
        public string DepartmentName { get; set; }
    }
}