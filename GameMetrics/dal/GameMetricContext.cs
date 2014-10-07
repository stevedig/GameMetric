using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GameMetrics.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace GameMetrics.dalGameMetricContext
{
    public class GameMetricContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Engagement> Engagements { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Purchase> Purchases { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}