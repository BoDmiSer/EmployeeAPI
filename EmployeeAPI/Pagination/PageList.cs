using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAPI.Pagination
{
    public class PageList<T> : List<T>
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }

        public bool HasPreviesPage => CurrentPage > 1;
        public bool HasNextPage => CurrentPage < TotalPages;
        public int? NextPageNumber => HasNextPage ? CurrentPage + 1 : (int?)null;
        public int? PreviesPAgeNumber => HasPreviesPage ? CurrentPage - 1 : (int?)null;

        public PageList(List<T> items, int count, int pageNumber, int pagesize)
        {
            TotalItems = count;
            PageSize = pagesize;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pagesize);
            AddRange(items);
        }

        public static PageList<T> Create(IEnumerable<T> source, int pageNumber, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageNumber) * pageSize).Take(pageSize).ToList();
            return new PageList<T>(items, count, pageNumber, pageSize);
        }
    }
}
