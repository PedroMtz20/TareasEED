using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alreaciones.DL;
using Aleaciones.Entities;

namespace Aleaciones.BL
{
    public class GoalBL
    {
        private GoalDL _GoalDL = new GoalDL();

        public readonly StringBuilder stringBuilder = new StringBuilder();

        public List<eGoal> GetAll()
        {
            return _GoalDL.GetAll();
        }

        public eGoal GetById(int IDMeta)
        {
            stringBuilder.Clear();

            if (IDMeta == 0) stringBuilder.Append("Por favor proporcione un valor de Id valido");

            if (stringBuilder.Length == 0)
            {
                return _GoalDL.GetById(IDMeta);
            }
            return null;
        }

        public void Delete(int IDMeta)
        {
            stringBuilder.Clear();

            if (IDMeta == 0) stringBuilder.Append("Por favor proporcione un valor de Id valido");

            if (stringBuilder.Length == 0)
            {
                _GoalDL.Delete(IDMeta);
            }
        }

        public void Register(eGoal Goal)
        {
            _GoalDL.Insert(Goal);
        }

    }
}
