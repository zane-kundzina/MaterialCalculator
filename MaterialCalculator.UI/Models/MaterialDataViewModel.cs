using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaterialCalculator.UI.Models
{
    public class MaterialDataViewModel
    {
        public List<string> Types { get; set; }

        public List<string> Sizes { get; set; }

        public double PieceSize { get; set; }

        public double NumberOfPieces { get; set; }

        public double TotalAmountOfUnits { get; set; }


    }
}
