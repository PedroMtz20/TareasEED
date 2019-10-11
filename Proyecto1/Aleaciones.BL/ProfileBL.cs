using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alreaciones.DL;
using Aleaciones.Entities;

namespace Aleaciones.BL
{
    public class ProfileBL
    {
        private ProfileDL _ProfileDL = new ProfileDL();

        public readonly StringBuilder stringBuilder = new StringBuilder();

        public List<eProfile> All()
        {
            return _ProfileDL.GetAll();
        }

        public eProfile GetById(int idProfile)
        {
            stringBuilder.Clear();

            if (idProfile == 0) stringBuilder.Append("Por favor proporcione un valor de Id valido");

            if (stringBuilder.Length == 0)
            {
                return _ProfileDL.GetById(idProfile);
            }
            return null;
        }
    }
}
