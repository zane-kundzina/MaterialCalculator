using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialCalculator.Entity
{
    public class MaterialSizesDto
    {
        [Key]
        public int Id { get; set; }
        public int MaterialId { get; set; }
        public string Size { get; set; }
        public MaterialDto Material { get; set; }
    }
}
