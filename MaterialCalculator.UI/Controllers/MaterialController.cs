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
            MaterialViewModel materialModel = new MaterialViewModel()
            {
                // UI is waiting for input...;
            };

            MaterialCalculatorActions materialActions = new MaterialCalculatorActions();
            var sizes = materialActions.GetMaterialSizes(materialModel.Type);

            materialModel.Size = sizes.FirstOrDefault();
            

            return View(materialModel);
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
                WeightPerUnitKg = materialModel.WeightPerUnitKg

            };

            MaterialCalculatorActions materialActions = new MaterialCalculatorActions();            
            
            // is Id necessary at all in this case?
            materialModel.Id = materialActions.GetMaterialId(materialDto.Type, materialDto.Size);
            
            // materialModel.Size = one from dropdown List "Size" that user choses;

            materialModel.PieceSize = materialActions.GetPieceSize(materialModel.Type);

            materialModel.WeightPerUnitKg = materialActions.GetKgPerUnit(materialDto.Type, materialDto.Size);

            return View(materialModel);
        }

    }
}
