using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luckyfive.Models
{
    public class TopActualAdvertisment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ParticipationsCount { get; set; }
        public string PhotoUrl { get; set; }
        public DateTime EndDate { get; set; }
    }
}
