using System.Linq.Expressions;
using ErrorHandlingProblemDetails.Data;
using Microsoft.EntityFrameworkCore;

namespace ErrorHandlingProblemDetails.Infrastructure;

public abstract class RepositoryBase<T>: IRepositoryBase<T>
    where T: class
{
    private readonly AppDbContext _repositoryContext;

    public RepositoryBase(AppDbContext repositoryContext)
    {
        _repositoryContext = repositoryContext;
    }
    public IQueryable<T> FindAll(bool trackChanges)
    {
        return !trackChanges ? _repositoryContext.Set<T>().AsNoTracking() : _repositoryContext.Set<T>();
    }

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
    {
        return !trackChanges
            ? _repositoryContext.Set<T>().Where(expression).AsNoTracking()
            : _repositoryContext.Set<T>().Where(expression);
    }

    public void Create(T entity)
    {
        _repositoryContext.Set<T>().Add(entity);
    }

    public void Update(T entity)
    {
        _repositoryContext.Set<T>().Update(entity);
    }

    public void Delete(T entity)
    {
        _repositoryContext.Set<T>().Remove(entity);
    }
}