using LeaveManagementSystemEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace LeaveManagementSystemProject.Models
{
    public class LeaveModel
    {
        [Key]
        public int LeaveId { get; set; }

        [Required(ErrorMessage = "Leave start date is required")]
        [Display(Name = "StartDate")]
        public long StartDate { get; set; }

        [Required(ErrorMessage = "Leave End date is required")]
        [Display(Name = "End Date")]
        public long EndDate { get; set; }
        [Required(ErrorMessage = "Leave type is required")]
        [Display(Name = "Leave Type")]
        public string LeaveType { get; set; }

        public int EmployeeId { get; set; }

        public string Status { get; set; }
        public string EmployeeName { get; set; }

    }
}