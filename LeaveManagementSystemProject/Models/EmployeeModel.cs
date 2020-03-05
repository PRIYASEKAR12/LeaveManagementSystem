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
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public short EmployeeAge { get; set; }
        public long EmployeePhoneNumber { get; set; }
        public string EmployeeEmail { get; set; }
        public int ManagerId { get; set; }
        public Manager Manager { get; set; }
        public int DesignationId { get; set; }
        public Designation Designation { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}