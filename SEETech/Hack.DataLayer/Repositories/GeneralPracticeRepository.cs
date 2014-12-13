using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.DataLayer.Repositories;
using Hack.DataLayer.Entities;

namespace Hack.DataLayer.Repositories
{
    public class GeneralPracticeRepository : Repository<GeneralPractice>
    {
        public GeneralPracticeRepository()
            : base("mongodb://admin:admin@ds027758.mongolab.com:27758/base")
        {
        }
    }


}
