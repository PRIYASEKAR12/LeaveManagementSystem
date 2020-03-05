using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeaveManagementSystemEntity;

namespace LeaveManagementSystemDAL
{
    public class EmployeeRepository
    {

        public void AddEmployeeList(Employee employee)
        {
            using (DepartmentDbContext departmentContext = new DepartmentDbContext())
            {
                departmentContext.Employees.Add(employee);
                departmentContext.SaveChanges();
            }
        }
        public IEnumerable<Manager> GetManager()
        {
            using (DepartmentDbContext departmentContext = new DepartmentDbContext())
            {
                return departmentContext.Managers.ToList();
            }
        }
        public IEnumerable<Designation> GetDesignation()
        {
            DepartmentDbContext departmentContext = new DepartmentDbContext();
            return departmentContext.Designations.ToList();
        }
        public IEnumerable<Employee> GetEmployee()
        {
            DepartmentDbContext departmentContext = new DepartmentDbContext();
            return departmentContext.Employees.ToList();
        }
        public void DeleteEmployee(int EmployeeId)
        {
            using (DepartmentDbContext departmentContext = new DepartmentDbContext())
            {
                Employee employee = departmentContext.Employees.Find(EmployeeId);
                departmentContext.Employees.Remove(employee);
                departmentContext.SaveChanges();
            }
        }
        public void AddAccount(Account account)
        {
            using (DepartmentDbContext departmentContext = new DepartmentDbContext())
            {
                departmentContext.Accounts.Add(account);
                departmentContext.SaveChanges();
            }
        }
        public Employee EditEmployee(int EmployeeId)
        {
            using (DepartmentDbContext departmentContext = new DepartmentDbContext())
            {
              return  departmentContext.Employees.Find(EmployeeId);
            }

        }
        
        public void UpdateEmployee(Employee employee)
        {
            using (DepartmentDbContext departmentContext = new DepartmentDbContext())
            {
                departmentContext.Entry(employee).State = System.Data.Entity.EntityState.Modified;
                departmentContext.SaveChanges();
            }
        }
        public Account CheckLogin(Account account)
        {
            using (DepartmentDbContext departmentContext = new DepartmentDbContext())
            {
               Account user= departmentContext.Accounts.Where(u => u.UserName == account.UserName && u.Password == account.Password).SingleOrDefault();
                if(user!=null)
                {
                    return user;
                }
                else
                {
                    return null;
                }
            }
           
        }
    }
}
