using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CIF_DABLEU.Entities.Models
{
    public class SaleInvoice
    {
        public int Id { get; set; }

        [Required]
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }

        public DateTime IssueDate { get; set; } = DateTime.UtcNow;

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Total { get; set; }

        public ICollection<SaleInvoiceDetail> Details { get; set; } = new List<SaleInvoiceDetail>();
    }
}
