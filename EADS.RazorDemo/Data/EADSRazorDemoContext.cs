using EADS.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EADS.RazorDemo.Data;
public class EADSRazorDemoContext : DbContext
{
    public EADSRazorDemoContext(DbContextOptions<EADSRazorDemoContext> options)
        : base(options)
    {
    }
    public DbSet<DemoPresentationObjectDatabaseReference> DemoObjects { get; set; } = default!;
}
