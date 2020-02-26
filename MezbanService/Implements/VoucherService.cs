using MezbanData.DbContext;
using MezbanInfrastructure.Repository;
using MezbanService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MezbanService.Implements
{
    public class VoucherService : BaseService<Voucher>, IVoucherService
    {
        public VoucherService(IUnitOfWork unitOfWork, IBaseRepository<Voucher> repository) : base(unitOfWork, repository)
        {
        }
    }
}
