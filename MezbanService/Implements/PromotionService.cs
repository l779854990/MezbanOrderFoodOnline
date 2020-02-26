using MezbanData.DbContext;
using MezbanInfrastructure.Repository;
using MezbanService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MezbanService.Implements
{
    public class PromotionService : BaseService<Promotion>, IPromotionService
    {
        public PromotionService(IUnitOfWork unitOfWork, IBaseRepository<Promotion> repository) : base(unitOfWork, repository)
        {
        }
    }
}
