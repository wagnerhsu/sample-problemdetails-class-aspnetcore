using ErrorHandlingProblemDetails.Data;

namespace ErrorHandlingProblemDetails.Infrastructure;

public class RepositoryManager : IRepositoryManager
{
    private readonly AppDbContext _repositoryContext;
    private ICompanyRepository _companyRepository;
    private IEmployeeRepository _employeeRepository;

    public RepositoryManager(AppDbContext repositoryContext)
    {
        _repositoryContext = repositoryContext;
    }

    public ICompanyRepository Company
    {
        get
        {
            if (_companyRepository == null) _companyRepository = new CompanyRepository(_repositoryContext);
            return _companyRepository;
        }
    }

    public IEmployeeRepository Employee
    {
        get
        {
            if (_employeeRepository == null) _employeeRepository = new EmployeeRepository(_repositoryContext);
            return _employeeRepository;
        }
    }

    public void Save()
    {
        _repositoryContext.SaveChanges();
    }

    public async Task SaveAsync()
    {
        await _repositoryContext.SaveChangesAsync();
    }
}