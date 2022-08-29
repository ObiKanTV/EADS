using EADS.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

public class EADSContext : DbContext
{
    public EADSContext(DbContextOptions<EADSContext> options)
        : base(options)
    {
    }

    public DbSet<EncStringData> EncStringData { get; set; } = default!;
    public DbSet<TestEncObject> EncObjectData { get; set; } = default!;
    public DbSet<EncryptionValue> EncryptionValues { get; set; } = default!;
}
