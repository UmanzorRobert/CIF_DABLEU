using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CIF_DABLEU.Entities.Models;

namespace CIF_DABLEU.BusinessLogic.Contracts
{
    public interface IAuthService
    {
        Task<bool> RegisterUserAsync(string fullName, string email, string password);
        Task<string?> LoginAsync(string email, string password);
    }
}
