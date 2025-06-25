using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CIF_DABLEU.BusinessLogic.Contracts;
using CIF_DABLEU.DataAccess.Contracts;
using CIF_DABLEU.Entities.Models;

namespace CIF_DABLEU.BusinessLogic.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        // ¡La Unit of Work es "inyectada" aquí por DI!
        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateProductAsync(Product product)
        {
            // Aquí irían las reglas de negocio. Ejemplo:
            if (product.Price <= 0)
            {
                throw new ArgumentException("El precio del producto debe ser mayor que cero.");
            }

            await _unitOfWork.Product.AddAsync(product);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _unitOfWork.Product.GetAllAsync();
        }
    }
}
