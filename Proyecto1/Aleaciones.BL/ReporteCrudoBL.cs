using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aleaciones.Entities;
using Alreaciones.DL;

namespace Aleaciones.BL
{
    public class ReporteCrudoBL
    {
        ReporteCrudoDL _reporteCrudoDL = new ReporteCrudoDL();

        public eReporteCrudo GetReporteCrudo(int CategoryValue)
        {
            return _reporteCrudoDL.GetReporteCrudo(CategoryValue);
        }
    }
}
