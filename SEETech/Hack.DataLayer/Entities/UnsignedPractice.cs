using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hack.DataLayer.Entities
{
    public sealed class UnsignedPractice : PracticeBase
    {
        public UnsignedPractice()
        {
            PracticeType = PracticeTypeEnum.Unsigned;
        }
    }
}
