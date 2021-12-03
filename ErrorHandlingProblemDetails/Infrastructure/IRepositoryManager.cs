﻿namespace ErrorHandlingProblemDetails.Infrastructure;

public interface IRepositoryManager
{
    ICompanyRepository Company { get; }
    IEmployeeRepository Employee { get; }
    void Save();
}