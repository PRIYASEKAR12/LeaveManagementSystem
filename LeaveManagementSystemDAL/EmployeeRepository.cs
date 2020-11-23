using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Threading.Tasks;
using LeaveManagementSystemEntity;
using System.Security.Cryptography.X509Certificates;

namespace LeaveManagementSystemDAL
{
    public class EmployeeRepository
    {
        public void AddEmployeeList(Employee employee)
        {
            using (LeaveDBContext departmentContext = new LeaveDBContext())
            {
                using (var trans = departmentContext.Database.BeginTransaction())
                {
                    try
                    {
                        departmentContext.Employees.Add(employee);
                        departmentContext.SaveChanges();
                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        Console.WriteLine(ex.InnerException);
                    }
                }
            }
        }
        public IEnumerable<Employee> GetEmployee()
        {
            using (LeaveDBContext departmentContext = new LeaveDBContext())
            {
                return departmentContext.Employees.Include("Designation").Include("Department").Include("Manager").ToList();
            }
        }
        public void DeleteEmployee(int EmployeeId)
        {
            using (LeaveDBContext departmentContext = new LeaveDBContext())
            {
                Employee employee = departmentContext.Employees.Find(EmployeeId);
                departmentContext.Employees.Remove(employee);
                departmentContext.SaveChanges();
            }
        }
        public Employee EditEmployee(int EmployeeId)
        {
            using (LeaveDBContext departmentContext = new LeaveDBContext())
            {
                return departmentContext.Employees.Find(EmployeeId);
            }
        }
        public void UpdateEmployee(Employee employee)
        {
            using (LeaveDBContext departmentContext = new LeaveDBContext())
            {
                departmentContext.Entry(employee).State = System.Data.Entity.EntityState.Modified;
                departmentContext.SaveChanges();
            }
        }
        public void AddDesignationList(Designation designation)
        {
            using (LeaveDBContext departmentContext = new LeaveDBContext())
            {
                departmentContext.Designations.Add(designation);
                departmentContext.SaveChanges();
            }
        }
        public IEnumerable<Designation> GetDesignation()
        {
            LeaveDBContext departmentContext = new LeaveDBContext();
            return departmentContext.Designations.ToList();
        }



        public void DeleteDesignation(int DesignationId)
        {
            using (LeaveDBContext departmentContext = new LeaveDBContext())
            {
                Designation designation = departmentContext.Designations.Find(DesignationId);
                departmentContext.Designations.Remove(designation);
                departmentContext.SaveChanges();
            }
        }
        public Designation EditDesignation(int DesignationId)
        {
            using (LeaveDBContext departmentContext = new LeaveDBContext())
            {
                return departmentContext.Designations.Find(DesignationId);
            }
        }
        public void UpdateDesignation(Designation designation)
        {
            using (LeaveDBContext departmentContext = new LeaveDBContext())
            {
                departmentContext.Entry(designation).State = System.Data.Entity.EntityState.Modified;
                departmentContext.SaveChanges();
            }
        }
        public void AddManagerList(Manager manager)
        {
            using (LeaveDBContext departmentContext = new LeaveDBContext())
            {
                SqlParameter sql = new SqlParameter("@ManagerName", manager.ManagerName);
                int count = departmentContext.Database.ExecuteSqlCommand("Manager_Insert @ManagerName", sql);
                //departmentContext.Managers.Add(manager);
                departmentContext.SaveChanges();
            }
        }

        public IEnumerable<Manager> GetManager()
        {
            using (LeaveDBContext departmentContext = new LeaveDBContext())
            {
                return departmentContext.Managers.ToList();
            }
        }

        public void DeleteManager(int ManagerId)
        {
            using (LeaveDBContext departmentContext = new LeaveDBContext())
            {
                SqlParameter sql = new SqlParameter("@ManagerId", ManagerId);
                int count = departmentContext.Database.ExecuteSqlCommand("Manager_Delete @ManagerId", sql);
                //Employee employee = departmentContext.Employees.Find(ManagerId);
                //departmentContext.Employees.Remove(employee);
                departmentContext.SaveChanges();
            }
        }
        public Manager EditManager(int ManagerId)
        {
            using (LeaveDBContext departmentContext = new LeaveDBContext())
            {
                return departmentContext.Managers.Find(ManagerId);
            }

        }
        public void UpdateManager(Manager manager)
        {
            using (LeaveDBContext departmentContext = new LeaveDBContext())
            {
                SqlParameter sql = new SqlParameter("@ManagerId", manager.ManagerId);
                SqlParameter sqlName = new SqlParameter("@ManagerName", manager.ManagerName);
                var data = departmentContext.Database.ExecuteSqlCommand("Manager_Update @ManagerId,@ManagerName", sql, sqlName);
                //int count = departmentContext.Database.ExecuteSqlCommand("Manager_Update @ManagerId", sql);
                // departmentContext.Entry(manager).State = System.Data.Entity.EntityState.Modified;
                departmentContext.SaveChanges();
            }
        }
        public void AddAccount(Account account)
        {
            using (LeaveDBContext departmentContext = new LeaveDBContext())
            {
                departmentContext.Accounts.Add(account);
                departmentContext.SaveChanges();
            }
        }
        public int SetEmployeeId(string EmployeeEmail)
        {
            using (LeaveDBContext departmentContext = new LeaveDBContext())
            {
                Employee employee = departmentContext.Employees.Where(x => x.EmployeeEmail == EmployeeEmail).SingleOrDefault();
                return employee.EmployeeId;

            }
        }
        public string CheckRole(int EmployeeDesignation)
        {
            if (EmployeeDesignation == 1)
            {
                return "admin";
            }
            else if (EmployeeDesignation == 2)
            {
                return "Employee";
            }
            else if (EmployeeDesignation == 3)
            {
                return "Manager";
            }
            return "";
        }

        public Account CheckLogin(Account account)
        {
            using (LeaveDBContext departmentContext = new LeaveDBContext())
            {
                Account user = departmentContext.Accounts.Where(u => u.UserName == account.UserName && u.Password == account.Password).SingleOrDefault();
                if (user != null)
                {
                    return user;
                }
                else
                {
                    return null;
                }
            }

        }

        public int GetEmployeeIdByGmail(string Gmail)
        {
            using (LeaveDBContext departmentContext = new LeaveDBContext())
            {
                Employee employee = departmentContext.Employees.Where(u => u.EmployeeEmail == Gmail).SingleOrDefault();
                return employee.EmployeeId;
            }
        }

        public string GetEmployeeNameByGmail(string Gmail)
        {
            using (LeaveDBContext departmentContext = new LeaveDBContext())
            {
                Employee employee = departmentContext.Employees.Where(u => u.EmployeeEmail == Gmail).SingleOrDefault();
                return employee.EmployeeName;
            }
        }
        public void AddLeaveRequest(Leave leaveRequest)
        {
            using (LeaveDBContext departmentContext = new LeaveDBContext())
            {
                departmentContext.LeaveRequest.Add(leaveRequest);
                departmentContext.SaveChanges();
            }
        }
        public int GetManagerIdByName(string Name)
        {
            using (LeaveDBContext departmentContext = new LeaveDBContext())
            {
                Manager manager = departmentContext.Managers.Where(u => u.ManagerName == Name).FirstOrDefault();
                return manager.ManagerId;
            }
        }
        public List<Employee> GetEmployeeByManagerId(int id)
        {
            using (LeaveDBContext departmentContext = new LeaveDBContext())
            {
                return departmentContext.Employees.Where(u => u.ManagerId == id).ToList();
            }
        }
        public List<Leave> GetLeaveRequestByManager(List<Employee> employee)
        {
            using (LeaveDBContext departmentContext = new LeaveDBContext())
            {
                List<Leave> list = new List<Leave>();
                foreach (Employee details in employee)
                {
                    List<Leave> leave = departmentContext.LeaveRequest.Where(u => u.EmployeeId == details.EmployeeId && u.Status == "Pending").ToList();
                    foreach (Leave leaves in leave)
                    {
                        list.Add(leaves);
                    }
                }
                return list;
            }
        }
        public string GetEmployeeNameById(int Id)
        {
            using (LeaveDBContext departmentContext = new LeaveDBContext())
            {
                Employee employee = departmentContext.Employees.Where(u => u.EmployeeId == Id).SingleOrDefault();
                return employee.EmployeeName;
            }
        }
        public void AcceptRequest(int LeaveId)
        {
            using (LeaveDBContext departmentContext = new LeaveDBContext())
            {
                var leaveRequest = departmentContext.LeaveRequest.Find(LeaveId);
                leaveRequest.Status = "Approved";
                departmentContext.SaveChanges();
            }
        }
        public void DeclineRequest(int LeaveId)
        {
            using (LeaveDBContext departmentContext = new LeaveDBContext())
            {
                var leaveRequest = departmentContext.LeaveRequest.Find(LeaveId);
                leaveRequest.Status = "Declined";
                departmentContext.SaveChanges();
            }
        }
    }
}
