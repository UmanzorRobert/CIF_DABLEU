using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIF_DABLEU.BusinessLogic.Contracts
{
    public interface IExportService
    {
        Task<byte[]> ExportProductsToExcelAsync();
        Task<byte[]> ExportInvoiceToPdfAsync(int invoiceId);
    }
}
