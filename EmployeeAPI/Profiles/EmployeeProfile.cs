using AutoMapper;
using EmployeeAPI.Dtos;
using EmployeeAPI.Models;
using EmployeeAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAPI.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<PageListViewModel<Employee>, PageDto>();
        }
    }
}
