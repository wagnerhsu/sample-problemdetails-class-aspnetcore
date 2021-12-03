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

    [HttpDelete("{id}")]
    public IActionResult DeleteCompany(Guid id)
    {
        var company = _repositoryManager.Company.GetCompany(id, false);
        if (company == null)
        {
            _logger.LogInformation($"Company with id: {id} doesn't exist in the database.");
            return NotFound();
        }

        _repositoryManager.Company.DeleteCompany(company);
        _repositoryManager.Save();
        return NoContent();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateCompany(Guid id, [FromBody] UpdateCompanyDto company)
    {
        if (company == null)
        {
            _logger.LogError("CompanyForUpdateDto object sent from client is null.");
            return BadRequest("CompanyForUpdateDto object is null");
        }

        var companyEntity = _repositoryManager.Company.GetCompany(id, trackChanges: true);
        if (companyEntity == null)
        {
            _logger.LogInformation($"Company with id: {id} doesn't exist in the database.");
            return NotFound();
        }

        _mapper.Map(company, companyEntity);
        _repositoryManager.Save();
        return NoContent();
    }
}