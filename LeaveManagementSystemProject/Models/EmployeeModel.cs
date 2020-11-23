using LeaveManagementSystemEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LeaveManagementSystemProject.Models
{
    public class EmployeeModel
    {       
        public int EmployeeId { get; set;}
        [Required(ErrorMessage ="EmployeeName is required")]
        [Display(Name = "Name")]
        [RegularExpression("[a-zA-Z]*$", ErrorMessage = "Please Enter Valid Name")]
        public string EmployeeName { get; set; }

        [Required(ErrorMessage = "EmployeeAge is required")]
        [Display(Name = "Age")]
        public short EmployeeAge { get; set; }

        [Required(ErrorMessage = "Mobile Number is required")]
        [Display(Name = "PhoneNumber")]
        [RegularExpression("[6-9][0-9]{9}$", ErrorMessage = "Please Enter Valid Mobile Number")]
        public long EmployeePhoneNumber { get; set; }

        [Required(ErrorMessage = "Email Address is required")]
        [Display(Name = "EmailId")]
        [RegularExpression(@"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$",ErrorMessage = "Please Enter Correct Email Address")]
        public string EmployeeEmail { get; set; }

        [Required(ErrorMessage = "gender is required")]
        [Display(Name = "Gender")]
        public string EmployeeGender { get; set; }

        [Required(ErrorMessage = "Manager is required")]
        
        public int ManagerId { get; set; }
        public Manager Manager { get; set; }
        [Required(ErrorMessage = "Designation is required")]
        public int DesignationId { get; set; }
        public Designation Designation { get; set; }
        [Required(ErrorMessage = "Department is required")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}