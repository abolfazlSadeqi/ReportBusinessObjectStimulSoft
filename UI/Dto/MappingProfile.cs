using AutoMapper;
using DAL.Model;
using Models;

namespace UI.Dto;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Add as many of these lines as you need to map your objects
        CreateMap<Employee, EmployeeDto>();
        CreateMap<EmployeeDto, Employee>();

    }
}

