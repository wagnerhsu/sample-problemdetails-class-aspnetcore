namespace ErrorHandlingProblemDetails.Profiles;

public class CompanyProfile : Profile
{
    public CompanyProfile()
    {
        CreateMap<Company, CompanyDto>()
            .ForMember(dest => dest.FullAddress,
                opt => opt.MapFrom(src => string.Join(' ', src.Address, src.Country)));
        CreateMap<Employee, EmployeeDto>();
        CreateMap<CreateCompanyDto, Company>();
        CreateMap<CreateEmployeeDto, Employee>();
        CreateMap<UpdateEmployeeDto, Employee>();
        CreateMap<UpdateCompanyDto, Company>();
    }
}