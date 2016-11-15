namespace PBEventWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initmysql : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activity",
                c => new
                    {
                        ActivityID = c.Int(nullable: false, identity: true),
                        Tittle = c.String(unicode: false),
                        Text = c.String(unicode: false),
                        StartHour = c.DateTime(nullable: false, precision: 0),
                        EndHour = c.DateTime(nullable: false, precision: 0),
                        PlaceID = c.Int(nullable: false),
                        EventID = c.Int(nullable: false),
                        Gameable = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ActivityID)
                .ForeignKey("dbo.Event", t => t.EventID, cascadeDelete: true)
                .ForeignKey("dbo.Place", t => t.PlaceID, cascadeDelete: true)
                .Index(t => t.EventID)
                .Index(t => t.PlaceID);
            
            CreateTable(
                "dbo.Event",
                c => new
                    {
                        EventID = c.Int(nullable: false, identity: true),
                        Tittle = c.String(unicode: false),
                        Text = c.String(unicode: false),
                        Active = c.Boolean(nullable: false),
                        Viewable = c.Boolean(nullable: false),
                        GameID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EventID);
            
            CreateTable(
                "dbo.Game",
                c => new
                    {
                        GameID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GameID)
                .ForeignKey("dbo.Event", t => t.GameID)
                .Index(t => t.GameID);
            
            CreateTable(
                "dbo.UserGame",
                c => new
                    {
                        UserGameID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        GameID = c.Int(nullable: false),
                        Points = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserGameID)
                .ForeignKey("dbo.Game", t => t.GameID, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: true)
                .Index(t => t.GameID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Login = c.String(unicode: false),
                        Password = c.String(unicode: false),
                        Email = c.String(unicode: false),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.PhotoEvent",
                c => new
                    {
                        PhotoEventID = c.Int(nullable: false, identity: true),
                        PhotoID = c.Int(nullable: false),
                        EventID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PhotoEventID)
                .ForeignKey("dbo.Event", t => t.EventID, cascadeDelete: true)
                .ForeignKey("dbo.Photo", t => t.PhotoID, cascadeDelete: true)
                .Index(t => t.EventID)
                .Index(t => t.PhotoID);
            
            CreateTable(
                "dbo.Photo",
                c => new
                    {
                        PhotoID = c.Int(nullable: false, identity: true),
                        Source = c.String(unicode: false),
                        Text = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.PhotoID);
            
            CreateTable(
                "dbo.Place",
                c => new
                    {
                        PlaceID = c.Int(nullable: false, identity: true),
                        Latitude = c.Single(nullable: false),
                        Longitude = c.Single(nullable: false),
                        Name = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.PlaceID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Activity", "PlaceID", "dbo.Place");
            DropForeignKey("dbo.PhotoEvent", "PhotoID", "dbo.Photo");
            DropForeignKey("dbo.PhotoEvent", "EventID", "dbo.Event");
            DropForeignKey("dbo.Game", "GameID", "dbo.Event");
            DropForeignKey("dbo.UserGame", "UserID", "dbo.User");
            DropForeignKey("dbo.UserGame", "GameID", "dbo.Game");
            DropForeignKey("dbo.Activity", "EventID", "dbo.Event");
            DropIndex("dbo.Activity", new[] { "PlaceID" });
            DropIndex("dbo.PhotoEvent", new[] { "PhotoID" });
            DropIndex("dbo.PhotoEvent", new[] { "EventID" });
            DropIndex("dbo.Game", new[] { "GameID" });
            DropIndex("dbo.UserGame", new[] { "UserID" });
            DropIndex("dbo.UserGame", new[] { "GameID" });
            DropIndex("dbo.Activity", new[] { "EventID" });
            DropTable("dbo.Place");
            DropTable("dbo.Photo");
            DropTable("dbo.PhotoEvent");
            DropTable("dbo.User");
            DropTable("dbo.UserGame");
            DropTable("dbo.Game");
            DropTable("dbo.Event");
            DropTable("dbo.Activity");
        }
    }
}
