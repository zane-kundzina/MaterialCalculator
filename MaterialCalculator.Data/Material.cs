using System;
using System.Collections.Generic;
using System.Text;

namespace MaterialCalculator.Data
{
    public class Material
    {
        public string Type { get; private set; }
        public string Size { get; private set; }
        public double PieceSize { get; private set; }
        public double NumberOfPieces { get; set; }
        public double WeightPerUnitKg { get; private set; }

        public Material(string type, string size, double pieceSize, double weightPerUnitKg )
        {
            Type = type;
            Size = size;
            PieceSize = pieceSize;
            WeightPerUnitKg = weightPerUnitKg;
        }


    }
}
