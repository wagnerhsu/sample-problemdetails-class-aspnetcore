namespace ErrorHandlingProblemDetails.Infrastructure;

public class CompanyRepository: RepositoryBase<Company>,ICompanyRepository
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
}