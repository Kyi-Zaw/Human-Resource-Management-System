using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
namespace InfrastructorLayer.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public DbSet<Employee> Employees { get; set; }

    public DbSet<PostInfo> PostInfo { get; set; }
}
