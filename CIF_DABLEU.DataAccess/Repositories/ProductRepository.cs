using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CIF_DABLEU.DataAccess.Contracts;
using CIF_DABLEU.DataAccess.Data;
using CIF_DABLEU.Entities.Models;

namespace CIF_DABLEU.DataAccess.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        // Aquí implementaríamos los métodos específicos de la interfaz
    }
}
