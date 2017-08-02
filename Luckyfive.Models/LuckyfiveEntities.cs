using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Data.Entity;

namespace Luckyfive.Models
{
    public partial class LuckyfiveEntities : DbContext
    {
        public LuckyfiveEntities()
            : base("name=LuckyfiveEntities")
        {
            Database.SetInitializer<LuckyfiveEntities>(new CreateDatabaseIfNotExists<LuckyfiveEntities>());
        }

        public virtual DbSet<Advertisment> Advertisments { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Participation> Participations { get; set; }
        public virtual DbSet<Photo> Photos { get; set; }
        public virtual DbSet<ProfileSetting> ProfileSettings { get; set; }
        public virtual DbSet<TemporaryParticipant> TemporaryParticipants { get; set; }
        public virtual DbSet<TopActualAdvertisment> TopActualAdvertisments { get; set; }
        public virtual DbSet<AdvertismentView> AdvertismentViews { get; set; }

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

            //modelBuilder.Configurations.Add(new TopActualAdvertismentConfiguration());
            modelBuilder.Entity<TopActualAdvertisment>();
            modelBuilder.Entity<AdvertismentView>();
        }

        public virtual void Commit()
        {
            try
            {
                base.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                Debug.WriteLine(e);
            }
        }
    }
}
