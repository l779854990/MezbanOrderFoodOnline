using MezbanData.DbContext;
using MezbanInfrastructure.Repository;
using MezbanInfrastructure.Repository.Interfaces;
using MezbanService.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace MezbanService.Implements
{
    public class AspNetUserService : BaseService<AspNetUser>, IAspNetUserService
    {
        private readonly IAspNetUserRepository _aspNetUserRepository;
        public AspNetUserService(IAspNetUserRepository aspNetUserRepository,IUnitOfWork unitOfWork, IBaseRepository<AspNetUser> repository) : base(unitOfWork, repository)
        {
            _aspNetUserRepository = aspNetUserRepository;
        }

        public bool CheckStatusUser(string userId)
        {
            return _aspNetUserRepository.Query(x => x.Status)
                .Any(x => x.Id == userId);
        }

        public AspNetUser GetBaseUserId(string userId)
        {
            return _aspNetUserRepository.Query(x => !string.IsNullOrEmpty(x.Id) && x.Status)
                .Include(x => x.AspNetRoles)
                .FirstOrDefault(x => x.Id == userId);
        }

        List<AspNetUser> IAspNetUserService.GetAll()
        {
            return _aspNetUserRepository.Query(x => x.Status).ToList();
        }
    }
}
