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
        // base
        public string RUPS { get; set; }
        public string PracticeCode { get; set; }
        public string PracticeName { get; set; }
        public DoctorStatusEnum DoctorStatus { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
    }
}
