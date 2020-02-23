using MezbanData.DbContext;
using MezbanModel.AspNetUser;
using System.Collections.Generic;

namespace MezbanService.Interfaces
{
    public interface IAspNetUserService : IBaseService<AspNetUser>
    {
        bool CheckStatusUser(string userId);
        List<AspNetUser> GetAll();
        AspNetUser GetBaseUserId(string userId);
    }
}
