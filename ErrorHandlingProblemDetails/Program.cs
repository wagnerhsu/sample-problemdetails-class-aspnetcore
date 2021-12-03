using ErrorHandlingProblemDetails.Data;
using ErrorHandlingProblemDetails.Infrastructure;
using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
    .Enrich.FromLogContext()
    .WriteTo.Async(c => c.Seq("http://localhost:5341"))
    .WriteTo.Async(c => c.Console())
    .CreateLogger();
try
{
    var builder = WebApplication.CreateBuilder(args);
    builder.Host.UseSerilog();
    var useInMemoryDb = builder.Configuration.GetValue<bool>("UseInMemeryDb");
    // Add services to the container.
    builder.Services.AddDbContext<AppDbContext>(options =>
    {
        if (useInMemoryDb)
            options.UseInMemoryDatabase("test-db");
        else options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
        if (builder.Environment.IsDevelopment())
        {
            options.EnableDetailedErrors();
            options.EnableSensitiveDataLogging();
        }
    });
    builder.Services.AddProblemDetails(options =>
    {
        options.IncludeExceptionDetails = (context, exception) => builder.Environment.IsDevelopment();
        options.Map<ProductCustomException>(exception => new ProblemDetails
        {
            Title = exception.Title,
            Detail = exception.Detail,
            Status = StatusCodes.Status500InternalServerError,
            Type = exception.Type,
            Instance = exception.Instance
        });
    });
    builder.Services.AddScoped<IProductService, ProductService>();
    builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
    builder.Services.AddControllers();
    builder.Services.AddAutoMapper(typeof(Program));
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseProblemDetails();
    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();
    // Database Seed
    using (var scope = app.Services.CreateAsyncScope())
    using (var context = scope.ServiceProvider.GetService<AppDbContext>())
    {
        context.Database.EnsureCreated();
    }

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly!");
}
finally
{
    Log.CloseAndFlush();
}