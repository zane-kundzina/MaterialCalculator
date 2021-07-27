using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialCalculator.Entity
{
    public class PieceSizesDto
    {
        public int Id { get; set; }
        public string PieceSizeName { get; set; }

        public MaterialDto Material { get; set; }
    }
}
