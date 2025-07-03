using CIF_DABLEU.BusinessLogic.Services;
using CIF_DABLEU.DataAccess.Contracts;
using CIF_DABLEU.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIF_DABLEU.BusinessLogic.Contracts
{
    // Usaremos una clase DTO (Data Transfer Object) para pasar los datos de la factura desde la UI
    public record InvoiceDetailDto(int ProductId, int Quantity, decimal UnitPrice);

    public interface IInvoiceService
    {
        Task<SaleInvoice> CreateInvoiceAsync(int customerId, IEnumerable<InvoiceDetailDto> details);
    }
}
