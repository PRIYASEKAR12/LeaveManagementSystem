using System.ComponentModel.DataAnnotations;
namespace LeaveManagementSystemEntity
{
    public class Designation
    {
        [Key]
        public int DesignationId { get; set; }
        public string DesignationName { get; set; }
    }
}
