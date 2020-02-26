using MezbanData.DbContext;
using MezbanInfrastructure.Repository;
using MezbanService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MezbanService.Implements
{
    public class CommentService : BaseService<Comment>, ICommentService
    {
        public CommentService(IUnitOfWork unitOfWork, IBaseRepository<Comment> repository) : base(unitOfWork, repository)
        {
        }
    }
}
