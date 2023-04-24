using DataAccess.Models;
using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class UserRepository : RepositoryBase<Account>, IUserRepository
    {
        public UserRepository(pxinxnmyschxxldxrsContext repositoryContext)
            : base(repositoryContext) { }
    }
}
