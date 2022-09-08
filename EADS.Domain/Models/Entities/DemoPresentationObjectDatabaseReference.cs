using EADS.Domain.Models.Entities.Shared;

namespace EADS.Domain.Models.Entities
{
    public class DemoPresentationObjectDatabaseReference : EntityBase
    {
        public string? PassPhrase { get; set; }
        public string? DataStoreKey { get; set; }
    }
}
