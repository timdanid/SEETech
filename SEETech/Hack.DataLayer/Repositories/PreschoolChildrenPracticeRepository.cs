using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.DataLayer.Repositories;
using Hack.DataLayer.Entities;

namespace Hack.DataLayer.Repositories
{
    public class PreschoolChildrenPracticeRepository : Repository<PreschoolChildrenPractice>
    {
        public PreschoolChildrenPracticeRepository()
            : base(Connection.ConnectionString)
        {
        }
    }


}
