using EmployeeAPI.Models;
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

        public void CreateEmployee(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee));
            }
            _context.Employees.Add(employee);
        }

        public void DeleteAllEmployee(IEnumerable<Employee> employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee));
            }
            _context.Employees.RemoveRange(employee);
        }

        public void DeleteEmploeey(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee));
            }
            _context.Employees.Remove(employee);
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return _context.Employees.ToList();
        }

        public Employee GetEmployeeById(long id)
        {
            return _context.Employees.FirstOrDefault(k => k.EmployeeId == id);
        }

        public IEnumerable<Employee> GetEmployeeByTitle(string title)
        {
            return _context.Employees.Where(employee => employee.Name == title).ToList();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateEmployee(Employee employee)
        {
            //throw new NotImplementedException();
        }
    }
}
