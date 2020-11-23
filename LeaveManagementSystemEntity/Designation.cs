using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagementSystemEntity
{
    public class Designation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
        public int DesignationId { get; set; }
        [Required]
        [MaxLength(40)]
        [Index(IsUnique = true)]
        public string DesignationName { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
