using EADS.Domain.Interfaces.Repositories;
using EADS.Domain.Interfaces.Services;
using EADS.Domain.Models.DTOs;
using EADS.Domain.Models.Entities;
using EADS.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
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

    public async Task<EADSResponsePostDTO> Add(DemoPresentationObjectDTO entity)
    {
        var eV = EncryptionService.GenerateEncryptionValue();
        var encObject = new DemoPresentationEncObject(){Name = EncryptionService.Encrypt(entity.Name, eV, entity.PassPhrase),
                                                     Description = EncryptionService.Encrypt(entity.Description, eV, entity.PassPhrase),
                                                     PhoneNumber = EncryptionService.Encrypt(entity.PhoneNumber, eV, entity.PassPhrase),
                                                     FileContent = EncryptionService.Encrypt(entity.FileContent, eV, entity.PassPhrase),
                                                     SSN = EncryptionService.Encrypt(entity.SSN, eV, entity.PassPhrase),
                                                     EncryptionValue = eV};
        var result1 = context.EncryptionValues.Add(eV);
        var result2 = context.DemoPresentationEncObjects.Add(encObject);

        await context.SaveChangesAsync();
        Console.WriteLine("Results: " + result1.ToString() + "\n" + result2.ToString());
        return new EADSResponsePostDTO() {Id = result2.Entity.Id };

    }
    public async Task<DemoPresentationObjectDTO> Get(EADSRequestGetDTO request)
    {
        var encObject = await context.DemoPresentationEncObjects.Where(x => x.Id == request.Id).Include(x => x.EncryptionValue).FirstOrDefaultAsync();
        var response = new DemoPresentationObjectDTO(EncryptionService.Decrypt(encObject.Name, encObject.EncryptionValue, request.PassPhrase),
                                                     EncryptionService.Decrypt(encObject.Description, encObject.EncryptionValue, request.PassPhrase),
                                                     EncryptionService.Decrypt(encObject.PhoneNumber, encObject.EncryptionValue, request.PassPhrase),
                                                     EncryptionService.Decrypt(encObject.FileContent, encObject.EncryptionValue, request.PassPhrase),
                                                     EncryptionService.Decrypt(encObject.SSN, encObject.EncryptionValue, request.PassPhrase));
        
        
        return response;
    }

    public async Task Remove(string id)
    {
        var encObject = context.DemoPresentationEncObjects.Where(x => x.Id == id).Include(x => x.EncryptionValue).FirstOrDefault();
        context.DemoPresentationEncObjects.Remove(encObject);
        context.EncryptionValues.Remove(encObject.EncryptionValue);
        await context.SaveChangesAsync();
    }
    public async Task<bool> Exists(string id)
    {
        return await context.DemoPresentationEncObjects.AnyAsync(x => x.Id == id);
    }
}

