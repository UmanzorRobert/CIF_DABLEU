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
    public class InvoiceService : IInvoiceService
    {
        private readonly IUnitOfWork _unitOfWork;

        public InvoiceService(IUnitOfWork unitOfWork) { _unitOfWork = unitOfWork; }

        public async Task<SaleInvoice> CreateInvoiceAsync(int customerId, IEnumerable<InvoiceDetailDto> details)
        {
            // --- INICIO DE LA TRANSACCIÓN (implícita por Unit of Work) ---

            // 1. Validar Stock y Calcular Total
            decimal total = 0;
            foreach (var detail in details)
            {
                var product = await _unitOfWork.Product.GetByIdAsync(detail.ProductId);
                if (product == null || product.Stock < detail.Quantity)
                {
                    throw new Exception($"Stock insuficiente para el producto: {product?.Name ?? "ID " + detail.ProductId}");
                }
                total += detail.Quantity * detail.UnitPrice;
            }

            // 2. Crear la Cabecera de la Factura
            var invoiceHeader = new SaleInvoice
            {
                CustomerId = customerId,
                IssueDate = DateTime.UtcNow,
                Total = total
            };
            await _unitOfWork.SaleInvoice.AddAsync(invoiceHeader);
            await _unitOfWork.SaveAsync(); // Guardamos para obtener el ID de la factura

            // 3. Crear los Detalles y Actualizar Stock
            foreach (var detail in details)
            {
                var invoiceDetail = new SaleInvoiceDetail
                {
                    SaleInvoiceId = invoiceHeader.Id,
                    ProductId = detail.ProductId,
                    Quantity = detail.Quantity,
                    UnitPrice = detail.UnitPrice,
                    SubTotal = detail.Quantity * detail.UnitPrice
                };
                await _unitOfWork.SaleInvoiceDetail.AddAsync(invoiceDetail);

                // Decrementar stock
                var productToUpdate = await _unitOfWork.Product.GetByIdAsync(detail.ProductId);
                productToUpdate!.Stock -= detail.Quantity;
                _unitOfWork.Product.Update(productToUpdate);
            }

            // 4. Guardar todos los cambios
            await _unitOfWork.SaveAsync();

            // 5. Devolver el objeto de la factura recién creada
            return invoiceHeader;
            // --- FIN DE LA TRANSACCIÓN ---
        }
    }
}
