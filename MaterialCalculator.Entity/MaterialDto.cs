using System;

namespace MaterialCalculator.Entity
{
    public class MaterialDto
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Size { get; set; }
        public double PieceSize { get; set; }
        public double NumberOfPieces { get; set; }
        public double pricePerTon { get; set; }
        public double WeightPerUnitKg { get; set; }
    }
}
