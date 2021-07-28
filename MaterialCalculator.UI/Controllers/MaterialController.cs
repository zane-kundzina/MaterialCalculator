using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaterialCalculator.UI.Models;
using MaterialCalculator.Entity;
using MaterialCalculator.BLL;


namespace MaterialCalculator.UI.Controllers
{
    public class MaterialController : Controller
    {
        public IActionResult Index()
        {
            var actions = new MaterialCalculatorActions();
            var materialData = new MaterialDataViewModel();

            var listOfTypes = actions.GetMaterialTypes();

            materialData.Types = listOfTypes;

            return View(materialData);
        }

        //public IActionResult GetMaterialInfo(string type, string size)
        //{   
        //    MaterialViewModel materialModel = new MaterialViewModel()
        //    {                
        //        Type = type    
        //    };

        //    MaterialDto materialDto = new MaterialDto()
        //    {
        //        Id = materialModel.Id,
        //        Type = materialModel.Type,
        //        PieceSize = materialModel.PieceSize,
        //        WeightPerUnit = materialModel.WeightPerUnit
        //    };

        //    MaterialCalculatorActions materialActions = new MaterialCalculatorActions(); 
            
        //    var sizes = materialActions.GetMaterialSizes(materialModel.Type);
            
        //    materialModel.PieceSize = materialActions.GetPieceSize(materialModel.Type);
                       
        //    return View(materialModel);
        //}

        [HttpPost]
        public List<string> GetMaterialTypes()
        {
            var actions = new MaterialCalculatorActions();

            var listOfTypes = actions.GetMaterialTypes();

            return listOfTypes;
        }

        [HttpPost]
        public MaterialDataViewModel GetMaterialSizes(string type, string size)   // argument should be passed from dropdown list "Types"
        {
            var actions = new MaterialCalculatorActions();

            var materialData = new MaterialDataViewModel();

            var listOfSizes = actions.GetMaterialSizes(type);

            var pieceSize = actions.GetPieceSize(type, size);

            materialData.Sizes = listOfSizes;

            materialData.PieceSize = pieceSize;

            return materialData;
        }

        [HttpPost]
        public double GetPieceSize(string type, string size)   // argument should be passed from dropdown list "Types"
        {
            var actions = new MaterialCalculatorActions(); 
            

            var pieceSize = actions.GetPieceSize(type, size);

            return pieceSize;

        }

        [HttpPost]
        public double CalculateAmountOfMaterialUnits(string type, string size)
        {
            var actions = new MaterialCalculatorActions();

            var numberOfMaterialUnits = actions.CalculateAmountOfMaterialUnits(type, size);

            return numberOfMaterialUnits;
        }

        //[HttpPost]
        //public double GetWeightPerUnit(string type, string size)
        //{
        //    var actions = new MaterialCalculatorActions();

        //    var weightPerUnit = actions.GetWeightPerUnit(type, size);

        //    return weightPerUnit;
        //}

        [HttpPost]
        public double CalculateMaterialWeight(string type, string size)
        {
            var actions = new MaterialCalculatorActions();

            var materialWeight = actions.CalculateMaterialWeight(type, size);

            return materialWeight;
        }

        [HttpPost]
        public double CalculateMaterialCost(string type, string size)
        {
            var actions = new MaterialCalculatorActions();

            var materialCost = actions.CalculateMaterialCost(type, size);

            return materialCost;
        }

        [HttpPost]
        public double CalculateTotalWeight(List<double> materialWeightsPerRow)
        {
            var actions = new MaterialCalculatorActions();

            var totalWeight = actions.CalculateTotalWeight(materialWeightsPerRow);

            return totalWeight;
        }

        [HttpPost]
        public double CalculatePercentageOfLoad(List<double> materialWeightsPerRow)
        {
            var actions = new MaterialCalculatorActions();

            var percentageOfLoad = actions.CalculatePercentageOfLoad(materialWeightsPerRow);

            return percentageOfLoad;
        }

        [HttpPost]
        public string IsLoadFull(List<double> materialWeightsPerRow)
        {
            var actions = new MaterialCalculatorActions();

            var isLoadFull = actions.IsLoadFull(materialWeightsPerRow);

            return isLoadFull;
        }
    }
}
