using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagementSystemEntity
{
    public class Manager
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
        public int ManagerId { get; set; }
        [Required]
        [MaxLength(40)]
        [Index(IsUnique = true)]
        public string ManagerName { get; set;}
        public ICollection<Employee> Employees { get; set; }
    }
}
