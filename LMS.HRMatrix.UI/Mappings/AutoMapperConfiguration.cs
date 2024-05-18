using AutoMapper;
using LMS.HRMatrix.Model;
using LMS.HRMatrix.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS.HRMatrix.Mappings
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
            {
                x.CreateMap<Employee, EmployeeViewModel>().ReverseMap();
            });
        }
    }
}