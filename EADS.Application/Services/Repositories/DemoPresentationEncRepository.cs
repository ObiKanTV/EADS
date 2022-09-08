using EADS.Domain.Interfaces.Repositories;
using EADS.Domain.Interfaces.Services;
using EADS.Domain.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EADS.Application.Services.Repositories;

public class DemoPresentationEncRepository : IDemoPresentationEncRepository
{
    public IEncryptionService EncryptionService { get; }
    private readonly EADSContext context;

    public DemoPresentationEncRepository(IEncryptionService encryptionService, EADSContext context)
    {
        EncryptionService = encryptionService;
        this.context = context;
    }

    public Task<EADSResponsePostDTO> Add(DemoPresentationObjectDTO entity)
    {
        throw new NotImplementedException();
    }

    public Task<DemoPresentationObjectDTO> Get(EADSRequestGetDTO request)
    {
        //context.
        return null;
    }

    public Task Remove(string id)
    {
        context.Remove(id);
        return Task.CompletedTask;
    }
}

