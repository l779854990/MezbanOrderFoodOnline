using MezbanData.DbContext;

namespace MezbanService.Interfaces
{
    public interface ICategoryService : IBaseService<Category>
    {
        bool Create(Category e);
    }
}
