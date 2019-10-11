using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aleaciones.Entities
{
    public class eReporteCrudo
    {
        public DateTime Bandera1 { get; set; }
        public DateTime Bandera2 { get; set; }
        public DateTime Bandera3 { get; set; }
        public double Sample_ca { get; set; }
        public double Sample_es { get; set; }
        public TimeSpan diff1 { get; set; }
        public TimeSpan diff2 { get; set; }
        public TimeSpan diff3 { get; set; }
    }
}
