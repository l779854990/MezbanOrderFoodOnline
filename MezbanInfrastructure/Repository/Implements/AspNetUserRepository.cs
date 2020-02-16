using MezbanData.DbContext;
using MezbanInfrastructure.Repository.Interfaces;

namespace MezbanInfrastructure.Repository.Implements
{
    public class AspNetUserRepository : BaseRepository<AspNetUser>, IAspNetUserRepository
    {
        public AspNetUserRepository(MezbanAirKitchenEntities context) : base(context)
        {
        }
    }
}
