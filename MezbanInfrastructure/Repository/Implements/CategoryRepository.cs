using MezbanData.DbContext;
using MezbanInfrastructure.Repository.Interfaces;

namespace MezbanInfrastructure.Repository.Implements
{
    public class CategoryRepository : BaseRepository<Category>,ICategoryRepository
    {
        public CategoryRepository(MezbanAirKitchenEntities context) : base(context)
        {
        }
    }
}
