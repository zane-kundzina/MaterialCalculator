using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialCalculator.Entity
{
    public class MaterialTypesDto
    {
        public int Id { get; set; }

        public string TypeName { get; set; }

        public MaterialDto Material { get; set; }
    }
}
