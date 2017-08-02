namespace Luckyfive.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SampleMigrations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Advertisments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 500),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        Tokens = c.Int(nullable: false),
                        OwnerId = c.String(nullable: false, maxLength: 128),
                        WinnerId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.OwnerId)
                .Index(t => t.OwnerId);
            
            CreateTable(
                "dbo.Participations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AdvId = c.Int(nullable: false),
                        Tokens = c.Int(nullable: false),
                        TempUserId = c.Int(),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TemporaryParticipants", t => t.TempUserId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.Advertisments", t => t.AdvId)
                .Index(t => t.AdvId)
                .Index(t => t.TempUserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.TemporaryParticipants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProfileSettings",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FullName = c.String(),
                        Addr1 = c.String(),
                        Addr2 = c.String(),
                        City = c.String(),
                        Region = c.String(),
                        ZipCode = c.String(),
                        Country = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        AdvId = c.Int(nullable: false),
                        Url = c.String(nullable: false, maxLength: 256),
                        First = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Advertisments", t => t.AdvId)
                .Index(t => t.AdvId);
            
            CreateTable(
                "dbo.AdvertismentViews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OwnerId = c.String(),
                        Name = c.String(),
                        Description = c.String(),
                        ParticipationsCount = c.Int(nullable: false),
                        PhotoUrl = c.String(),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TopActualAdvertisments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OwnerId = c.String(),
                        Name = c.String(),
                        Description = c.String(),
                        ParticipationsCount = c.Int(nullable: false),
                        PhotoUrl = c.String(),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Photos", "AdvId", "dbo.Advertisments");
            DropForeignKey("dbo.Participations", "AdvId", "dbo.Advertisments");
            DropForeignKey("dbo.ProfileSettings", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Participations", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Participations", "TempUserId", "dbo.TemporaryParticipants");
            DropForeignKey("dbo.Advertisments", "OwnerId", "dbo.AspNetUsers");
            DropIndex("dbo.Photos", new[] { "AdvId" });
            DropIndex("dbo.ProfileSettings", new[] { "Id" });
            DropIndex("dbo.Participations", new[] { "UserId" });
            DropIndex("dbo.Participations", new[] { "TempUserId" });
            DropIndex("dbo.Participations", new[] { "AdvId" });
            DropIndex("dbo.Advertisments", new[] { "OwnerId" });
            DropTable("dbo.TopActualAdvertisments");
            DropTable("dbo.AdvertismentViews");
            DropTable("dbo.Photos");
            DropTable("dbo.ProfileSettings");
            DropTable("dbo.TemporaryParticipants");
            DropTable("dbo.Participations");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Advertisments");
        }
    }
}
