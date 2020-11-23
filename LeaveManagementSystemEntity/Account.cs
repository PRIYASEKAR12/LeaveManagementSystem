using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagementSystemEntity
{
    public class Account
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
        public int AccountId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
 
       
    }
}
