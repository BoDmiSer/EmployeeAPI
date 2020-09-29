using EmployeeAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI.Data
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationUserDbContext _sessionRepository;

        public Task<ActionResult<Employee>> CreateEmployee(Employee tutorial)
        {
            throw new NotImplementedException();
        }

        public void DeleteAllEmployee(IEnumerable<Employee> employee)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<Employee>> DeleteEmploeey(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ActionResult<IEnumerable<Employee>>> GetAllEmployee()
        {
            var employees =  new List<Employee>()
            {
                //new Employee(0,"Дмитрий","Богдагнов","Сергеевич",DateTime.Today,"Воронеж","89515511759","bogdanov_s69@mail.ru")
            };
            _sessionRepository.Employees.AddRange(employees);
            await _sessionRepository.SaveChangesAsync();
            return employees;
        }

        public Task<ActionResult<Employee>> GetEmployeeById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> GetEmployeeByTitle(string title)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> UpdateEmployee(Employee tutorial)
        {
            throw new NotImplementedException();
        }
    }
}
