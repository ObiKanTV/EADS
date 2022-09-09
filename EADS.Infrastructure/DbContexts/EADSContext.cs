using EADS.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EADS.Infrastructure.DbContexts;

public class EADSContext : DbContext
{
    public EADSContext(DbContextOptions<EADSContext> options)
        : base(options)
    {
    }

    public DbSet<EncStringData> EncStringData { get; set; } = default!;
    public DbSet<TestEncObject> EncObjectData { get; set; } = default!;
    public DbSet<EncryptionValue> EncryptionValues { get; set; } = default!;
    public DbSet<DemoPresentationEncObject> DemoPresentationEncObjects { get; set; } = default!;
}
