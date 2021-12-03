namespace ErrorHandlingProblemDetails.Dtos;

public class UpdateCompanyDto
{
    public string Name { get; set; }
    public string Address { get; set; }
    public string Country { get; set; }
    public IEnumerable<UpdateEmployeeDto> Employees { get; set; }
}