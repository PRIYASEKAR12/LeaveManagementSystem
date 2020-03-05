using LeaveManagementSystemEntity;
using System.Collections.Generic;
using System.Linq;

namespace LeaveManagementSystemDAL
{
    public class DepartmentRepository
    {
        public void AddDepartmentList(Department department)
        {
            DepartmentDbContext departmentContext = new DepartmentDbContext();
            departmentContext.Departments.Add(department);
            departmentContext.SaveChanges();
        }
        public IEnumerable<Department> GetDepartment()
        {
            DepartmentDbContext departmentContext = new DepartmentDbContext();
            return departmentContext.Departments.ToList();
        }
    }
}
