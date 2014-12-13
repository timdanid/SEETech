using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.DataLayer;

namespace Hack.DataLayer.Entities
{
    public abstract class PracticeBase : Entity
    {
        public enum DoctorStatus
        {
            KONC = 1,
            DZ = 2
        }

        // base
        public string RUPS { get; set; }
        public string PracticeCode { get; set; }
        public string PracticeName { get; set; }
        public DoctorStatus Status { get; set; }
        public string Address { get; set; }
        public City City { get; set; }
    }
}
