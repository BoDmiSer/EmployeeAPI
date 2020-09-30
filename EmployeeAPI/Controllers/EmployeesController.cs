using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeAPI.Data;
using EmployeeAPI.Models;
using Microsoft.AspNetCore.Authorization;
using EmployeeAPI.Authentication;
using EmployeeAPI.ViewModel;
using AutoMapper;
using EmployeeAPI.Dtos;

namespace EmployeeAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationUserDbContext _context;
        private readonly IEmployeeRepository _repo;
        private readonly IMapper _mapper;


        public EmployeesController(IEmployeeRepository repository, ApplicationUserDbContext context, IMapper mapper)
        {
            _repo = repository;
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Employees
        [HttpGet]
        public ActionResult<PageDto> GetEmployees(int page = 0, int size = 4)
        {
            PageListViewModel<Employee> pageListView;
            pageListView = PageListViewModel<Employee>.Create(_context.Employees.ToList(), page, size);

            return Ok(_mapper.Map<PageDto>(pageListView));
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await _repo.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }
            return employee;
        }

        // PUT: api/Employees/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[Authorize(Roles = UserRoles.Admin + "," + UserRoles.Moderator)]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return BadRequest();
            }
            try
            {
                await _repo.UpdateEmployee(employee);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        // POST: api/Employees
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            var getemployee = await _repo.CreateEmployee(employee);
            return CreatedAtAction("GetEmployee", new { id = employee.EmployeeId }, employee);
        }

        // DELETE: api/Employees/5
        //[Authorize(Roles = UserRoles.Admin)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            return await _repo.DeleteEmploeey(id);
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.EmployeeId == id);
        }
    }
}
