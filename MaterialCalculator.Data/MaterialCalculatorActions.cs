using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaterialCalculator.BLL;
using MaterialCalculator.Entity;
using MaterialCalculator.DAL;

namespace MaterialCalculator.BLL
{
    public class MaterialCalculatorActions
    {
        // place for logic; entity objects are used in BLL; methods        

        

        List<double> materialWeightsPerRow = new List<double>();
        const double maxLoadWeight = 24;

        public List<string> GetMaterialType()
        {
            var repo = new MaterialCalculatorRepository();
            
            
            
            // method have to offer list of available material types in dropdown list
            // list in UI "Type" for further choice;
            // How to get data from data base into dropdown list in UI???            

            // SQL query? to get list of types available?

            //SELECT DISTINCT Type
            //FROM Materials

            //List<MaterialDto> materials = new List<MaterialDto>(); // should be material list from data base, How/where to write it???
            //List<string> types = new List<string>();    // lsit of sizes availablo for type chosed should appear in dropdown list "Size" to chose it in UI;

            //foreach (var material in materials)
            //{                
            //    var type = material.Type;
            //    types.Add(type);
            //}  



            return repo.GetMaterialType();
            // list of sizes should be displayed in dropdown list in UI;
            // how to do it?
        }

        public List<string> GetMaterialSizes(string type)
        {
            // according to material.Type choice from UI, method have to offer list of available material sizes in dropdown
            // list in UI "Size" dropdown list for further choice;
            // how to get data from db in UI in dropdown list?

            // SQL query? to get list of types available? How/where to write in?

            // SELECT Size
            // FROM Materials
            // WHERE Type = “type chosed by user from dropdown list”

            List<MaterialDto> materials = new List<MaterialDto>(); // how to get material list from data base???
            List<string> sizes = new List<string>();    // list of sizes availablo for type chosed should appear in dropdown list "Size" to chose it in UI;

            // is following foreach loop necessary at all if SQL query is executed and appropriate sizes found? how to add them to the list what to return
            // and show in dropdown list?
            
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

            // SELECT PieceSize
            // FROM Materials
            // WHERE Type = “type chosed by user from dropdown list”

            List<MaterialDto> materials = new List<MaterialDto>(); // material list in data base???

            var material = materials.FirstOrDefault(m => m.Type == type);
            var pieceSize = material.PieceSize;

            return pieceSize;
            // pieceSize should be displayed in UI for material type chosen - how to do it?
            // how to do it?
        }

        public double GetNumberOfPieces()
        { 
            double numberOfPieces = 0;

            // var numberOfPieces = number received from UI - user input;
            // how to do this?

            return numberOfPieces;
        }

        public double GetWeightPerUnit(string type, string size)
        {
            // according to material.Type and material.Size choice from UI, method have to find weight of this material per unit from data base

            // SELECT WeightPerUnit
            // FROM Materials
            // WHERE Type = “type chosed by user from dropdown list” && Size = “size chosed by user from dropdown list”

            List<MaterialDto> materials = new List<MaterialDto>(); // material list from data base???

            var material = materials.FirstOrDefault(m => m.Type == type && m.Size == size);
            var weightPerUnit = material.WeightPerUnit;

            return weightPerUnit;
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
            // should there be a "current material" as object which to work with in each record line?
            
            List<MaterialDto> materials = new List<MaterialDto>(); // material list in data base???
            MaterialDto currentMaterial = new MaterialDto();            

            currentMaterial = materials.FirstOrDefault(m => m.Type == type && m.Size == size);
            double amountOfMaterialUnits = CalculateAmountOfMaterialUnits(type, size, numberOfPieces);

            double materialWeight = amountOfMaterialUnits * currentMaterial.WeightPerUnit;
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
            // result should be formatted as % ans displayed in UI - how to do this?

            return percentageOfLoad;
        }

        public string IsLoadFull(List<double> materialWeightsPerRow)
        {
            // there should be warning Message displayed on the screen that Load is exceeding 1 truck;
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


        // it is not necessary at the moment
        public void SaveMaterialList()
        {
            // saves/exports current list of materials (optionally) and clears it afterwards; 
            // How to do it?
        }
    }
}
