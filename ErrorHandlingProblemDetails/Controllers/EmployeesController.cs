using Microsoft.AspNetCore.Mvc;

namespace ErrorHandlingProblemDetails.Controllers;

[Route("api/companies/{companyId}/employees")]
[ApiController]
public class EmployeesController : ControllerBase
{
    private readonly IRepositoryManager _repository;
    private readonly ILogger<EmployeesController> _logger;
    private readonly IMapper _mapper;

    public EmployeesController(IRepositoryManager repository, ILogger<EmployeesController> logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetEmployeesForCompany(Guid companyId)
    {
        var company = _repository.Company.GetCompany(companyId, false);
        if (company == null)
        {
            _logger.LogInformation($"Company with id: {companyId} doesn't exist in the database.");
            return NotFound();
        }

        var employeesFromDb = _repository.Employee.GetEmployees(companyId, false);
        var employeesDto = _mapper.Map<IEnumerable<EmployeeDto>>(employeesFromDb);
        return Ok(employeesFromDb);
    }

    [HttpGet("{id}")]
    public IActionResult GetEmployeeForCompany(Guid companyId, Guid id)
    {
        var company = _repository.Company.GetCompany(companyId, false);
        if (company == null)
        {
            _logger.LogInformation($"Company with id: {companyId} doesn't exist in the database.");
            return NotFound();
        }

        var employeeDb = _repository.Employee.GetEmployee(companyId, id, false);
        if (employeeDb == null)
        {
            _logger.LogInformation($"Employee with id: {id} doesn't exist in the database.");
            return NotFound();
        }

        var employee = _mapper.Map<EmployeeDto>(employeeDb);
        return Ok(employee);
    }
}