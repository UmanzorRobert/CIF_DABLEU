using CIF_DABLEU.BusinessLogic.Contracts;
using CIF_DABLEU.DataAccess.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIF_DABLEU.BusinessLogic.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly IUnitOfWork _unitOfWork;
        public DashboardService(IUnitOfWork unitOfWork) { _unitOfWork = unitOfWork; }

        public async Task<DashboardDataDto> GetDashboardDataAsync()
        {
            var totalSales = await _unitOfWork.SaleInvoice.GetTotalSalesAsync();
            var topProducts = await _unitOfWork.SaleInvoice.GetTopSellingProductsAsync(5);

            return new DashboardDataDto
            {
                TotalSales = totalSales,
                TopSellingProducts = topProducts
            };
        }
    }
}
