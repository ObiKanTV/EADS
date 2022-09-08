using EADS.Domain.Interfaces.Repositories.Shared;
using EADS.Domain.Interfaces.Services;
using EADS.Domain.Models.DTOs;
using EADS.Domain.Models.DTOs.Shared;
using EADS.Domain.Models.Entities.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EADS.Application.Services.Repositories.Shared
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : DTOBase
    {
        public IEncryptionService EncryptionService => throw new NotImplementedException();

        public Task<EADSResponsePostDTO> Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> Get(EADSRequestGetDTO request)
        {
            throw new NotImplementedException();
        }

        public Task Remove(string id)
        {
            throw new NotImplementedException();
        }
    }
}
