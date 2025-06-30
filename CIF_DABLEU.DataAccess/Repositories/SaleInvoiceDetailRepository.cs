using CIF_DABLEU.DataAccess.Contracts;
using CIF_DABLEU.DataAccess.Data;
using CIF_DABLEU.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIF_DABLEU.DataAccess.Repositories
{
    public class SaleInvoiceDetailRepository : Repository<SaleInvoiceDetail>, ISaleInvoiceDetailRepository
    {
        private readonly ApplicationDbContext _context;

        public SaleInvoiceDetailRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        // Aquí implementaríamos los métodos específicos de la interfaz
    }
}
