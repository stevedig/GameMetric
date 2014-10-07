namespace GameMetrics.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using GameMetrics.Models;
    using System.Collections.Generic;
    internal sealed class Configuration : DbMigrationsConfiguration<GameMetrics.dalGameMetricContext.GameMetricContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GameMetrics.dalGameMetricContext.GameMetricContext context)
        {
            //  This method will be called after migrating to the latest version.
            var games = new List<Game>
            {
                new Game { Title = "Guaranteed"},
                new Game { Title = "Qualifiers"},
                new Game { Title = "Head to Head"},
                new Game { Title = "50-50"},
                new Game { Title = "Leagues"},
                new Game { Title = "Multipliers"},
                new Game { Title = "Steps"},
                new Game { Title = "Beginner"},
            };
            games.ForEach(s => context.Games.AddOrUpdate(p => p.Title, s));
            context.SaveChanges();
        }
    }
}
