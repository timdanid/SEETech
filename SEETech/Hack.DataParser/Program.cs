using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Hack.DataLayer.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;
using Hack.DataLayer.Repositories;

namespace Hack.DataParser
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] opca = System.IO.File.ReadAllLines(@"C:\Hackaton\opca.csv");
            string[] predskolska = System.IO.File.ReadAllLines(@"C:\Hackaton\predskolska.csv");
            string[] zene = System.IO.File.ReadAllLines(@"C:\Hackaton\zene.csv");
            string[] zubari = System.IO.File.ReadAllLines(@"C:\Hackaton\zubari.csv");
            string[] nepotpisnici = System.IO.File.ReadAllLines(@"C:\Hackaton\nepotpisnici.csv");

            //GeneralPracticeRepository repository = new GeneralPracticeRepository();

            foreach (string line in opca)
            {
                var values = line.Split(';');
                GeneralPractice practice = new GeneralPractice();
                practice.RUPS = values[0].Trim();
                practice.PracticeCode = values[1].Trim();
                //practice.PracticeName = values[2].Trim();
                practice.DoctorStatus = values[3].Trim().ToLower() == "dz" ? DoctorStatusEnum.DZ : DoctorStatusEnum.KONC;
                practice.Address = values[4].Trim();
                practice.City = values[5].Trim();
                practice.SickLeaveRate = values[6].Trim().ToLower() == "da";
                practice.MedicationPrescription = values[7].Trim().ToLower() == "da";
                practice.ReferToSpecialistHealthCare = values[8].Trim().ToLower() == "da";
                practice.ReferToPrimaryLaboratory = values[9].Trim().ToLower() == "da";
                practice.CronicDiseasePanel = values[10].Trim().ToLower() == "da";
                practice.PeerGroup = values[11].Trim().ToLower() == "da";
                practice.PreventivePrograms = values[12].Trim().ToLower() == "da";
                practice.GroupPracticeOnlyForDoctorsInConcession = values[13].Trim().ToLower() == "da";
                practice.CouncilOnlyForEmployees = values[14].Trim().ToLower() == "da";
                practice.Council = values[15].Trim().ToLower() == "da";
                practice.EHealth = values[16].Trim().ToLower() == "da";
                practice.SchedulingPatients = values[17].Trim().ToLower() == "da";
                practice.SamplesForPrimaryLabAnalysis = values[18].Trim().ToLower() == "da";
                practice.TelephoneConsultation = values[19].Trim().ToLower() == "da";

                SetLocationProperties(practice);

                //repository.Add(practice);
            }

            foreach (string line in predskolska)
            {
                var values = line.Split(';');
                PreschoolChildrenPractice practice = new PreschoolChildrenPractice();
                practice.RUPS = values[0].Trim();
                practice.PracticeCode = values[1].Trim();
                //practice.PracticeName = values[2].Trim();
                practice.DoctorStatus = values[3].Trim().ToLower() == "dz" ? DoctorStatusEnum.DZ : DoctorStatusEnum.KONC;
                practice.Address = values[4].Trim();
                practice.City = values[5].Trim();
                practice.MedicationPrescription = values[6].Trim().ToLower() == "da";
                practice.ReferToSpecialistHealthCare = values[7].Trim().ToLower() == "da";
                practice.ReferToPrimaryLaboratory = values[8].Trim().ToLower() == "da";
                practice.PercentageOfFirstSystematicExaminationBefore2MonthsOfLife = values[9].Trim().ToLower() == "da";
                practice.FeedingPanelTracking = values[10].Trim().ToLower() == "da";
                practice.PeerGroup = values[11].Trim().ToLower() == "da";
                practice.PreventivePrograms = values[12].Trim().ToLower() == "da";
                practice.GroupPracticeOnlyForDoctorsInConcession = values[13].Trim().ToLower() == "da";
                practice.CouncilOnlyForEmployees = values[14].Trim().ToLower() == "da";
                practice.Council = values[15].Trim().ToLower() == "da";
                practice.EHealth = values[16].Trim().ToLower() == "da";
                practice.SchedulingPatients = values[17].Trim().ToLower() == "da";
                practice.TakingSamplesForPrimaryLabAnalysis = values[18].Trim().ToLower() == "da";
                practice.EmergencyPhone = values[19].Trim().ToLower() == "da";

                SetLocationProperties(practice);
            }

            foreach (string line in zene)
            {
                var values = line.Split(';');
                WomanHealthPractice practice = new WomanHealthPractice();
                practice.RUPS = values[0].Trim();
                practice.PracticeCode = values[1].Trim();
                //practice.PracticeName = values[2].Trim();
                practice.DoctorStatus = values[3].Trim().ToLower() == "dz" ? DoctorStatusEnum.DZ : DoctorStatusEnum.KONC;
                practice.Address = values[4].Trim();
                practice.City = values[5].Trim();
                practice.SickLeaveRate = values[6].Trim().ToLower() == "da";
                practice.MedicationPrescription = values[7].Trim().ToLower() == "da";
                practice.ReferToSpecialistHealthCare = values[8].Trim().ToLower() == "da";
                practice.ReferToPrimaryLaboratory = values[9].Trim().ToLower() == "da";
                practice.OlderWomenWithTVSExamination = values[10].Trim().ToLower() == "da";
                practice.YoungerWomenContraceptionCouncil = values[11].Trim().ToLower() == "da";
                practice.PeerGroup = values[12].Trim().ToLower() == "da";
                practice.PreventivePrograms = values[13].Trim().ToLower() == "da";
                practice.GroupPracticeOnlyForDoctorsInConcession = values[14].Trim().ToLower() == "da";
                practice.CouncilOnlyForEmployees = values[15].Trim().ToLower() == "da";
                practice.Council = values[16].Trim().ToLower() == "da";
                practice.EHealth = values[17].Trim().ToLower() == "da";
                practice.SchedulingPatients = values[18].Trim().ToLower() == "da";
                practice.TakingSamplesForPrimaryLabAnalysis = values[19].Trim().ToLower() == "da";
                practice.TakingAndDeliveryOfSamplesForMicrobiologyDiagnostics = values[20].Trim().ToLower() == "da";

                SetLocationProperties(practice);
            }

            foreach (string line in zubari)
            {
                var values = line.Split(';');
                DentalPractice practice = new DentalPractice();
                practice.RUPS = values[0].Trim();
                practice.PracticeCode = values[1].Trim();
                //practice.PracticeName = values[2].Trim();
                practice.DoctorStatus = values[3].Trim().ToLower() == "dz" ? DoctorStatusEnum.DZ : DoctorStatusEnum.KONC;
                practice.Address = values[4].Trim();
                practice.City = values[5].Trim();
                practice.ReferToSpecialistHealthCare = values[6].Trim().ToLower() == "da";
                practice.PortionOfPreventiveProcedures = values[7].Trim().ToLower() == "da";
                practice.PersonsWithDentalStatus = values[8].Trim().ToLower() == "da";
                practice.PeerGroup = values[9].Trim().ToLower() == "da";
                practice.PreventivePrograms = values[10].Trim().ToLower() == "da";
                practice.GroupPracticeOnlyForDoctorsInConcession = values[11].Trim().ToLower() == "da";
                practice.CouncilOnlyForEmployees = values[12].Trim().ToLower() == "da";
                practice.Council = values[13].Trim().ToLower() == "da";
                practice.EHealth = values[14].Trim().ToLower() == "da";
                practice.SchedulingPatients = values[15].Trim().ToLower() == "da";
                practice.EmergencyPhone = values[16].Trim().ToLower() == "da";
                practice.SpecialNeedsDentalCare = values[17].Trim().ToLower() == "da";

                SetLocationProperties(practice);
            }

            foreach (string line in nepotpisnici)
            {
                var values = line.Split(';');
                UnsignedPractice practice = new UnsignedPractice();
                practice.RUPS = values[0].Trim();
                practice.PracticeCode = values[1].Trim();
                //practice.PracticeName = values[2].Trim();
                practice.DoctorStatus = values[3].Trim().ToLower() == "dz" ? DoctorStatusEnum.DZ : DoctorStatusEnum.KONC;
                practice.Address = values[4].Trim();
                practice.City = values[5].Trim();

                SetLocationProperties(practice);
            }

        }

        static void SetLocationProperties(PracticeBase practice)
        {
            string[] novo = System.IO.File.ReadAllLines(@"C:\Hackaton\novo.csv");
            string[] koordinate = System.IO.File.ReadAllLines(@"C:\Hackaton\koordinate.csv");

            foreach (string line2 in novo)
            {
                var values2 = line2.Split(';');
                string code = values2[1].Trim();

                if (code == practice.PracticeCode)
                {
                    practice.PracticeName = values2[2].Trim();
                    practice.BusinessArea = values2[3].Trim();
                    practice.PracticeType = values2[4].Trim();
                    practice.POBox = values2[8].Trim();
                    practice.Email = values2[10].Trim();
                    practice.OfficePhone = values2[11].Trim();
                    practice.ContactPhone = values2[12].Trim();
                    practice.WorkingHours = values2[13].Trim();

                    string geoid = values2[14].Trim();

                    foreach (string line3 in koordinate)
                    {
                        var values3 = line3.Split(';');
                        string geoid2 = values3[0].Trim();

                        if (geoid == geoid2)
                        {
                            practice.County = values3[12].Trim();
                            practice.Country = values3[13].Trim();
                            practice.CoordinateX = values3[14].Trim();
                            practice.CoordinateY = values3[15].Trim();
                        }
                    }
                }
            }
        }
    }
}
