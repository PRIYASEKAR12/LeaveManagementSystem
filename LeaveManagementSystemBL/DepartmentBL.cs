using LeaveManagementSystemDAL;
using LeaveManagementSystemEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagementSystemBL
{
    public interface IDepartmentBL
    {
        void AddDepartment(Department department);
        IEnumerable<Department> GetDepartment();
        void DeleteDepartment(int DepartmentId);
        Department GetDepartmentId(int DesignationId);
        void UpdateDepartment(Department department);
    }
    public class DepartmentBL:IDepartmentBL
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
        public void DeleteDepartment(int DepartmentId)
        {
            repository.DeleteDepartment(DepartmentId);
        }
        public Department GetDepartmentId(int DesignationId)
        {
            return repository.EditDepartment(DesignationId);
        }
        public void UpdateDepartment(Department department)
        {
           repository.UpdateDepartment(department);
        }
    }
}
