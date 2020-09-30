using EmployeeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAPI.Dtos
{
    public class PageDto
    {
        public int TotalItems { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
    }
}
