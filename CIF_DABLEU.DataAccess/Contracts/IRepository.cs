using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace CIF_DABLEU.DataAccess.Contracts
{
    public interface IRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        void Update(T entity); // Generalmente no es asíncrona
        void Delete(T entity); // Generalmente no es asíncrona
    }
}
