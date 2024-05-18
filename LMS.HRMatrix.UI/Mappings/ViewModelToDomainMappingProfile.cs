using AutoMapper;
using LMS.HRMatrix.Model;
using LMS.HRMatrix.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS.HRMatrix.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }
        
        public static void Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EmployeeViewModel, Employee>();
            });

            IMapper mapper = config.CreateMapper();

        }
    }
}