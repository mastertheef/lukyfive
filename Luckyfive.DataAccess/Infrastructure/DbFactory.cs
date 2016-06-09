using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Luckyfive.Models;

namespace Luckyfive.DataAccess.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        LuckyfiveEntities dbContext;

        public LuckyfiveEntities Init()
        {
            return dbContext ?? (dbContext = new LuckyfiveEntities());
        }

        protected override void DisposeCore()
        {
            if (this.dbContext != null)
            {
                this.dbContext.Dispose();
            }
        }
    }
}
