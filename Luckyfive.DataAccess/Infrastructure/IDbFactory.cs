using Luckyfive.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luckyfive.DataAccess.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        LuckyfiveEntities Init();
    }
}
