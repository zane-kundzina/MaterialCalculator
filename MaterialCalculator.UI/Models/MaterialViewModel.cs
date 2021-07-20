using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaterialCalculator.UI.Models
{
    public class MaterialViewModel
    {        
        public int Id { get; set; }
        public string Type { get; set; }
        public string Size { get; set; }
        public double PieceSize { get; set; }
        public double WeightPerUnit { get; set; }
        public double NumberOfPieces { get; set; }
        public double PricePerTon { get; set; }        
        
    }
}
