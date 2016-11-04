using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PBEventWeb.Models
{
    public class MyDBContext : DbContext
    {
        public MyDBContext() : base("CS") { }

        public DbSet<Event> Events { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<PhotoEvent> PhotoEvents { get; set; }
        public DbSet<UserGame> UserGames { get; set; }

        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {/**
            modelBuilder.Entity<PhotoEvent>()
                .HasKey(c => new { c.PhotoID, c.EventID });

            modelBuilder.Entity<Event>()
                .HasMany(c => c.Photos)
                .WithRequired()
                .HasForeignKey(c => c.PhotoID);
            modelBuilder.Entity<Photo>()
                .HasMany(c => c.Events)
                .WithRequired()
                .HasForeignKey(c => c.EventID);

            modelBuilder.Entity<UserGame>()
                .HasKey(c => new { c.UserID, c.GameID });

            modelBuilder.Entity<User>()
                .HasMany(c => c.Games)
                .WithRequired()
                .HasForeignKey(c => c.GameID);
            modelBuilder.Entity<Game>()
                .HasMany(c => c.Users)
                .WithRequired()
                .HasForeignKey(c => c.UserID);
        **/

            modelBuilder.Entity<Event>()
                .HasOptional(s => s.Game) // Mark Address property optional in Student entity
                .WithRequired(ad => ad.Event); // mark Student property as required in StudentAddress entity. Cannot save StudentAddress without Student


        }
    }
}