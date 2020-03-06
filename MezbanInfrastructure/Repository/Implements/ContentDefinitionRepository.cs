using System;
using MezbanData.DbContext;
using MezbanInfrastructure.Repository.Interfaces;

namespace MezbanInfrastructure.Repository.Implements
{
    public class ContentDefinitionRepository : BaseRepository<Contentdefinition>, IContentDefinitionRepository
    {
        public ContentDefinitionRepository(MezbanAirKitchenEntities context) : base(context)
        {
        }
    }
}
