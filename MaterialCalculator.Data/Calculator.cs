using System;
using System.Collections.Generic;

namespace MaterialCalculator.Data
{
    public class Calculator
    {
        public List<Material> materials { get; set; } = new List<Material>();

        // does it needs any specific constructor?

        public void NewMaterialList()
        {
            // method code....
            // saves/exports current list of materials (optionally) and clears it afterwards; 
        }

        public void AddMaterial(Material material)
        {
            // method code....
            materials.Add(material);
        }

        public double CalculateMaterialAmount()
        {
            // method code....
            return 0.0;
        }

        public double CalculateMaterialWeight()
        {
            // method code....
            return 0.0;
        }

        public double CalculateTotalWeight()
        {
            // method code....
            return 0.0;
        }

        public double CalculatePercentageOfLoad()
        {
            // method code....
            return 0.0;
        }

        public string IsLoadFull()
        {
            // method code....
            return string.Empty;
        }


    }
}
