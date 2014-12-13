using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hack.DataLayer.Entities
{
    public sealed class PreschoolChildrenPractice : Practice
    {
        public bool MedicationPrescription { get; set; }
        public bool ReferToPrimaryLaboratory { get; set; }
        public bool PercentageOfFirstSystematicExaminationBefore2MonthsOfLife { get; set; }
        public bool FeedingPanelTracking { get; set; }
        public bool TakingSamplesForPrimaryLabAnalysis { get; set; }
        public bool EmergencyPhone { get; set; }
    }
}
