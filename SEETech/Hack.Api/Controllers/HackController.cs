using System;
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
    }
}