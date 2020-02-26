using MezbanData.DbContext;
using MezbanInfrastructure.Repository;
using MezbanService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MezbanService.Implements
{
    public class RestaurantService : BaseService<Restaurant>, IRestaurantService
    {
        public RestaurantService(IUnitOfWork unitOfWork, IBaseRepository<Restaurant> repository) : base(unitOfWork, repository)
        {
        }
    }
}
