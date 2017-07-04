using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Luckyfive.Models
{
    public partial class ProfileSetting
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Addr1 { get; set; }
        public string Addr2 { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }
    }
}
