using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaterialCalculator.UI.Models
{
    public class PieceSizesViewModel
    {
        public int Id { get; set; }
        public string PieceSizeName { get; set; }

        public MaterialViewModel Material { get; set; }
    }
}
