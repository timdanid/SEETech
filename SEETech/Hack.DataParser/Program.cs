using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hack.DataLayer;

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

            // countries, counties, cities
            using (HackEntities entities = new HackEntities())
            {
                Console.WriteLine("Adding countries, counties, cities...");

                foreach (var line in koordinate)
                {
                    var values = line.Split(';');

                    string pobox = values[10].Trim();
                    string cityName = values[11].Trim();
                    string countyName = values[12].Trim();
                    string countryName = values[13].Trim();

                    Country country = entities.Countries.FirstOrDefault(x => x.Name.ToLower() == countryName.ToLower());
                    if (country == null)
                    {
                        country = new Country();
                        country.Name = countryName;
                        entities.Countries.Add(country);
                    }

                    County county = entities.Counties.FirstOrDefault(x => x.Name.ToLower() == countyName.ToLower());
                    if (county == null)
                    {
                        county = new County();
                        county.Name = countyName;
                        county.Country = country;
                        entities.Counties.Add(county);
                    }

                    City city = entities.Cities.FirstOrDefault(x => x.Name.ToLower() == countyName.ToLower());
                    if (city == null)
                    {
                        city = new City();
                        city.Name = cityName;
                        city.County = county;
                        city.Country = country;
                        city.POBox = pobox;
                        entities.Cities.Add(city);
                    }
                }

                entities.SaveChanges();

                Console.WriteLine("Adding opca...");

                foreach (string line in opca)
                {
                    var values = line.Split(';');

                    Practice practice = new Practice();
                    practice.RUPS = values[0].Trim();
                    practice.PracticeCode = values[1].Trim();
                    //practice.PracticeName = values[2].Trim();
                    practice.DoctorStatus = GetDoctorStatus(entities, values[3].Trim().ToLower());
                    practice.Address = values[4].Trim();
                    practice.City = GetCity(entities, values[5].Trim());
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

                    SetLocationProperties(entities, practice, novo, koordinate);
                    SetCountProperties(practice, count_opca);

                    entities.Practices.Add(practice);
                }

                entities.SaveChanges();
                Console.WriteLine("Adding predskolska...");

                foreach (string line in predskolska)
                {
                    var values = line.Split(';');
                    Practice practice = new Practice();
                    practice.RUPS = values[0].Trim();
                    practice.PracticeCode = values[1].Trim();
                    //practice.PracticeName = values[2].Trim();
                    practice.DoctorStatus = GetDoctorStatus(entities, values[3].Trim().ToLower());
                    practice.Address = values[4].Trim();
                    practice.City = GetCity(entities, values[5].Trim());
                    practice.MedicationPrescription = values[6].Trim().ToLower() == "da";
                    practice.ReferToSpecialistHealthCare = values[7].Trim().ToLower() == "da";
                    practice.ReferToPrimaryLaboratory = values[8].Trim().ToLower() == "da";
                    practice.PercentageOfFirstSystematicExaminationBefore2MonthsOfLife = values[9].Trim().ToLower() ==
                                                                                         "da";
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

                    SetLocationProperties(entities, practice, novo, koordinate);
                    SetCountProperties(practice, count_predskolska);

                    entities.Practices.Add(practice);
                }

                entities.SaveChanges();
                Console.WriteLine("Adding zene...");

                foreach (string line in zene)
                {
                    var values = line.Split(';');
                    Practice practice = new Practice();
                    practice.RUPS = values[0].Trim();
                    practice.PracticeCode = values[1].Trim();
                    //practice.PracticeName = values[2].Trim();
                    practice.DoctorStatus = GetDoctorStatus(entities, values[3].Trim().ToLower());
                    practice.Address = values[4].Trim();
                    practice.City = GetCity(entities, values[5].Trim());
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

                    SetLocationProperties(entities, practice, novo, koordinate);
                    SetCountProperties(practice, count_zene);

                    entities.Practices.Add(practice);
                }

                entities.SaveChanges();
                Console.WriteLine("Adding zubari...");

                foreach (string line in zubari)
                {
                    var values = line.Split(';');
                    Practice practice = new Practice();
                    practice.RUPS = values[0].Trim();
                    practice.PracticeCode = values[1].Trim();
                    //practice.PracticeName = values[2].Trim();
                    practice.DoctorStatus = GetDoctorStatus(entities, values[3].Trim().ToLower());
                    practice.Address = values[4].Trim();
                    practice.City = GetCity(entities, values[5].Trim());
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

                    SetLocationProperties(entities, practice, novo, koordinate);
                    SetCountProperties(practice, count_zubari);

                    entities.Practices.Add(practice);
                }

                entities.SaveChanges();
                Console.WriteLine("Adding nepotpisnici...");

                foreach (string line in nepotpisnici)
                {
                    var values = line.Split(';');
                    Practice practice = new Practice();
                    practice.RUPS = values[0].Trim();
                    practice.PracticeCode = values[1].Trim();
                    //practice.PracticeName = values[2].Trim();
                    practice.DoctorStatus = GetDoctorStatus(entities, values[3].Trim().ToLower());
                    practice.Address = values[4].Trim();
                    practice.City = GetCity(entities, values[5].Trim());

                    SetLocationProperties(entities, practice, novo, koordinate);

                    entities.Practices.Add(practice);
                }

                entities.SaveChanges();
            }

            Console.WriteLine("Done.");

        }

        public static DoctorStatus GetDoctorStatus(HackEntities entities, string doctorStatus)
        {
            return entities.DoctorStatuses.First(x => x.Name.ToLower() == doctorStatus.ToLower());
        }

        public static City GetCity(HackEntities entities, string cityName)
        {
            return entities.Cities.First(x => x.Name.ToLower() == cityName.ToLower());
        }

        private static void SetCountProperties(Practice practice, string[] counts)
        {
            foreach (string line in counts)
            {
                var values = line.Split(';');
                string code = values[1].Trim();

                if (code == practice.PracticeCode)
                {
                    int count = Int32.Parse(values[5].Trim());
                    practice.NumberOfPatients = count;
                }
            }
        }

        static void SetLocationProperties(HackEntities entities, Practice practice, string[] novo, string[] koordinate)
        {
            foreach (string line in novo)
            {
                var values = line.Split(';');
                string code = values[1].Trim();

                if (code == practice.PracticeCode)
                {
                    practice.PracticeName = values[2].Trim();
                    practice.BusinessArea = values[3].Trim();
                    practice.PracticeTypeDescription = values[4].Trim();
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
                            practice.CoordinateX = values2[14].Trim();
                            practice.CoordinateY = values2[15].Trim();
                        }
                    }
                }
            }
        }
    }
}
