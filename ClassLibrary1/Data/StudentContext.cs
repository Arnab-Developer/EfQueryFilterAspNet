using ClassLibrary1.Models;
using ClassLibrary1.Services;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary1.Data;

public class StudentContext : DbContext
{
    private readonly int _tenantId;

    public StudentContext(DbContextOptions<StudentContext> options,
        ITenantProvider tenantProvider) : base(options)
    {
        _tenantId = tenantProvider.GetTenantId();
        Students = Set<Student>();
    }

    public DbSet<Student> Students { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>().HasQueryFilter(s => s.TenantId == _tenantId);
    }
}
