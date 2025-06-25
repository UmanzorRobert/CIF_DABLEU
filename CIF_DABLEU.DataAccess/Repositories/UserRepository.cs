using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CIF_DABLEU.DataAccess.Contracts;
using CIF_DABLEU.DataAccess.Data;
using CIF_DABLEU.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace CIF_DABLEU.DataAccess.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}