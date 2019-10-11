using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aleaciones.Entities;
using Alreaciones.DL;

namespace Aleaciones.BL
{
    public class UsersBL
    {
        private UserDL _UserDL = new UserDL();

        public readonly StringBuilder stringBuilder = new StringBuilder();

        public void Register(eUser User)
        {
            if (ValidateUser(User))
            {
                if (_UserDL.GetById(User.idUser) == null)
                {
                    _UserDL.Insert(User);
                }
                else
                    _UserDL.Update(User);
            }
        }

        public List<eUser> All()
        {
            return _UserDL.GetAll();
        }

        public eUser GetById(int idUser)
        {
            stringBuilder.Clear();

            if (idUser == 0) stringBuilder.Append("Por favor proporcione un valor de Id valido");

            if (stringBuilder.Length == 0)
            {
                return _UserDL.GetById(idUser);
            }
            return null;
        }

        public void Delete(int idUser, int User)
        {
            stringBuilder.Clear();

            if (idUser == 0) stringBuilder.Append("Por favor proporcione un valor de Id valido");

            if (stringBuilder.Length == 0)
            {
                _UserDL.Delete(idUser, User);
            }
        }

        private bool ValidateUser(eUser User)
        {
            stringBuilder.Clear();

            if (string.IsNullOrEmpty(User.namUser)) stringBuilder.Append("El campo Código Usero es obligatorio");
            return stringBuilder.Length == 0;
        }

        public eUser ValidateLogin(string namUser, string userPass)
        {
            return _UserDL.ValidateUser(namUser, userPass);
        }   
    }
}
