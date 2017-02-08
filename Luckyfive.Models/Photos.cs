namespace Luckyfive.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Photos
    {
        public int Id { get; set; }

        public int AdvId { get; set; }

        [Required]
        [StringLength(256)]
        public string Url { get; set; }

        public virtual Advertisments Advertisments { get; set; }
    }
}
