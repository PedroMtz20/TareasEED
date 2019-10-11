using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aleaciones.Entities
{
    public class eProfile
    {
        public int idUserProfile { get; set; }
        public int idUser { get; set; }
        public int idProfile { get; set; }
        public int? createdBy { get; set; }
        public DateTime? createdDate { get; set; }
        public int? modifiedBy { get; set; }
        public DateTime? modifiedDate { get; set; }
    }
}
