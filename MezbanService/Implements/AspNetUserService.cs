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
    public class AspNetUserService : BaseService<AspNetUser>, IAspNetUserService
    {
        public AspNetUserService(IUnitOfWork unitOfWork, IBaseRepository<AspNetUser> repository) : base(unitOfWork, repository)
        {
        }
    }
}
