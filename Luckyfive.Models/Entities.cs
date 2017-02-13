namespace Luckyfive.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }

        public virtual DbSet<Advertisments> Advertisments { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Participations> Participations { get; set; }
        public virtual DbSet<Photos> Photos { get; set; }
        public virtual DbSet<ProfileSettings> ProfileSettings { get; set; }
        public virtual DbSet<TemporaryParticipants> TemporaryParticipants { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Advertisments>()
                .HasMany(e => e.Participations)
                .WithRequired(e => e.Advertisments)
                .HasForeignKey(e => e.AdvId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Advertisments>()
                .HasMany(e => e.Photos);
                

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.Advertisments)
                .WithRequired(e => e.Owner)
                .HasForeignKey(e => e.OwnerId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.Participations)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AspNetUsers>()
                .HasOptional(e => e.ProfileSettings)
                .WithRequired(e => e.AspNetUsers);

            modelBuilder.Entity<TemporaryParticipants>()
                .HasMany(e => e.Participations)
                .WithOptional(e => e.TemporaryParticipants)
                .HasForeignKey(e => e.TempUserId);
        }
    }
}
