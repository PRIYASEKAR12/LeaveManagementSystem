using LeaveManagementSystemDAL;
using LeaveManagementSystemEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagementSystemBL
{
    public class DepartmentBL
    {
        DepartmentRepository repository = new DepartmentRepository();
        public void AddDepartment(Department department)
        {
            repository.AddDepartmentList(department);
        }
        public IEnumerable<Department> GetDepartment()
        {           
            return repository.GetDepartment();
        }
    }
}
