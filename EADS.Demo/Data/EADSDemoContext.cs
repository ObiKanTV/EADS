using Microsoft.EntityFrameworkCore;

public class EADSDemoContext : DbContext
{
    public EADSDemoContext(DbContextOptions<EADSDemoContext> options)
        : base(options)
    {
    }

    public DbSet<EADS.Demo.Models.DemoPresentationObject> DemoPresentationObject { get; set; } = default!;
    public DbSet<EADS.Demo.Models.DemoPresentationObjectDatabaseReference> DemoPresentationObjectDatabaseReferences { get; set; } = default!;
}
