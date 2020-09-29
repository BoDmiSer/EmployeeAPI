using EmployeeAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAPI.Data
{
    public interface IEmployeeRepository
    {
        bool SaveChanges();
        Task<ActionResult<IEnumerable<Employee>>> GetAllEmployee();
        IEnumerable<Employee> GetEmployeeByTitle(string title);
        Task<ActionResult<Employee>> GetEmployeeById(int id);
        Task<ActionResult<Employee>> CreateEmployee(Employee tutorial);
        Task<IActionResult> UpdateEmployee(Employee tutorial);
        Task<ActionResult<Employee>> DeleteEmploeey(int id);
        void DeleteAllEmployee(IEnumerable<Employee> employee);
    }
}
