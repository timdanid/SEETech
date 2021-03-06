﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Hack.DataLayer;
using Newtonsoft.Json;

namespace Hack.Api.Controllers
{
    [EnableCors("*", "*", "*")]
    public class HackController : ApiController
    {
        //// GET api/<controller>
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<controller>/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<controller>
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/<controller>/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/<controller>/5
        //public void Delete(int id)
        //{
        //}


        [EnableCors("*", "*", "*")]
        [Route("api/GetCitiesForCounty")]
        public object GetCitiesForCounty(string countyName)
        {
            using (HackEntities entities = new HackEntities())
            {
                County county = entities.Counties.FirstOrDefault(x => x.Name.ToLower().Contains(countyName.ToLower()));
                if (county != null)
                {
                    return county.Cities.Select(t => new { id = t.ID, name = t.Name }).ToList();
                }

                return null;
            }
        }

        [EnableCors("*", "*", "*")]
        [Route("api/GetAllCounties")]
        public object GetAllCounties()
        {
            using (HackEntities entities = new HackEntities())
            {
                return entities.Counties.Select(t => new { id = t.ID, name = t.Name }).ToList();
            }
        }

        [EnableCors("*", "*", "*")]
        [Route("api/GetPracticesList")]
        public object GetPracticesList(string query, bool general, bool preschool, bool women, bool dental)
        {
            using (HackEntities entities = new HackEntities())
            {
                List<Practice> practice =
                    entities.Practices.Where(x => x.City.Name.ToLower().Contains(query.ToLower()) || x.Address.ToLower().Contains(query.ToLower())).ToList();

                List<int> types = new List<int>();

                if (general)
                {
                    types.Add(1);
                }
                if (preschool)
                {
                    types.Add(2);
                }
                if (women)
                {
                    types.Add(3);
                }
                if (dental)
                {
                    types.Add(4);
                }

                return practice.Where(x => types.Contains(x.PracticeTypeID)).Select(t => new { href = "/#/detail/" + t.ID + "/", name = t.PracticeName, location = t.Address, general= t.PracticeType.ID == 1 ? true : false, dental= t.PracticeType.ID == 4? true:false, women = t.PracticeType.ID == 3 ? true:false, preschool = t.PracticeType.ID == 2 ? true: false }).ToList();
            }
        }

        [EnableCors("*", "*", "*")]
        [Route("api/GetPracticesDetails")]
        public object GetPracticesDetails(int id)
        {
            using (HackEntities entities = new HackEntities())
            {
                Practice practice = entities.Practices.FirstOrDefault(x => x.ID == id);

                if (practice != null)
                {
                    object result = new
                    {
                        RUPS = practice.RUPS,
                        PracticeCode = practice.PracticeCode,
                        PracticeName = practice.PracticeName,
                        PracticeType = practice.PracticeType.Name,
                        DoctorStatus = practice.DoctorStatus.Name,
                        Address = practice.Address,
                        City = practice.City.Name,
                        BusinessArea = practice.BusinessArea,
                        PracticeTypeDescription = practice.PracticeTypeDescription,
                        Email = practice.Email,
                        OfficePhone = practice.OfficePhone,
                        ContactPhone = practice.ContactPhone,
                        WorkingHours = practice.WorkingHours,
                        CoordinateX = practice.CoordinateX,
                        CoordinateY = practice.CoordinateY,
                        NumberOfPatients = practice.NumberOfPatients,
                        ReferToSpecialistHealthCare = practice.ReferToSpecialistHealthCare,
                        PeerGroup = practice.PeerGroup,
                        PreventivePrograms = practice.PreventivePrograms,
                        GroupPracticeOnlyForDoctorsInConcession = practice.GroupPracticeOnlyForDoctorsInConcession,
                        CouncilOnlyForEmployees = practice.CouncilOnlyForEmployees,
                        Council = practice.Council,
                        EHealth = practice.EHealth,
                        SchedulingPatients = practice.SchedulingPatients,
                        SickLeaveRate = practice.SickLeaveRate,
                        MedicationPrescription = practice.MedicationPrescription,
                        ReferToPrimaryLaboratory = practice.ReferToPrimaryLaboratory,
                        CronicDiseasePanel = practice.CronicDiseasePanel,
                        SamplesForPrimaryLabAnalysis = practice.SamplesForPrimaryLabAnalysis,
                        TelephoneConsultation = practice.TelephoneConsultation,
                        PercentageOfFirstSystematicExaminationBefore2MonthsOfLife = practice.PercentageOfFirstSystematicExaminationBefore2MonthsOfLife,
                        FeedingPanelTracking = practice.FeedingPanelTracking,
                        TakingSamplesForPrimaryLabAnalysis = practice.TakingSamplesForPrimaryLabAnalysis,
                        EmergencyPhone = practice.EmergencyPhone,
                        OlderWomenWithTVSExamination = practice.OlderWomenWithTVSExamination,
                        YoungerWomenContraceptionCouncil = practice.YoungerWomenContraceptionCouncil,
                        TakingAndDeliveryOfSamplesForMicrobiologyDiagnostics = practice.TakingAndDeliveryOfSamplesForMicrobiologyDiagnostics,
                        PortionOfPreventiveProcedures = practice.PortionOfPreventiveProcedures,
                        PersonsWithDentalStatus = practice.PersonsWithDentalStatus,
                        SpecialNeedsDentalCare = practice.SpecialNeedsDentalCare
                    };

                    return result;
                }

                return null;
            }
        }

        [EnableCors("*", "*", "*")]
        [Route("api/GetMarkers")]
        public object GetMarkers()
        {
            using (HackEntities entities = new HackEntities())
            {
                var a =  entities.Practices.Select(t => new { id = t.ID, type= t.PracticeType.ID, practiceName = t.PracticeName, x_coordinate = t.CoordinateX, y_coordinate = t.CoordinateY, location = t.Address + ", " + t.City.Name, numberOfPatients = t.NumberOfPatients }).ToList();
                return a.Select(t => new { t.id, t.practiceName, t.x_coordinate, t.y_coordinate, t.location, t.numberOfPatients, icon = GetIcon(t.type) });
            }
        }

        private string GetIcon(int practiseId)
        {
            switch (practiseId)
            { 
                case 1: return "/images/market-icons/marker-64-base1.png";
                case 2: return "/images/market-icons/marker-64-base2.png";
                case 3: return "/images/market-icons/marker-64-base3.png";
                case 4: return "/images/market-icons/marker-64-base4.png";
                default: return null;
            }
        }
    }
}