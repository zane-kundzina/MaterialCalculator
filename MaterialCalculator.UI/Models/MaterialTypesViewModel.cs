using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaterialCalculator.UI.Models
{
    public class MaterialTypesViewModel
    {
        public int Id { get; set; }

        public string TypeName { get; set; }

        public MaterialViewModel Material { get; set; }
    }
}
