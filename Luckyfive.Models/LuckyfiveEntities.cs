namespace Luckyfive.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class LuckyfiveEntities : DbContext
    {
        public LuckyfiveEntities()
            : base("name=LuckyfiveEntities")
        {
        }

        public virtual DbSet<Advertisment> Advertisments { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Participation> Participations { get; set; }
        public virtual DbSet<Photo> Photos { get; set; }
        public virtual DbSet<ProfileSetting> ProfileSettings { get; set; }
        public virtual DbSet<TemporaryParticipant> TemporaryParticipants { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Advertisment>()
                .HasMany(e => e.Participations)
                .WithRequired(e => e.Advertisment)
                .HasForeignKey(e => e.AdvId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Advertisment>()
                .HasMany(e => e.Photos)
                .WithRequired(e => e.Advertisment)
                .HasForeignKey(e => e.AdvId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.Advertisments)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.OwnerId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.Participations)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AspNetUser>()
                .HasOptional(e => e.ProfileSetting)
                .WithRequired(e => e.AspNetUser);

            modelBuilder.Entity<TemporaryParticipant>()
                .HasMany(e => e.Participations)
                .WithOptional(e => e.TemporaryParticipant)
                .HasForeignKey(e => e.TempUserId);
        }

        public virtual void Commit()
        {
            base.SaveChanges();
        }
    }
}
