using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagementSystemEntity
{
    public class Department
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
        public int DepartmentId { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MaxLength(40)]
        public string DepartmentName { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
