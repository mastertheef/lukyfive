namespace Luckyfive.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Participations
    {
        public int Id { get; set; }

        public int AdvId { get; set; }

        public int Tokens { get; set; }

        public int? TempUserId { get; set; }

        [Required]
        [StringLength(128)]
        public string UserId { get; set; }

        public virtual Advertisments Advertisments { get; set; }

        public virtual AspNetUsers AspNetUsers { get; set; }

        public virtual TemporaryParticipants TemporaryParticipants { get; set; }
    }
}
