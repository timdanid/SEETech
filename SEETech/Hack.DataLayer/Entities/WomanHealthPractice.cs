using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hack.DataLayer.Entities
{
    public sealed class WomanHealthPractice : Practice
    {
        public bool SickLeaveRate { get; set; }
        public bool MedicationPrescription { get; set; }
        public bool ReferToPrimaryLaboratory { get; set; }
        public bool OlderWomenWithTVSExamination { get; set; }
        public bool YoungerWomenContraceptionCouncil { get; set; }
        public bool TakingSamplesForPrimaryLabAnalysis { get; set; }
        public bool TakingAndDeliveryOfSamplesForMicrobiologyDiagnostics { get; set; }
    }
}
