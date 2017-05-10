using System;
using System.Collections.Generic;

namespace Luckyfive.DTO
{
    public class AdvertismentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Status { get; set; }
        public int Tokens { get; set; }
        public string OwnerId { get; set; }
        public bool Lucky { get; set; }
    }
}
