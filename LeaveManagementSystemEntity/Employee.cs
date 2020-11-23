using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagementSystemEntity
{
    public class Employee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
        public int EmployeeId { get; set; }
        [Required]
        [MaxLength(40)]
        public string EmployeeName { get; set; }
        [Required]
        public short EmployeeAge { get; set; }
        [Required]
        [Index(IsUnique =true)]
        public long EmployeePhoneNumber { get; set; }
        [Required]
        [Index(IsUnique = true)]
        [MaxLength(255)]
        public string EmployeeEmail { get; set; }
        [Required]
        [MaxLength(6)]
        public string EmployeeGender { get; set; }
        public int ManagerId { get; set; }
        public virtual Manager Manager { get; set;}
        public int DesignationId { get; set; }
        public virtual Designation Designation {get;set;}
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set;}
      
    }
}
