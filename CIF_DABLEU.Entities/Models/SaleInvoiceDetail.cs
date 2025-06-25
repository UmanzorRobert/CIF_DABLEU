using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CIF_DABLEU.Entities.Models
{
    public class SaleInvoiceDetail
    {
        public int Id { get; set; }

        [Required]
        public int SaleInvoiceId { get; set; }
        public SaleInvoice? SaleInvoice { get; set; }

        [Required]
        public int ProductId { get; set; }
        public Product? Product { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal UnitPrice { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal SubTotal { get; set; }
    }
}
