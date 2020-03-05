using LeaveManagementSystemDAL;
using LeaveManagementSystemEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagementSystemBL
{
    public class EmployeeBL
    {
        EmployeeRepository employeeRepository = new EmployeeRepository();
        public void AddEmployee(Employee employee)
        {            
            employeeRepository.AddEmployeeList(employee);
        }
        public IEnumerable<Manager> GetManager()
        {
            return employeeRepository.GetManager();
        }
        public IEnumerable<Designation> GetDesignation()
        {           
            return employeeRepository.GetDesignation();
        }
        public IEnumerable<Employee> GetEmployee()
        {
            return employeeRepository.GetEmployee();
        }
        public void DeleteEmployee(int EmployeeId)
        {                                                                                                                                                                                                                                   
            employeeRepository.DeleteEmployee(EmployeeId);
        }
        public Employee GetEmployeeId(int EmployeeId)
        {
          return  employeeRepository.EditEmployee(EmployeeId);
        }
        public void UpdateEmployee(Employee employee)
        {
            employeeRepository.UpdateEmployee(employee);
        }
        public string Password(string EmployeeName,string EmployeePhoneNumber)
        {
            return EmployeeName.Substring(0, 3) + EmployeePhoneNumber.Substring(0, 3);
        }
        public void AddAccount(Account account)
        {
            employeeRepository.AddAccount(account);

        }

    }
}
