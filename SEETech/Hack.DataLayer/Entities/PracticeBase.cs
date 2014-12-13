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

        // locations.csv
        public string BusinessArea { get; set; }
        public string PracticeTypeString { get; set; }
        public string POBox { get; set; }
        public string Email { get; set; }
        public string OfficePhone { get; set; }
        public string ContactPhone { get; set; }
        public string WorkingHours { get; set; }
        
        // coordinates.csv
        public string County { get; set; }
        public string Country { get; set; }
        public string CoordinateX { get; set; }
        public string CoordinateY { get; set; }

        // patients
        public int NumberOfPatients { get; set; }
        public int MinimumNumberOfPatients { get; set; }
        public int AverageNumberOfPatients { get; set; }
        public int MaximumNumberOfPatients { get; set; }

        public PracticeTypeEnum PracticeType { get; set; }
    }
}
