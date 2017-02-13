namespace Luckyfive.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Photo
    {
        public Guid Id { get; set; }

        public int AdvId { get; set; }

        [Required]
        [StringLength(256)]
        public string Url { get; set; }

        public virtual Advertisment Advertisment { get; set; }
    }
}
