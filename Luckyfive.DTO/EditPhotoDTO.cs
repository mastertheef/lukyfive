using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luckyfive.DTO
{
    public class EditPhotoDTO
    {
        public Guid Id { get; set; }
        public bool ShouldDelete { get; set; }
        public string Name { get; set; }
    }
}
