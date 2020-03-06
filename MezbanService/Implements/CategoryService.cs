using MezbanData.DbContext;
using MezbanInfrastructure.Repository;
using MezbanService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using MezbanCommon.Heplers;
using MezbanInfrastructure.Repository.Interfaces;

namespace MezbanService.Implements
{
    public class CategoryService : BaseService<Category>, ICategoryService
    {
        private readonly  _contentEntryRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IContentDefinitionRepository _contentDefinitionRepository;
        public CategoryService(IUnitOfWork unitOfWork, IBaseRepository<Category> repository) : base(unitOfWork, repository)
        {
        }

        public bool Create(Category e)
        {
            using (var DbTransaction = _unitOfWork.BeginTransaction()) { }
            {
                try
                {
                    var contentDefinition = new Contentdefinition
                    {
                        Name = Contanst.TableName.Category
                    };
                    _ageRepository.Insert(age);
                    _unitOfWork.Complete();
                    dbTransaction.Commit();
                    return true;
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
