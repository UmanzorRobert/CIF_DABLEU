using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIF_DABLEU.BusinessLogic.Contracts
{
    public interface IDashboardService
    {
        Task<DashboardDataDto> GetDashboardDataAsync();
    }
}
