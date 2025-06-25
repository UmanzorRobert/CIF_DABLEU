using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CIF_DABLEU.Entities.Models;

namespace CIF_DABLEU.DataAccess.Contracts
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User?> GetByEmailAsync(string email);
    }
}