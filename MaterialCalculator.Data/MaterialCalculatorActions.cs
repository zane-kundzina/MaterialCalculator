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

        
        

        public List<string> GetMaterialType()
        {
            var repo = new MaterialCalculatorRepository();    

            return repo.GetMaterialType();            
        }

        public List<string> GetMaterialSizes(string type)   // type should be get from dropdown list "Type" - what user has chosen; how to point to it?
        {
            var repo = new MaterialCalculatorRepository();

            return repo.GetMaterialSizes(type);            
        }

        public double GetPieceSize(string type)     // type should be get from dropdown list "Type" - what user has chosen; how to point to it?
        {
            // according to material.Type choice from UI, method have to offer piece size for this material type from data base

            var repo = new MaterialCalculatorRepository();

            return repo.GetPieceSize(type);
            // pieceSize should be displayed in UI for material type chosen - how to do it?
            // how to do it?
        }

        public double GetNumberOfPieces()
        {
            var repo = new MaterialCalculatorRepository();            

            // var numberOfPieces = number received from UI - user input in input field; // User inputs number of pieces 
            // how to do/get this data?

            return repo.GetNumberOfPieces();
        }

        public double GetWeightPerUnit(string type, string size)    // type & size should be get from dropdown list "Type" & "Size" - what user has chosen; how to point to it?
        {
            // according to material.Type and material.Size choice from UI, method have to find weight of this material per unit from data base
            var repo = new MaterialCalculatorRepository();

            return repo.GetWeightPerUnit(type, size);
        }

        public double CalculateAmountOfMaterialUnits(string type, string size)  // type & size should be get from dropdown list "Type" & "Size" - what user has chosen; how to point to it?
        {
            // according to material.Type and material.Size choice and number of pieces input from UI,method have to calculate total amount of units (m/m2)
            var repo = new MaterialCalculatorRepository();                    

            return repo.CalculateAmountOfMaterialUnits(type, size);   // should be shown in the UI table
        }

        public double CalculateMaterialWeight(string type, string size)
        {
            // should there be a "current material" as object which to work with in each record line?
            var repo = new MaterialCalculatorRepository();

            return repo.CalculateMaterialWeight(type, size);
        }

        public double CalculateMaterialCost(string type, string size)
        {
            var repo = new MaterialCalculatorRepository();

            double pricePerTon = 0;
            double materialCostPerRow = pricePerTon * repo.CalculateMaterialWeight(type, size);

            return materialCostPerRow;
        }

        public double CalculateTotalWeight(List<double> materialWeightsPerRow)
        {
            // material weight from each record row should be added up into one total;
             
            var repo = new MaterialCalculatorRepository();

            return repo.CalculateTotalWeight(materialWeightsPerRow); ;
            // it should be displayed for user in UI
        }

        public double CalculatePercentageOfLoad(List<double> materialWeightsPerRow)
        {
            var repo = new MaterialCalculatorRepository();

            var totalWeight = CalculateTotalWeight(materialWeightsPerRow);
            double percentageOfLoad = totalWeight / repo.maxLoadWeight;
            
            // result should be formatted as % ans displayed in UI - how to do this?
            return percentageOfLoad;
        }

        public string IsLoadFull(List<double> materialWeightsPerRow)
        {
            var repo = new MaterialCalculatorRepository();

            // there should be warning Message displayed on the screen that Load is exceeding 1 truck;
            string warningMessage = "Attention - load weight exceeds allowed weight per 1 truck!";
            var totalWeight = CalculateTotalWeight(materialWeightsPerRow);
            if (totalWeight > repo.maxLoadWeight)
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
