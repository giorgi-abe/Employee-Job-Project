using ApplicationDomainModels.Models;
using ApplicationDtos.ViewDtos;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApplicationUIServices
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<PhoneNumber, PhoneNubmerViewDto>().ReverseMap();
            CreateMap<Employee, EmployeeViewDto>().ReverseMap();

        }
    }
}
