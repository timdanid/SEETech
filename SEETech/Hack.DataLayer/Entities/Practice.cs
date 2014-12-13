using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.DataLayer;

namespace Hack.DataLayer.Entities
{
    public abstract class Practice : PracticeBase
    {
        // uspjesnost rada doktora
        public bool ReferToSpecialistHealthCare { get; set; }

        // kvaliteta rada doktora
        public bool PeerGroup { get; set; }

        // dodatne mogucnosti
        public bool PreventivePrograms { get; set; }
        public bool GroupPracticeOnlyForDoctorsInConcession { get; set; }
        public bool CouncilOnlyForEmployees { get; set; }
        public bool Council { get; set; }
        public bool EHealth { get; set; }
        public bool SchedulingPatients { get; set; }
    }
}
