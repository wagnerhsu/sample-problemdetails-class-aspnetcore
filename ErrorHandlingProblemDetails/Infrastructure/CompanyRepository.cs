using Microsoft.EntityFrameworkCore;

namespace ErrorHandlingProblemDetails.Infrastructure;

public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
{
    public CompanyRepository(AppDbContext repositoryContext) : base(repositoryContext)
    {
    }

    public IEnumerable<Company> GetAllCompanies(bool trackChanges)
    {
        return FindAll(trackChanges).OrderBy(c => c.Name).ToList();
    }

    public Company GetCompany(Guid companyId, bool trackChanges)
    {
        return FindByCondition(c => c.CompanyId.Equals(companyId), trackChanges).SingleOrDefault();
    }

    public async Task<IEnumerable<Company>> GetAllCompaniesAsync(bool trackChanges)
    {
        return await FindAll(trackChanges).OrderBy(c => c.Name).ToListAsync();
    }

    public async Task<Company> GetCompanyAsync(Guid companyId, bool trackChanges)
    {
        return await FindByCondition(c => c.CompanyId.Equals(companyId), trackChanges).SingleOrDefaultAsync();
    }

    public async Task<IEnumerable<Company>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges)
    {
        return await FindByCondition(x => ids.Contains(x.CompanyId), trackChanges).ToListAsync();
    }

    public void CreateCompany(Company company)
    {
        Create(company);
    }

    public void DeleteCompany(Company company)
    {
        Delete(company);
    }
}