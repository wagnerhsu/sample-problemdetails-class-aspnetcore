using Microsoft.EntityFrameworkCore;

namespace ErrorHandlingProblemDetails.Data;

public class AppDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Company> Companies { get; set; }     
    public DbSet<Employee> Employees { get; set; } 
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Product>().ToTable("Products");
        builder.Entity<Product>().HasKey(p => p.ProductId);
        builder.Entity<Product>().Property(p => p.ProductId).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(50);
        builder.Entity<Product>().Property(p => p.Category).IsRequired().HasMaxLength(20);

        builder.Entity<Product>().HasData
        (
            new Product {ProductId = 101, Name = "Plate", Category = "Kitchen Utensils"},
            new Product {ProductId = 102, Name = "Blanket", Category = "Accessories"},
            new Product {ProductId = 103, Name = "Bicycle", Category = "Vehicle"}
        );

        builder.ApplyConfiguration(new CompanyConfiguration());
        builder.ApplyConfiguration(new EmployeeConfiguration());
    }
}