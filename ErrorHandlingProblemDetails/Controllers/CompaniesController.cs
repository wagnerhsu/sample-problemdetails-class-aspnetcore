using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ErrorHandlingProblemDetails.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CompaniesController : ControllerBase
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly ILogger<CompaniesController> _logger;
    private readonly IMapper _mapper;

    public CompaniesController(IRepositoryManager repositoryManager, ILogger<CompaniesController> logger,
        IMapper mapper)
    {
        _repositoryManager = repositoryManager;
        _logger = logger;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetCompanies()
    {
        var companies = _repositoryManager.Company.GetAllCompanies(false);
        var companiesDto = _mapper.Map<IEnumerable<CompanyDto>>(companies);
        return Ok(companiesDto);
    }

    [HttpGet("{id}")]
    public IActionResult GetCompany(Guid id)
    {
        var company = _repositoryManager.Company.GetCompany(id, trackChanges: false);
        if (company == null)
        {
            _logger.LogInformation($"Company with id: {id} doesn't exist in the database.");
            return NotFound();
        }
        else
        {
            var companyDto = _mapper.Map<CompanyDto>(company);
            return Ok(companyDto);
        }
    }
}