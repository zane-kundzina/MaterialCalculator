using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialCalculator.Entity
{
    public class OrderListDto
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Order Number")]
        [Required]
        public string OrderNumber { get; set; }

        [DisplayName("Ordered By")]
        [Required]
        public string OrderedBy { get; set; }

        [DisplayName("Supplier")]
        public int SupplierId { get; set; }
        [ForeignKey("SupplierId")]
        public virtual SupplierDto Supplier { get; set; }
    }
}
