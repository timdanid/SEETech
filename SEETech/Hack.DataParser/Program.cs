using System;
using System.Collections.Generic;
using System.Linq;
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
            //CityRepository repository = new CityRepository();
            //repository.Delete(x => x.Name == "Zadar");

            string[] lines = System.IO.File.ReadAllLines(@"C:\Hackaton\opca.csv");

            //GeneralPracticeRepository repository = new GeneralPracticeRepository();

            foreach (string line in lines)
            {
                var values = line.Split(';');
                GeneralPractice practice = new GeneralPractice();
                practice.RUPS = values[0].Trim();
                practice.PracticeCode = values[1].Trim();
                practice.PracticeName = values[2].Trim();
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
                //repository.Add(practice);
            }
        }
    }
}
