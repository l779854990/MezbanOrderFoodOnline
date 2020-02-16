using MezbanData.DbContext;
using MezbanInfrastructure.Repository.Interfaces;

namespace MezbanInfrastructure.Repository.Implements
{
    public class LanguageRepository : BaseRepository<Language>, ILanguageRepository
    {
        public LanguageRepository(MezbanAirKitchenEntities context) : base(context)
        {
        }
    }
}
