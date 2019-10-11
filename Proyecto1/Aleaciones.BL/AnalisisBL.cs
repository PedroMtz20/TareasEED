using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using Aleaciones.Entities;
using Alreaciones.DL;

namespace Aleaciones.BL
{
    public class AnalisisBL
    {
        private AnalisisDl _AnalisisDL = new AnalisisDl();
        
        public TimeSpan AvgTimeLingotes(int i)
        {
            return _AnalisisDL.AvgTimesLingotes(i);
        }

        public DateTime[,] GetByLinea()
        {
            return _AnalisisDL.GetAnalisisByLinea();
        }

        public double[,] GetByPorcentaje()
        {
            return _AnalisisDL.GetAnalisisByPorcenteaje();

        }

        public string GetAnalisisLingotesRecomendados(int i)
        {
            return _AnalisisDL.AnalisisLingotesRecomendadados(i);
        }

        public int CantidadLingotes(float calcio, float estano, string formula)
        {
            return _AnalisisDL.CantidadLingotes(calcio,estano,formula);
        }

        public int SumaLingotes(int i, DateTime time)
        {
            return _AnalisisDL.SumaLingotes(i, time);
        }

        public int GetMaxLinea(int j)
        {
            return _AnalisisDL.getMax(j);
        }

    }
}
