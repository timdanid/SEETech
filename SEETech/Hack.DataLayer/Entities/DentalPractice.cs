using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hack.DataLayer.Entities
{
    public sealed class DentalPractice : Practice
    {
        public bool PortionOfPreventiveProcedures { get; set; }
        public bool PersonsWithDentalStatus { get; set; }
        public bool EmergencyPhone { get; set; }
        public bool SpecialNeedsDentalCare { get; set; }
    }
}
