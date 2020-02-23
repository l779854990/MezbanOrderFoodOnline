using MezbanData.DbContext;
using MezbanInfrastructure.Repository;
using MezbanModel.AspNetUser;
using MezbanService.Interfaces;

namespace MezbanService.Implements
{
    public class AspNetRoleService : BaseService<AspNetRole>, IAspNetRoleService
    {
        public AspNetRoleService(IUnitOfWork unitOfWork, IBaseRepository<AspNetRole> repository) : base(unitOfWork, repository)
        {
        }

        public UserRoleModel GetUserRole()
        {
            throw new System.NotImplementedException();
        }
    }
}
