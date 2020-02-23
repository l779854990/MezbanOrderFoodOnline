using MezbanData.DbContext;
using MezbanModel.AspNetUser;

namespace MezbanService.Interfaces
{
    public interface IAspNetRoleService : IBaseService<AspNetRole>
    {
        UserRoleModel GetUserRole();
    }
}
