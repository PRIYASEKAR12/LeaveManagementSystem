using LeaveManagementSystemDAL;
using LeaveManagementSystemEntity;

using System.Collections.Generic;

namespace LeaveManagementSystemBL
{
    public interface IEmployeeBL
    {
        void AddEmployee(Employee employee);
        IEnumerable<Employee> GetEmployee();
        void DeleteEmployee(int EmployeeId);
        Employee GetEmployeeId(int EmployeeId);
        void UpdateEmployee(Employee employee);
        void AddDesignation(Designation designation);
        IEnumerable<Designation> GetDesignation();
        void DeleteDesignation(int DesignationId);
        Designation GetDesignationId(int DesignationId);
        void UpdateDesignation(Designation designation);
        void AddManager(Manager manager);
        IEnumerable<Manager> GetManager();
        void DeleteManager(int ManagerId);
        Manager GetManagerId(int ManagerId);
        void UpdateManager(Manager manager);
        string Password(string EmployeeName, string EmployeePhoneNumber);
        void AddAccount(Account account);
        string Role(int EmployeeDesignation);
        int SetEmployeeId(string EmployeeEmail);
        int GetEmployeeIdByGmail(string Gmail);
        string GetEmployeeNameByGmail(string Gmail);
        int GetManagerIdByName(string Name);
        void AddLeaveRequest(Leave leaveRequest);
        List<Employee> GetEmployeeByManagerId(int id);
        List<Leave> GetLeaveRequestByManager(List<Employee> employee);
        string GetEmployeeNameById(int id);
        void AcceptRequest(int LeaveId);
        void DeclineRequest(int LeaveId);
    }
        public class EmployeeBL : IEmployeeBL
    {
        EmployeeRepository employeeRepository = new EmployeeRepository();
        public void AddEmployee(Employee employee)
        {            
            employeeRepository.AddEmployeeList(employee);
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
            return employeeRepository.EditEmployee(EmployeeId);
        }
        public void UpdateEmployee(Employee employee)
        {
            employeeRepository.UpdateEmployee(employee);
        }


        public void AddDesignation(Designation designation)
        {
            employeeRepository.AddDesignationList(designation);
        }
        public IEnumerable<Designation> GetDesignation()
        {
            return employeeRepository.GetDesignation();
        }
        public void DeleteDesignation(int DesignationId)
        {
            employeeRepository.DeleteManager(DesignationId);
        }
        public Designation GetDesignationId(int DesignationId)
        {
            return employeeRepository.EditDesignation(DesignationId);
        }
        public void UpdateDesignation(Designation designation)
        {
            employeeRepository.UpdateDesignation(designation);
        }

        public void AddManager(Manager manager)
        {
            employeeRepository.AddManagerList(manager);
        }
        public IEnumerable<Manager> GetManager()
        {
            return employeeRepository.GetManager();
        }              
        public void DeleteManager(int ManagerId)
        {
            employeeRepository.DeleteManager(ManagerId);
        }
        public Manager GetManagerId(int ManagerId)
        {
            return employeeRepository.EditManager(ManagerId);
        }
        public void UpdateManager(Manager manager)
        {
            employeeRepository.UpdateManager(manager);
        }
        
        public string Password(string EmployeeName,string EmployeePhoneNumber)
        {
            return EmployeeName.Substring(0, 3) + EmployeePhoneNumber.Substring(0, 3);
        }
        public void AddAccount(Account account)
        {
            employeeRepository.AddAccount(account);
        }
        public string Role(int EmployeeDesignation)
        {
            return employeeRepository.CheckRole(EmployeeDesignation);
        }
        public int SetEmployeeId(string EmployeeEmail)
        {
            return employeeRepository.SetEmployeeId(EmployeeEmail);
        }
        public int GetEmployeeIdByGmail(string Gmail)
        {
            return employeeRepository.GetEmployeeIdByGmail(Gmail);
        }
        public string GetEmployeeNameByGmail(string Gmail)
        {
            return employeeRepository.GetEmployeeNameByGmail(Gmail);
        }
        public void AddLeaveRequest(Leave leaveRequest)
        {
            employeeRepository.AddLeaveRequest(leaveRequest);
        }

        public int GetManagerIdByName(string Name)
        {
            return employeeRepository.GetManagerIdByName(Name);
        }
        public List<Employee> GetEmployeeByManagerId(int id)
        {
            return employeeRepository.GetEmployeeByManagerId(id);
        }
        public List<Leave> GetLeaveRequestByManager(List<Employee> employee)
        {
            return employeeRepository.GetLeaveRequestByManager(employee);
        }
        public string GetEmployeeNameById(int Id)
        {
            return employeeRepository.GetEmployeeNameById(Id);
        }
        public void AcceptRequest(int LeaveId)
        {
            employeeRepository.AcceptRequest(LeaveId);
        }
        public void DeclineRequest(int LeaveId)
        {
            employeeRepository.DeclineRequest(LeaveId);
        }
    }
}
