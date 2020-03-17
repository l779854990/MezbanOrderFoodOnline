using MezbanData.DbContext;
using MezbanInfrastructure.Repository;
using MezbanInfrastructure.Repository.Interfaces;
using MezbanService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MezbanService.Implements
{
    public class LanguageService : BaseService<Language>, ILanguageService
    {
        private readonly ILanguageRepository _languageRepository;
        public LanguageService(ILanguageRepository languageRepository,IUnitOfWork unitOfWork, IBaseRepository<Language> repository) : base(unitOfWork, repository)
        {
            _languageRepository = languageRepository;
        }

        public IList<Language> List()
        {
            return _languageRepository.GetAll().ToList();
        }
    }
}
