using EADS.Domain.Interfaces.Services;
using EADS.Domain.Models.DTOs;

namespace EADS.Domain.Interfaces.Repositories.Shared;

public interface IRepositoryBase<TEntity> where TEntity : DTOBase
{
    public IEncryptionService EncryptionService { get; }

    Task<TEntity> Get(EADSRequestGetDTO request);
    Task<EADSResponsePostDTO> Add(TEntity entity);
    Task Remove(string id);
}

