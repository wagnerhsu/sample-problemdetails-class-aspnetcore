using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ErrorHandlingProblemDetails.Filters;

public class ValidateCompanyExistAttribute : IAsyncActionFilter
{
    private readonly IRepositoryManager _repository;
    private readonly ILogger<ValidateCompanyExistAttribute> _logger;

    public ValidateCompanyExistAttribute(IRepositoryManager repository, ILogger<ValidateCompanyExistAttribute> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var trackChanges = context.HttpContext.Request.Method.Equals("PUT");
        var id = (Guid) context.ActionArguments["id"];
        // TODO:
        var company = await _repository.Company.GetCompanyAsync(id, trackChanges);
        if (company == null)
        {
            _logger.LogInformation($"Company with id: {id} doesn't exist in the database.");
            context.Result = new NotFoundResult();
        }
        else
        {
            context.HttpContext.Items.Add("company", company);
            await next();
        }
    }
}