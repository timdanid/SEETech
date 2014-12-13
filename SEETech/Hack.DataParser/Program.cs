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
            Console.WriteLine("Reading files...");

            string[] opca = System.IO.File.ReadAllLines(@"C:\Hackaton\opca.csv");
            string[] predskolska = System.IO.File.ReadAllLines(@"C:\Hackaton\predskolska.csv");
            string[] zene = System.IO.File.ReadAllLines(@"C:\Hackaton\zene.csv");
            string[] zubari = System.IO.File.ReadAllLines(@"C:\Hackaton\zubari.csv");
            string[] nepotpisnici = System.IO.File.ReadAllLines(@"C:\Hackaton\nepotpisnici.csv");

            string[] novo = System.IO.File.ReadAllLines(@"C:\Hackaton\novo.csv");
            string[] koordinate = System.IO.File.ReadAllLines(@"C:\Hackaton\koordinate.csv");

            string[] count_opca = System.IO.File.ReadAllLines(@"C:\Hackaton\count_opca.csv");
            string[] count_predskolska = System.IO.File.ReadAllLines(@"C:\Hackaton\count_predskolska.csv");
            string[] count_zene = System.IO.File.ReadAllLines(@"C:\Hackaton\count_zene.csv");
            string[] count_zubari = System.IO.File.ReadAllLines(@"C:\Hackaton\count_zubari.csv");

            GeneralPracticeRepository generalPracticeRepository = new GeneralPracticeRepository();
            PreschoolChildrenPracticeRepository preschoolChildrenPracticeRepository = new PreschoolChildrenPracticeRepository();
            WomanHealthPracticeRepository womanHealthPracticeRepository = new WomanHealthPracticeRepository();
            DentalPracticeRepository dentalPracticeRepository = new DentalPracticeRepository();
            UnsignedPracticeRepositoy unsignedPracticeRepositoy = new UnsignedPracticeRepositoy();

            Console.WriteLine("Adding opca...");

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

                SetLocationProperties(practice, novo, koordinate);
                SetCountProperties(practice, count_opca, 1275, 1700, 2125);

                generalPracticeRepository.Add(practice);
            }

            Console.WriteLine("Adding predskolska...");

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

                SetLocationProperties(practice, novo, koordinate);
                SetCountProperties(practice, count_predskolska, 715, 950, 1190);

                preschoolChildrenPracticeRepository.Add(practice);
            }

            Console.WriteLine("Adding zene...");

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

                SetLocationProperties(practice, novo, koordinate);
                SetCountProperties(practice, count_zene, 4500, 6000, 9000);

                womanHealthPracticeRepository.Add(practice);
            }

            Console.WriteLine("Adding zubari...");

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

                SetLocationProperties(practice, novo, koordinate);
                SetCountProperties(practice, count_zubari, 1425, 1900, 2375);

                dentalPracticeRepository.Add(practice);
            }

            Console.WriteLine("Adding nepotpisnici...");

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

                SetLocationProperties(practice, novo, koordinate);

                unsignedPracticeRepositoy.Add(practice);
            }

            Console.WriteLine("Done.");

        }

        private static void SetCountProperties(PracticeBase practice, string[] counts, int minCount, int avgCount, int maxCount)
        {
            foreach (string line in counts)
            {
                var values = line.Split(';');
                string code = values[1].Trim();

                if (code == practice.PracticeCode)
                {
                    int count = Int32.Parse(values[5].Trim());
                    practice.NumberOfPatients = count;
                    practice.MinimumNumberOfPatients = minCount;
                    practice.AverageNumberOfPatients = avgCount;
                    practice.MaximumNumberOfPatients = maxCount;
                }
            }
        }

        static void SetLocationProperties(PracticeBase practice, string[] novo, string[] koordinate)
        {
            foreach (string line in novo)
            {
                var values = line.Split(';');
                string code = values[1].Trim();

                if (code == practice.PracticeCode)
                {
                    practice.PracticeName = values[2].Trim();
                    practice.BusinessArea = values[3].Trim();
                    practice.PracticeTypeString = values[4].Trim();
                    practice.POBox = values[8].Trim();
                    practice.Email = values[10].Trim();
                    practice.OfficePhone = values[11].Trim();
                    practice.ContactPhone = values[12].Trim();
                    practice.WorkingHours = values[13].Trim();

                    string geoid = values[14].Trim();

                    foreach (string line2 in koordinate)
                    {
                        var values2 = line2.Split(';');
                        string geoid2 = values2[0].Trim();

                        if (geoid == geoid2)
                        {
                            practice.County = values2[12].Trim();
                            practice.Country = values2[13].Trim();
                            practice.CoordinateX = values2[14].Trim();
                            practice.CoordinateY = values2[15].Trim();
                        }
                    }
                }
            }
        }
    }
}
