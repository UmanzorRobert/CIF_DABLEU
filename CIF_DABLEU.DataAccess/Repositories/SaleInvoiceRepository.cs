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
    public class SaleInvoiceRepository : Repository<SaleInvoice>, ISaleInvoiceRepository
    {
        private readonly ApplicationDbContext _context;

        public SaleInvoiceRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        // Aquí implementaríamos los métodos específicos de la interfaz
        public async Task<decimal> GetTotalSalesAsync()
        {
            return await _context.SaleInvoices.SumAsync(i => i.Total);
        }

        public async Task<IEnumerable<object>> GetTopSellingProductsAsync(int count)
        {
            return await _context.SaleInvoiceDetails
                .GroupBy(d => new { d.ProductId, d.Product.Name })
                .Select(g => new
                {
                    Producto = g.Key.Name,
                    CantidadVendida = g.Sum(d => d.Quantity)
                })
                .OrderByDescending(r => r.CantidadVendida)
                .Take(count)
                .ToListAsync();
        }

        // ... dentro de la clase SaleInvoiceRepository
        public async Task<SaleInvoice?> GetByIdWithDetailsAsync(int invoiceId)
        {
            return await _context.SaleInvoices
                .Include(si => si.Customer)
                .Include(si => si.Details)
                    .ThenInclude(d => d.Product)
                .FirstOrDefaultAsync(si => si.Id == invoiceId);
        }
    }
}
