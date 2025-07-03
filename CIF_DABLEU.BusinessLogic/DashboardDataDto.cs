using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIF_DABLEU.BusinessLogic
{
    public class DashboardDataDto
    {
        public decimal TotalSales { get; set; }
        public IEnumerable<object> TopSellingProducts { get; set; } = new List<object>();
    }
}
