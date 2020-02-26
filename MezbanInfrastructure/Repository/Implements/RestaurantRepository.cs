using MezbanData.DbContext;
using MezbanInfrastructure.Repository.Interfaces;

namespace MezbanInfrastructure.Repository.Implements
{
    public class RestaurantRepository : BaseRepository<Restaurant>, IRestaurantRepository
    {
        public RestaurantRepository(MezbanAirKitchenEntities context) : base(context)
        {
        }
    }
}
