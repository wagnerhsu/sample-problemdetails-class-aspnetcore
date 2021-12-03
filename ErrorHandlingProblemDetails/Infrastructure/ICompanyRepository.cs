

namespace ErrorHandlingProblemDetails.Infrastructure;

public interface ICompanyRepository
{
    IEnumerable<Company> GetAllCompanies(bool trackChanges); 
    Company GetCompany(Guid companyId, bool trackChanges); 
}