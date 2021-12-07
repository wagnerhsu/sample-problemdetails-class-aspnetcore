using ErrorHandlingProblemDetails.Filters;
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

    [HttpGet("{id}", Name = "CompanyById")]
    public IActionResult GetCompany(Guid id)
    {
        var company = _repositoryManager.Company.GetCompany(id, false);
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

    [HttpPost]
    public IActionResult CreateCompany([FromBody] CreateCompanyDto company)
    {
        if (company == null)
        {
            _logger.LogError("CompanyForCreationDto object sent from client is null.");
            return BadRequest("CompanyForCreationDto object is null");
        }

        var companyEntity = _mapper.Map<Company>(company);
        _repositoryManager.Company.CreateCompany(companyEntity);
        _repositoryManager.Save();
        var companyToReturn = _mapper.Map<CompanyDto>(companyEntity);
        return CreatedAtRoute("CompanyById", new {id = companyToReturn.CompanyId}, companyToReturn);
    }

    [ServiceFilter(typeof(ValidateCompanyExistAttribute))]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCompany(Guid id)
    {
        var company = HttpContext.Items["company"] as Company;

        _repositoryManager.Company.DeleteCompany(company);
        await _repositoryManager.SaveAsync();
        return NoContent();
    }

    [ServiceFilter(typeof(ValidateCompanyExistAttribute))]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCompany(Guid id, [FromBody] UpdateCompanyDto company)
    {
        if (company == null)
        {
            _logger.LogError("CompanyForUpdateDto object sent from client is null.");
            return BadRequest("CompanyForUpdateDto object is null");
        }

        var companyEntity = HttpContext.Items["company"] as Company;

        _mapper.Map(company, companyEntity);
        await _repositoryManager.SaveAsync();
        return NoContent();
    }
}