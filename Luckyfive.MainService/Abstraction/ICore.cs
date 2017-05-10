using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luckyfive.MainService.Abstraction
{
    public interface ICore
    {
        void FindLuckyPeople();
        void FindAndProcessReady();
    }
}
