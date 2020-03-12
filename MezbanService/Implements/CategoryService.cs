using MezbanData.DbContext;
using MezbanInfrastructure.Repository;
using MezbanService.Interfaces;
using System;
using MezbanCommon.Heplers;
using MezbanInfrastructure.Repository.Interfaces;
using MezbanModel.Category;

namespace MezbanService.Implements
{
    public class CategoryService : BaseService<Category>, ICategoryService
    {
        private readonly IContentEntryRepository _contentEntryRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IContentDefinitionRepository _contentDefinitionRepository;
        public CategoryService(IContentEntryRepository contentEntryRepository, ICategoryRepository categoryRepository, IContentDefinitionRepository contentDefinitionRepository,IUnitOfWork unitOfWork, IBaseRepository<Category> repository) : base(unitOfWork, repository)
        {
            _contentEntryRepository = contentEntryRepository;
            _categoryRepository = categoryRepository;
            _contentDefinitionRepository = contentDefinitionRepository;
        }

        public bool Create(CategoryCommandModel vm, Category e)
        {
            using (var DbTransaction = _unitOfWork.BeginTransaction())
            {
                try
                {
                    var contentDefinition = new ContentDefinition
                    {
                        Name = Contanst.TableName.Category
                    };
                    e.ContentDefinition = contentDefinition;
                    foreach (var item in vm.LanguageVms)
                    {
                        var contentEntry = new ContentEntry
                        {
                            LanguageId = item.LanguageId,
                            Token = item.Token,
                            Value = item.Value ?? string.Empty,
                            ContentDefinitionId = contentDefinition.ContentDefinitionId
                        };
                        e.ContentDefinition.ContentEntries.Add(contentEntry);
                    }
                    _categoryRepository.Insert(e);
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
