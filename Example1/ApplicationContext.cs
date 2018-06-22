using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Example1
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>()
                .HasOne(x => x.Team)
                .WithMany(x => x.Players)
                .HasForeignKey(x => x.TeamName)
                .HasPrincipalKey(x => x.Name);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=relationsdb;Trusted_Connection=True");
        }
    }




    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Player> Players { get; set; }    
    }

    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TeamName { get; set; }
        public Team Team { get; set; }
    }
}
