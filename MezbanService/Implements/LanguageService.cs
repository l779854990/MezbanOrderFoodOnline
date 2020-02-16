using MezbanData.DbContext;
using MezbanInfrastructure.Repository;
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
        public LanguageService(IUnitOfWork unitOfWork, IBaseRepository<Language> repository) : base(unitOfWork, repository)
        {
        }
    }
}
