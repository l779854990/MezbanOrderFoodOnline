using MezbanData.DbContext;
using MezbanInfrastructure.Repository;
using MezbanService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MezbanService.Implements
{
    public class CategoryService : BaseService<Category>, ICategoryService
    {
        public CategoryService(IUnitOfWork unitOfWork, IBaseRepository<Category> repository) : base(unitOfWork, repository)
        {
        }
    }
}
