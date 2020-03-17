using MezbanData.DbContext;
using MezbanModel.Category;
using System.Collections.Generic;

namespace MezbanService.Interfaces
{
    public interface ICategoryService : IBaseService<Category>
    {
        bool Create(CategoryViewModel categoryViewModel,Category e);
        IList<Category> List();
    }
}
