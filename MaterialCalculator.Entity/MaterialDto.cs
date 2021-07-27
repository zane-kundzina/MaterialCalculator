using System;

namespace MaterialCalculator.Entity
{
    public class MaterialDto
    {
        public int Id { get; set; }
        public string Type { get; set; }

        public int TypeId { get; set; }

        public string Size { get; set; }

        public double PieceSize { get; set; }

        public int PieceSizeId { get; set; }
        public double WeightPerUnit { get; set; }

        //public double NumberOfPieces { get; set; }
        //public double PricePerTon { get; set; }

    }
}
