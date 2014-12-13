using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.DataLayer;

namespace Hack.DataLayer.Entities
{
    public sealed class City : Entity
    {
        public City(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public string POBox { get; set; }
    }
}
