//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Luckyfive.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Participations
    {
        public int Id { get; set; }
        public int AdvId { get; set; }
        public int Tokens { get; set; }
        public Nullable<int> TempUserId { get; set; }
        public int UserId { get; set; }
    
        public virtual Advertisments Advertisments { get; set; }
        public virtual TemporaryParticipants TemporaryParticipants { get; set; }
        public virtual Users Users { get; set; }
    }
}
