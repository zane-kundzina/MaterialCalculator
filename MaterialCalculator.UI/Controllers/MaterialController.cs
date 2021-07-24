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

            var listOfTypes = actions.GetMaterialTypes();  

            return View(listOfTypes);
        }

        public IActionResult GetMaterialInfo(string type, string size)
        {
            // code according to AnimalEngine example....

            MaterialViewModel materialModel = new MaterialViewModel()
            {
                // Type and size should be get from user input fro UI and according to this data from data base should be collected -
                // PieceSize, WeightPerUnitKg;
                Type = type,
                Size = size     // sizes are offered in dropdown list according to type chosen...
            };

            MaterialDto materialDto = new MaterialDto()
            {
                Id = materialModel.Id,
                Type = materialModel.Type,
                Size = materialModel.Size,
                PieceSize = materialModel.PieceSize,
                WeightPerUnit = materialModel.WeightPerUnit

            };

            MaterialCalculatorActions materialActions = new MaterialCalculatorActions();            
            
            // is Id necessary at all in this case?
            //materialModel.Id = materialActions.GetMaterialId(materialDto.Type, materialDto.Size);
            
            var sizes = materialActions.GetMaterialSizes(materialModel.Type);
            // materialModel.Size = one from dropdown List "Size" that user choses;

            materialModel.PieceSize = materialActions.GetPieceSize(materialModel.Type);

            //materialModel.WeightPerUnitKg = materialActions.GetKgPerUnit(materialDto.Type, materialDto.Size);

            return View(materialModel);
        }

        [HttpPost]
        public List<string> GetMaterialTypes()
        {
            var actions = new MaterialCalculatorActions();

            var listOfTypes = actions.GetMaterialTypes();

            return listOfTypes;
        }

        [HttpPost]
        public List<string> GetMaterialSizes(string type)   // argument should be passed from dropdown list "Types"
        {
            var actions = new MaterialCalculatorActions();           

            var listOfSizes = actions.GetMaterialSizes(type);

            return listOfSizes;

            //var size = materialCalculator.GetPieceSize(data);
            //return new List<string>() { "1", "2", "3", "4", "5" };
        }

        [HttpPost]
        public double GetPieceSize(string type)   // argument should be passed from dropdown list "Types"
        {
            var actions = new MaterialCalculatorActions();           

            var pieceSize = actions.GetPieceSize(type);

            return pieceSize;

        }

        [HttpPost]
        public double CalculateAmountOfMaterialUnits(string type, string size)
        {
            var actions = new MaterialCalculatorActions();

            var numberOfMaterialUnits = actions.CalculateAmountOfMaterialUnits(type, size);

            return numberOfMaterialUnits;
        }

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
