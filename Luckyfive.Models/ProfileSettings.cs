namespace Luckyfive.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ProfileSettings
    {
        public string Id { get; set; }

        public int? CountryId { get; set; }

        public int? RegionId { get; set; }

        public int? CityId { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(256)]
        public string ContactName { get; set; }

        public virtual AspNetUsers AspNetUsers { get; set; }
    }
}
