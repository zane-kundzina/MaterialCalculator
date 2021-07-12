using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaterialCalculator.BLL;
using MaterialCalculator.Entity;

namespace MaterialCalculator.BLL
{
    public class MaterialCalculatorActions
    {
        // place for logic; entity objects are used in BLL; methods        

        List<double> materialWeightsPerRow = new List<double>();
        const double maxLoadWeight = 24;

        public int GetMaterialId(string type, string size)
        {
            // according to material Type and Size from UI, methods finds material in data base;
            // Not sure if following code points to data base objects, data base will be in DAL....... how to do it?
            // not sure if finding Id is necessary at all, because Type&size combination is unique and given by user,
            // according to this info material can be found in database;

            List<MaterialDto> materials = new List<MaterialDto>(); // material list in data base???

            var material = materials.FirstOrDefault(m => m.Type == type && m.Size == size); // according to type and size Id can be found in the list;
            var id = material.Id;            

            return id; 
        }
        public List<string> GetMaterialSizes(string type)
        {
            // according to material.Type choice from UI, method have to offer list of available material sizes in dropdown
            // list in UI "Size" for further choice;
            // Not sure if following code points to data base objects, data base will be in DAL....... how to do it?

            List<string> sizes = new List<string>();    // lsit of sizes availablo for type chosed should appear in dropdown list "Size" to chose it in UI;

            List<MaterialDto> materials = new List<MaterialDto>(); // material list in data base???

            //Mocked list
            for(int i = 0; i>0; i++)
            {
                materials.Add(new MaterialDto()
                {
                    Id = i,
                    NumberOfPieces = i
                });
            }
            //Mocked list

            foreach (var m in materials)
            {
                var material = materials.FirstOrDefault(m => m.Type == type);
                var size = material.Size;
                sizes.Add(size);
            }

            return sizes;
            // list of sizes should be displayed in dropdown list un UI;
            // how to do it?
        }

        public double GetPieceSize(string type)
        {
            // according to material.Type choice from UI, method have to offer piece size for this material type from data base

            List<MaterialDto> materials = new List<MaterialDto>(); // material list in data base???

            var material = materials.FirstOrDefault(m => m.Type == type);
            var pieceSize = material.PieceSize;

            return pieceSize;
            // pieceSize should be displayed in UI for material type chosen;
            // how to do it?
        }

        public double GetNumberOfPieces()
        { 
            double numberOfPieces = 0;

            // var numberOfPieces = number received from UI - user input;
            // how to do this?

            return numberOfPieces;
        }

        public double GetKgPerUnit(string type, string size)
        {
            // according to material.Type and material.Size choice from UI, method have to find weight of this material per unit from data base

            List<MaterialDto> materials = new List<MaterialDto>(); // material list in data base???

            var material = materials.FirstOrDefault(m => m.Type == type && m.Size == size);
            var kgPerUnit = material.WeightPerUnitKg;

            return kgPerUnit;
        }

        public double CalculateAmountOfMaterialUnits(string type, string size, int numberOfPieces)
        {
            // according to material.Type and material.Size choice and number of pieces input from UI,method have to calculate total amount of units (m/m2)
            // User inputs number of pieces 

            var pieceSize = GetPieceSize(type);
            var amountOfMaterialUnits = pieceSize * numberOfPieces;            

            return amountOfMaterialUnits;   // should be shown in the UI table
        }

        public double CalculateMaterialWeight(string type, string size, int numberOfPieces)
        {
            List<MaterialDto> materials = new List<MaterialDto>(); // material list in data base???
            MaterialDto material = new MaterialDto();            

            material = materials.FirstOrDefault(m => m.Type == type && m.Size == size);
            double amountOfMaterialUnits = CalculateAmountOfMaterialUnits(type, size, numberOfPieces);

            double materialWeight = amountOfMaterialUnits * material.WeightPerUnitKg;
            // this weight per row should be added to total material weight;
            materialWeightsPerRow.Add(materialWeight);

            return materialWeight;
        }

        public double CalculateTotalWeight(List<double> materialWeightsPerRow)
        {
            // material weight from each record row should be added up into one total;
            // 
            double totalWeight = 0;
            foreach (var weight in materialWeightsPerRow)
            {
                totalWeight = totalWeight + weight;
            }

            return totalWeight;
            // it should be displayed for user in UI
        }

        public double CalculatePercentageOfLoad(List<double> materialWeightsPerRow)
        {                         
            var totalWeight = CalculateTotalWeight(materialWeightsPerRow);
            double percentageOfLoad = totalWeight / maxLoadWeight;
            // result should be formatted as % ans displayed in UI;

            return percentageOfLoad;
        }

        public string IsLoadFull(List<double> materialWeightsPerRow)
        {
            // there should be warining Message displayed on the screen that Load is exceeding 1 truck;
            string warningMessage = "Attention - load weight exceeds allowed weight per 1 truck!";
            var totalWeight = CalculateTotalWeight(materialWeightsPerRow);
            if (totalWeight > maxLoadWeight)
            {
                return warningMessage;
            }
            else
            {
                return string.Empty;
            }
            
        }

        public void SaveMaterialList()
        {
            // saves/exports current list of materials (optionally) and clears it afterwards; 
            // How to do it?
        }
    }
}
