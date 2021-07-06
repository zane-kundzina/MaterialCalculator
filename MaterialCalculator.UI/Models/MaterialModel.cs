using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaterialCalculator.UI.Models
{
    public class MaterialModel
    {
        public string Type { get; private set; }
        public string Size { get; private set; }
        public double PieceSize { get; private set; }
        public double NumberOfPieces { get; set; }
        public double WeightPerUnitKg { get; private set; }

        
    }
}
