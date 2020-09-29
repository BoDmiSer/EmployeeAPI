using EmployeeAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAPI.Data
{
    public class MySQLEmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationUserDbContext _context;

        public MySQLEmployeeRepository(ApplicationUserDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<Employee>> CreateEmployee(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee));
            }
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return  employee;

        }

        public void DeleteAllEmployee(IEnumerable<Employee> employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee));
            }
            _context.Employees.RemoveRange(employee);
        }

        public async Task<ActionResult<Employee>> DeleteEmploeey(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee));
            }
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return employee;
        }

        public async Task<ActionResult<IEnumerable<Employee>>> GetAllEmployee()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<ActionResult<Employee>> GetEmployeeById(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            return employee;
        }

        public IEnumerable<Employee> GetEmployeeByTitle(string title)
        {
            return _context.Employees.Where(employee => employee.Name == title).ToList();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public async Task<IActionResult> UpdateEmployee(Employee employee)
        {
            _context.Entry(employee).State = EntityState.Modified;
           await _context.SaveChangesAsync();
            return null;
        }
    }
}
