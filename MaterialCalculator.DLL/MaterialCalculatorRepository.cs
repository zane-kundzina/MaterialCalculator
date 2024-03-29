﻿using MaterialCalculator.DAL.Context;
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
        List<double> materialWeightsPerRow = new List<double> ();

        public double maxLoadWeight { get; set; } = 24;
        public List<string> GetMaterialTypes ()
        {
            using(var context = new MaterialCalculatorDBContext () )
            {
                return context.MaterialTypes.Select ( x => x.TypeName ).ToList();
            }
        }

        //public List<string> GetMaterialTypes1 ()
        //{
        //    List<string> types = new List<string> ();
        //    List<MaterialDto> materials;

        //    using ( var context = new MaterialCalculatorDBContext () )
        //    {
        //        materials = context?.Materials?.ToList ();
        //    }

        //    for ( int i = 0; i < materials.Count - 1; i++ )
        //    {
        //        if ( materials [i] != materials [i + 1] )
        //        {
        //            types.Add ( materials [i].Type );
        //        }
        //    }

        //    return types;
        //}

        public List<string> GetMaterialSizes ( string type )   // type should be get from dropdown list "Type" - what user has chosen
        {
            List<string> sizes = new List<string> ();           

            using ( var context = new MaterialCalculatorDBContext () )
            {  
                var materialType = context.MaterialTypes.Where(x => x.TypeName == type).FirstOrDefault();

                sizes = context.Materials.Where ( x => x.TypeId == materialType.Id )
                    .Select ( x => x.Size ).ToList ();                
            }

            return sizes;
        }

        // type is get from dropdown list "Type" - what user has chosen
        public double GetPieceSize ( string type, string size )   
        {             
            var materialTypes = new MaterialTypesDto();
            var materials = new MaterialDto();
            var pieceSize = new PieceSizesDto();

            using ( var context = new MaterialCalculatorDBContext () )
            {
                materialTypes = context.MaterialTypes.Where(x => x.TypeName == type).FirstOrDefault();
                materials = context.Materials.Where(x => x.TypeId == materialTypes.Id).FirstOrDefault();
                pieceSize = context.PieceSizes.Where(x => x.Material.Id == materials.Id).FirstOrDefault();
            } 
            return pieceSize.PieceSize;
        }

        // type and size should be get from dropdown list "Type" & "Size" - what user has chosen
        //public double GetWeightPerUnit ( string type, string size )   
        //{            
        //    var materialTypes = new MaterialTypesDto();
        //    var material = new MaterialDto();
        //    var pieceSize = new PieceSizesDto();
        //    //var weightPerUnit = 0;

        //    using (var context = new MaterialCalculatorDBContext())
        //    {
        //        materialTypes = context.MaterialTypes.Where(x => x.TypeName == type).FirstOrDefault();
        //        material = context.Materials.Where(x => x.TypeId == materialTypes.Id).FirstOrDefault();
        //        //weightPerUnit = Convert.ToInt32( context.Materials.Where(x => x.TypeId == material.TypeId).Select(x => x.WeightPerUnit).FirstOrDefault());
        //    }

        //    //using ( var context = new MaterialCalculatorDBContext () )
        //    //{
        //    //    materials = context.Materials.ToList ();
        //    //    materialSizes = context.MaterialSizes.ToList ();
        //    //}

            

        //    //var weightPerUnit = material.WeightPerUnit;

        //    return material.WeightPerUnit;
        //}

        public double GetNumberOfPieces ()
        {
            double numberOfPieces = 0;

            // var numberOfPieces = number received from UI - user input in input field; // User inputs number of pieces 
            // how to do/get this data?

            return numberOfPieces;
        }

        public double CalculateAmountOfMaterialUnits ( string type, string size )  // type & size should be get from dropdown list "Type" & "Size" - what user has chosen; how to point to it?
        {
            // according to material.Type and material.Size choice and number of pieces input from UI,method have to calculate total amount of units (m/m2)

            var pieceSize = GetPieceSize ( type, size );
            var amountOfMaterialUnits = pieceSize * GetNumberOfPieces ();

            return amountOfMaterialUnits;
        }

        public double CalculateMaterialWeight ( string type, string size )
        {
            List<MaterialDto> materials;

            using ( var context = new MaterialCalculatorDBContext () )
            {
                materials = context.Materials.ToList ();
            }

           // var material = materials.FirstOrDefault ( m => m.TypeId == type );

            double amountOfMaterialUnits = CalculateAmountOfMaterialUnits ( type, size );

            //double materialWeight = amountOfMaterialUnits * material.WeightPerUnit / 1000;

            // this weight per each row should be added to total material weight;
            materialWeightsPerRow.Add ( 0 );

            return 0;
        }

        public double CalculateTotalWeight ( List<double> materialWeightsPerRow )
        {
            // material weight from each record row should be added up into one total;

            double totalWeight = 0;
            foreach ( var weight in materialWeightsPerRow )
            {
                totalWeight = totalWeight + weight;
            }

            return totalWeight;
        }
    }
}
