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
        public double PieceSize { get; set; }

        public MaterialDto Material { get; set; }
    }
}
