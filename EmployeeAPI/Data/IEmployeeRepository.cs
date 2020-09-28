using EmployeeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAPI.Data
{
    interface IEmployeeRepository
    {
        bool SaveChanges();
        IEnumerable<Employee> GetAllEmployee();
        IEnumerable<Employee> GetEmployeeByTitle(string title);
        Employee GetEmployeeById(long id);
        void CreateEmployee(Employee tutorial);
        void UpdateEmployee(Employee tutorial);
        void DeleteEmploeey(Employee tutorial);
        void DeleteAllEmployee(IEnumerable<Employee> employee);
    }
}
