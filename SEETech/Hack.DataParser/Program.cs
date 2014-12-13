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
            CityRepository repository = new CityRepository();
            repository.Add(new City("Zadar"));
        }
    }
}
