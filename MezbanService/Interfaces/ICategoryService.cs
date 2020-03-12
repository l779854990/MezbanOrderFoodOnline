using MezbanData.DbContext;
using MezbanModel.Category;

namespace MezbanService.Interfaces
{
    public interface ICategoryService : IBaseService<Category>
    {
        bool Create(CategoryCommandModel categoryViewModel,Category e);
    }
}
