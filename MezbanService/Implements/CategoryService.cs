using MezbanData.DbContext;
using MezbanInfrastructure.Repository;
using MezbanService.Interfaces;
using System;
using MezbanCommon.Heplers;
using MezbanInfrastructure.Repository.Interfaces;

namespace MezbanService.Implements
{
    public class CategoryService : BaseService<Category>, ICategoryService
    {
        private readonly  IContentEntryRepository _contentEntryRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IContentDefinitionRepository _contentDefinitionRepository;
        public CategoryService(IUnitOfWork unitOfWork, IBaseRepository<Category> repository) : base(unitOfWork, repository)
        {
        }

        public bool Create(Category e)
        {
            using (var DbTransaction = _unitOfWork.BeginTransaction())
            {
                try
                {
                    var contentDefinition = new Contentdefinition
                    {
                        Name = Contanst.TableName.Category
                    };
                    _unitOfWork.Complete();
                    DbTransaction.Commit();
                    return true;
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                    return false;
                }
            }
        }
    }
}
