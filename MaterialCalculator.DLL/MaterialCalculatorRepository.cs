using MaterialCalculator.DAL.Context;
using MaterialCalculator.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialCalculator.DAL
{
    public class MaterialCalculatorRepository
    {
        List<double> materialWeightsPerRow = new List<double>();       

        public double maxLoadWeight { get; set; } = 24;

        public List<string> GetMaterialType()
        {
            List<string> types = new List<string>();

            List<MaterialDto> materials;

            using (var context = new MaterialCalculatorDBContext())
            {
                materials = context.Materials.ToList();
                
            }

            foreach (var item in materials)
            {
                types.Add(item.Type);
            }

            return types;
        }

        public List<string> GetMaterialSizes(string type)   // type should be get from dropdown list "Type" - what user has chosen
        {
            List<string> sizes = new List<string>();
            List<MaterialDto> materials;

            using (var context = new MaterialCalculatorDBContext())
            {
                materials = context.Materials.ToList();
            }

            foreach (var m in materials)
            {
                var material = materials.Where(m => m.Type == type).FirstOrDefault();
                var size = material.Size;
                sizes.Add(size);
            }

            return sizes;
        }

        public double GetPieceSize(string type)   // type should be get from dropdown list "Type" - what user has chosen
        {
            List<MaterialDto> materials;

            using (var context = new MaterialCalculatorDBContext())
            {
                materials = context.Materials.ToList();
            }           

            var material = materials.FirstOrDefault(m => m.Type == type);
            var pieceSize = material.PieceSize;

            return pieceSize;
        }

        public double GetWeightPerUnit(string type, string size)   // type and size should be get from dropdown list "Type" & "Size" - what user has chosen
        {
            List<MaterialDto> materials;

            using (var context = new MaterialCalculatorDBContext())
            {
                materials = context.Materials.ToList();
            }           

            var material = materials.FirstOrDefault(m => m.Type == type && m.Size == size);
            var weightPerUnit = material.WeightPerUnit;

            return weightPerUnit;
        }

        public double GetNumberOfPieces()
        {
            double numberOfPieces = 0;

            // var numberOfPieces = number received from UI - user input in input field; // User inputs number of pieces 
            // how to do/get this data?

            return numberOfPieces;
        }

        public double CalculateAmountOfMaterialUnits(string type, string size)  // type & size should be get from dropdown list "Type" & "Size" - what user has chosen; how to point to it?
        {
            // according to material.Type and material.Size choice and number of pieces input from UI,method have to calculate total amount of units (m/m2)

            var pieceSize = GetPieceSize(type);
            var amountOfMaterialUnits = pieceSize * GetNumberOfPieces();

            return amountOfMaterialUnits;   
        }

        public double CalculateMaterialWeight(string type, string size)
        {
            List<MaterialDto> materials;            

            using (var context = new MaterialCalculatorDBContext())
            {
                materials = context.Materials.ToList();
            }

            var material = materials.FirstOrDefault(m => m.Type == type && m.Size == size);
            
            double amountOfMaterialUnits = CalculateAmountOfMaterialUnits(type, size);

            double materialWeight = amountOfMaterialUnits * material.WeightPerUnit/1000;
            
            // this weight per each row should be added to total material weight;
            materialWeightsPerRow.Add(materialWeight);

            return materialWeight;
        }

        public double CalculateTotalWeight(List<double> materialWeightsPerRow)
        {
            // material weight from each record row should be added up into one total;
             
            double totalWeight = 0;
            foreach (var weight in materialWeightsPerRow)
            {
                totalWeight = totalWeight + weight;
            }

            return totalWeight;            
        }
    }
}
