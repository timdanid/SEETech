using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.DataLayer.Repositories;
using Hack.DataLayer.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;
using Hack.DataLayer.Repositories;

namespace Hack.DataLayer.Repositories
{
    public class PracticeBaseRepository : Repository<PracticeBase>
    {

        public PracticeBaseRepository()
            : base(Connection.ConnectionString)
        {
        }

        public dynamic GetGeneralPractice()
        {
            return this.collection.FindAs<GeneralPractice>(Query.EQ("PracticeType", (int)PracticeTypeEnum.General));
        }

    }
}
