

namespace ErrorHandlingProblemDetails.Infrastructure;

public interface ICompanyRepository
{
    IEnumerable<Company> GetAllCompanies(bool trackChanges); 
    Company GetCompany(Guid companyId, bool trackChanges);
    Task<IEnumerable<Company>> GetAllCompaniesAsync(bool trackChanges);
    Task<Company> GetCompanyAsync(Guid companyId, bool trackChanges);
    Task<IEnumerable<Company>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);
    void CreateCompany(Company company); 
    void DeleteCompany(Company company); 
}