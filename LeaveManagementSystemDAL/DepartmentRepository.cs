using LeaveManagementSystemEntity;
using System.Collections.Generic;
using System.Linq;

namespace LeaveManagementSystemDAL
{
    public class DepartmentRepository
    {
        public void AddDepartmentList(Department department)
        {
            LeaveDBContext departmentContext = new LeaveDBContext();
            departmentContext.Departments.Add(department);
            departmentContext.SaveChanges();
        }
        public IEnumerable<Department> GetDepartment()
        {
            LeaveDBContext departmentContext = new LeaveDBContext();
            return departmentContext.Departments.ToList();
        }
        public void DeleteDepartment(int DepartmentId)
        {
            using (LeaveDBContext departmentContext = new LeaveDBContext())
            {
                Department department = departmentContext.Departments.Find(DepartmentId);
                departmentContext.Departments.Remove(department);
                departmentContext.SaveChanges();
            }
        }
        public Department EditDepartment(int DepartmentId)
        {
            using (LeaveDBContext departmentContext = new LeaveDBContext())
            {
                return departmentContext.Departments.Find(DepartmentId);
            }
        }
        public void UpdateDepartment(Department department)
        {
            using (LeaveDBContext departmentContext = new LeaveDBContext())
            {
                departmentContext.Entry(department).State = System.Data.Entity.EntityState.Modified;
                departmentContext.SaveChanges();
            }
        }

    }
}
