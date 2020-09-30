using EmployeeAPI.Pagination;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAPI.ViewModel
{
    public class PageListViewModel<T>
    {
        public int TotalItems { get; set; }
        public IEnumerable<T> Employees { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }

        private PageListViewModel(int TotalItems, IEnumerable<T> Employees, int CurrentPage, int TotalPages)
        {
            this.TotalItems = TotalItems;
            this.Employees = Employees;
            this.CurrentPage = CurrentPage;
            this.TotalPages = TotalPages;
        }
        public static PageListViewModel<T> Create(IEnumerable<T> Employee, int page, int size)
        {
            PageList<T> PaginationTutorials;
            PaginationTutorials = PageList<T>.Create(Employee, page, size);
            return new PageListViewModel<T>(PaginationTutorials.TotalItems, PaginationTutorials, PaginationTutorials.CurrentPage, PaginationTutorials.TotalPages);
        }
    }
}
