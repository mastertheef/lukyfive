﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luckyfive.Models
{
    public partial class LuckyfiveEntities : Entities
    {
        public virtual void Commit()
        {
            base.SaveChanges();
        }
    }
}
