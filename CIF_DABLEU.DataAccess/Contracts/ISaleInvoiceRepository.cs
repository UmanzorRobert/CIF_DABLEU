using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CIF_DABLEU.Entities.Models;

namespace CIF_DABLEU.DataAccess.Contracts
{
    public interface ISaleInvoiceRepository : IRepository<SaleInvoice>
    {
        // Aquí podríamos agregar métodos específicos para productos en el futuro
        // Por ejemplo: Task<IEnumerable<Product>> GetProductsWithLowStockAsync(int threshold);
    }
}

