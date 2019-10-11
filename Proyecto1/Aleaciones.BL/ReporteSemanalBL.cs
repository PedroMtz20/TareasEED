using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alreaciones.DL;

namespace Aleaciones.BL
{
    public class ReporteSemanalBL
    {
        private ReporteSemanalDL _reporte = new ReporteSemanalDL();

        public List<TimeSpan> Avgtimes(int i, DateTime j, DateTime z)
        {
                return _reporte.AvgTimes(i, j, z);
        }

        public List<TimeSpan> AvgtimesLingotes(int i, DateTime j, DateTime z)
        {
            return _reporte.AvgTimesLingotes(i, j, z);
        }

        public List<TimeSpan> AvgtimesEquipos(DateTime j, DateTime z, string TurnoBajo, string TurnoAlto)
        {
            return _reporte.AvgTimesEquipos(j, z, TurnoBajo, TurnoAlto);
        }

        public List<TimeSpan> AvgtimesLingotesEquipos(DateTime j, DateTime z, string TurnoBajo, string TurnoAlto)
        {
            return _reporte.AvgTimeLingotesEquipos(j, z, TurnoBajo, TurnoAlto);
        }

        public List<DateTime> GetTurnos()
        {
            return _reporte.GetTurnos();
        }
    }
}
