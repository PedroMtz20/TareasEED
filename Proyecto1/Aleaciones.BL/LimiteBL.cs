using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alreaciones.DL;
using Aleaciones.Entities;

namespace Aleaciones.BL
{
    public class LimiteBL
    {
        private LimiteDL _LimiteDL = new LimiteDL();

        public readonly StringBuilder stringBuilder = new StringBuilder();

        public List<eLimite> All()
        {
            return _LimiteDL.GetAll();
        }

        public eLimite GetById(int idProfile)
        {
            stringBuilder.Clear();

            if (idProfile == 0) stringBuilder.Append("Por favor proporcione un valor de Id valido");

            if (stringBuilder.Length == 0)
            {
                return _LimiteDL.GetById(idProfile);
            }
            return null;
        }

        public void Delete(int idLimit)
        {
            stringBuilder.Clear();

            if (idLimit == 0) stringBuilder.Append("Por favor proporcione un valor de Id valido");

            if (stringBuilder.Length == 0)
            {
                _LimiteDL.Delete(idLimit);
            }
        }

        public void Register(eLimite Limite)
        {
            _LimiteDL.Insert(Limite);
        }
    }
}
