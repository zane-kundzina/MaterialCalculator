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

            var listOfTypes = actions.GetMaterialType();  

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
        public List<string> GetValue(string type)
        {
            var materialCalc = new MaterialCalculatorActions();
            //var size = materialCalc.GetPieceSize(data);
            return new List<string>() { "1", "2", "3", "4", "5" };
        }
    }
}
