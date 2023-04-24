using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUserService
    {
        Task<List<Account>> GetAll();
        Task<Account> GetById(int id);
        Task Create(Account model);
        Task Update(Account model);
        Task Delete(int id);

    }
}
