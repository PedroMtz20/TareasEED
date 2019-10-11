using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aleaciones.Entities
{
    public class eAnalisis
    {
        public string CategoryName { get; set; }
        public int CategoryValue { get; set; }
        public DateTime subGroupDateTime { get; set; }
        public string CharacterisitcName { get; set; }
        public double Sample { get; set; }
        public int target { get; set; }
        public int max { get; set; }

        public double LRL { get; set; }
        public double URL { get; set; }
    }
}
