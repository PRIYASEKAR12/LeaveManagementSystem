//using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagementSystemEntity
{
    public class Leave
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
        public int LeaveId { get; set; }
        public long StartDate { get; set; }
        public long EndDate { get; set; }
        public string LeaveType { get; set; }
        public string Status { get; set; }
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

    }
}
