//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hack.DataLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class Practice
    {
        public int ID { get; set; }
        public string RUPS { get; set; }
        public string PracticeCode { get; set; }
        public string PracticeName { get; set; }
        public int PracticeTypeID { get; set; }
        public int DoctorStatusID { get; set; }
        public string Address { get; set; }
        public int CityID { get; set; }
        public string BusinessArea { get; set; }
        public string PracticeTypeDescription { get; set; }
        public string Email { get; set; }
        public string OfficePhone { get; set; }
        public string ContactPhone { get; set; }
        public string WorkingHours { get; set; }
        public string CoordinateX { get; set; }
        public string CoordinateY { get; set; }
        public int NumberOfPatients { get; set; }
        public bool ReferToSpecialistHealthCare { get; set; }
        public bool PeerGroup { get; set; }
        public bool PreventivePrograms { get; set; }
        public bool GroupPracticeOnlyForDoctorsInConcession { get; set; }
        public bool CouncilOnlyForEmployees { get; set; }
        public bool Council { get; set; }
        public bool EHealth { get; set; }
        public bool SchedulingPatients { get; set; }
        public Nullable<bool> SickLeaveRate { get; set; }
        public Nullable<bool> MedicationPrescription { get; set; }
        public Nullable<bool> ReferToPrimaryLaboratory { get; set; }
        public Nullable<bool> CronicDiseasePanel { get; set; }
        public Nullable<bool> SamplesForPrimaryLabAnalysis { get; set; }
        public Nullable<bool> TelephoneConsultation { get; set; }
        public Nullable<bool> PercentageOfFirstSystematicExaminationBefore2MonthsOfLife { get; set; }
        public Nullable<bool> FeedingPanelTracking { get; set; }
        public Nullable<bool> TakingSamplesForPrimaryLabAnalysis { get; set; }
        public Nullable<bool> EmergencyPhone { get; set; }
        public Nullable<bool> OlderWomenWithTVSExamination { get; set; }
        public Nullable<bool> YoungerWomenContraceptionCouncil { get; set; }
        public Nullable<bool> TakingAndDeliveryOfSamplesForMicrobiologyDiagnostics { get; set; }
        public Nullable<bool> PortionOfPreventiveProcedures { get; set; }
        public Nullable<bool> PersonsWithDentalStatus { get; set; }
        public Nullable<bool> SpecialNeedsDentalCare { get; set; }
    
        public virtual City City { get; set; }
        public virtual DoctorStatus DoctorStatus { get; set; }
        public virtual PracticeType PracticeType { get; set; }
    }
}
