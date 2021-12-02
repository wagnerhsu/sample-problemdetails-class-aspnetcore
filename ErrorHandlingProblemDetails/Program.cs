using ErrorHandlingProblemDetails.Data;
using ErrorHandlingProblemDetails.Infrastructure;
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
    // Add services to the container.
    builder.Services.AddDbContext<AppDbContext>(options =>
    {
        options.UseInMemoryDatabase(("test-db"));
    });
    builder.Services.AddScoped<IProductService, ProductService>();
    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

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