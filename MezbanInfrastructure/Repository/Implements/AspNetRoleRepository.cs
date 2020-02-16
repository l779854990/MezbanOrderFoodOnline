using MezbanData.DbContext;
using MezbanInfrastructure.Repository.Interfaces;

namespace MezbanInfrastructure.Repository.Implements
{
    public class AspNetRoleRepository : BaseRepository<AspNetRole>, IAspNetRoleRepository
    {
        public AspNetRoleRepository(MezbanAirKitchenEntities context) : base(context)
        {
        }
    }
}
