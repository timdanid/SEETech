using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hack.DataLayer.Entities
{
    public sealed class GeneralPractice : Practice
    {
        public bool SickLeaveRate { get; set; }
        public bool MedicationPrescription { get; set; }
        public bool ReferToPrimaryLaboratory { get; set; }
        public bool CronicDiseasePanel { get; set; }
        public bool SamplesForPrimaryLabAnalysis { get; set; }
        public bool TelephoneConsultation { get; set; }
    }
}
