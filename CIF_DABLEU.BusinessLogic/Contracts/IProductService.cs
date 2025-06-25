using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CIF_DABLEU.Entities.Models;

namespace CIF_DABLEU.BusinessLogic.Contracts
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task CreateProductAsync(Product product);
    }
}
