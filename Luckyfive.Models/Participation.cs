namespace Luckyfive.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Participation
    {
        public int Id { get; set; }

        public int AdvId { get; set; }

        public int Tokens { get; set; }

        public int? TempUserId { get; set; }

        [Required]
        [StringLength(128)]
        public string UserId { get; set; }

        public virtual Advertisment Advertisment { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }

        public virtual TemporaryParticipant TemporaryParticipant { get; set; }
    }
}
