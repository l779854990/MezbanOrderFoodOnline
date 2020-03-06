using System;
using MezbanData.DbContext;
using MezbanInfrastructure.Repository.Interfaces;

namespace MezbanInfrastructure.Repository.Implements
{
    public class ContentEntryRepository : BaseRepository<ContentEntry>,IContentEntryRepository
    {
        public ContentEntryRepository(MezbanAirKitchenEntities context) : base(context)
        {
        }
    }
}
