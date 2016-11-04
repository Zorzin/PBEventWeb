namespace PBEventWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activities",
                c => new
                    {
                        ActivityID = c.Int(nullable: false, identity: true),
                        Tittle = c.String(),
                        Text = c.String(),
                        StartHour = c.DateTime(nullable: false),
                        EndHour = c.DateTime(nullable: false),
                        PlaceID = c.Int(nullable: false),
                        EventID = c.Int(nullable: false),
                        Gameable = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ActivityID)
                .ForeignKey("dbo.Events", t => t.EventID, cascadeDelete: true)
                .ForeignKey("dbo.Places", t => t.PlaceID, cascadeDelete: true)
                .Index(t => t.PlaceID)
                .Index(t => t.EventID);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventID = c.Int(nullable: false, identity: true),
                        Tittle = c.String(),
                        Text = c.String(),
                        Active = c.Boolean(nullable: false),
                        Viewable = c.Boolean(nullable: false),
                        GameID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EventID);
            
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        GameID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GameID)
                .ForeignKey("dbo.Events", t => t.GameID)
                .Index(t => t.GameID);
            
            CreateTable(
                "dbo.UserGames",
                c => new
                    {
                        UserGameID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        GameID = c.Int(nullable: false),
                        Points = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserGameID)
                .ForeignKey("dbo.Games", t => t.GameID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.GameID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.PhotoEvents",
                c => new
                    {
                        PhotoEventID = c.Int(nullable: false, identity: true),
                        PhotoID = c.Int(nullable: false),
                        EventID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PhotoEventID)
                .ForeignKey("dbo.Events", t => t.EventID, cascadeDelete: true)
                .ForeignKey("dbo.Photos", t => t.PhotoID, cascadeDelete: true)
                .Index(t => t.PhotoID)
                .Index(t => t.EventID);
            
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        PhotoID = c.Int(nullable: false, identity: true),
                        Source = c.String(),
                        Text = c.String(),
                    })
                .PrimaryKey(t => t.PhotoID);
            
            CreateTable(
                "dbo.Places",
                c => new
                    {
                        PlaceID = c.Int(nullable: false, identity: true),
                        Latitude = c.Single(nullable: false),
                        Longitude = c.Single(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.PlaceID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Activities", "PlaceID", "dbo.Places");
            DropForeignKey("dbo.PhotoEvents", "PhotoID", "dbo.Photos");
            DropForeignKey("dbo.PhotoEvents", "EventID", "dbo.Events");
            DropForeignKey("dbo.Games", "GameID", "dbo.Events");
            DropForeignKey("dbo.UserGames", "UserID", "dbo.Users");
            DropForeignKey("dbo.UserGames", "GameID", "dbo.Games");
            DropForeignKey("dbo.Activities", "EventID", "dbo.Events");
            DropIndex("dbo.PhotoEvents", new[] { "EventID" });
            DropIndex("dbo.PhotoEvents", new[] { "PhotoID" });
            DropIndex("dbo.UserGames", new[] { "GameID" });
            DropIndex("dbo.UserGames", new[] { "UserID" });
            DropIndex("dbo.Games", new[] { "GameID" });
            DropIndex("dbo.Activities", new[] { "EventID" });
            DropIndex("dbo.Activities", new[] { "PlaceID" });
            DropTable("dbo.Places");
            DropTable("dbo.Photos");
            DropTable("dbo.PhotoEvents");
            DropTable("dbo.Users");
            DropTable("dbo.UserGames");
            DropTable("dbo.Games");
            DropTable("dbo.Events");
            DropTable("dbo.Activities");
        }
    }
}
