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
        public List<string> GetMaterialType()
        {
            List<string> types = new List<string>();

            List<MaterialDto> materials;

            using (var context = new MaterialCalculatorDBContext())
            {
                materials = context.Materials.ToList();
                // can not be null....???
            }

            foreach (var item in materials)
            {
                types.Add(item.Type);
            }

            return types;
        }
    }
}
