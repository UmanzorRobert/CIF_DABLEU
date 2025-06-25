using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIF_DABLEU.DataAccess.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository Product { get; }
        // Agregaremos más repositorios aquí: ICustomerRepository, ISaleInvoiceRepository, etc.
        IUserRepository User { get; } 

        Task<int> SaveAsync();
    }
}