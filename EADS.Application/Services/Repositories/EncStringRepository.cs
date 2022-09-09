using EADS.Domain.Interfaces.Repositories;
using EADS.Domain.Interfaces.Services;
using EADS.Domain.Models.DTOs;
using EADS.Domain.Models.Entities;
using EADS.Infrastructure.DbContexts;

namespace EADS.Application.Services.Repositories;

public class EncStringRepository : IEncStringRepository
{
    private readonly EADSContext context;

    public EncStringRepository(IEncryptionService encryptionService, EADSContext context)
    {
        EncryptionService = encryptionService;
        this.context = context;
    }

    public IEncryptionService EncryptionService { get; }

    public Task<EADSResponsePostDTO> Add(EncStringDTO entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));
        var encValue = EncryptionService.GenerateEncryptionValue();
        var encData = EncryptionService.Encrypt(entity.Data, encValue, entity.PassPhrase);
        var encModel = new EncStringData() { 
            Data = encData,
            EncryptionValue = encValue
        };
        var resp1 = context.Add(encValue);
        var resp2 = context.Add(encModel);
        var result = context.SaveChangesAsync().Result;

        return Task.FromResult(new EADSResponsePostDTO() {Id = encModel.Id });

    }

    public Task<bool> Exists(string id)
    {
        throw new NotImplementedException();
    }

    public Task<EncStringDTO> Get(EADSRequestGetDTO request)
    {
        throw new NotImplementedException();
    }

    public Task Remove(string id)
    {
        throw new NotImplementedException();
    }
}

