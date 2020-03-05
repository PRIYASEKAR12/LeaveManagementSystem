using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagementSystemEntity
{
    public class Employee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public short EmployeeAge { get; set; }
        public long EmployeePhoneNumber { get; set;}
        public string EmployeeEmail { get; set; }
        public int ManagerId { get; set; }
        public Manager Manager { get; set;}
        public int DesignationId { get; set; }
        public Designation Designation {get;set;}
        public int DepartmentId { get; set; }
        public Department Department { get; set;}
    }
}
