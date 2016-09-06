namespace GameStore.Migrations
{
    using GameStore.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GameStore.Models.GameDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GameStore.Models.GameDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Games.AddOrUpdate(i => i.Title,

                new Game
                {
                    Title = "Little Big Planet 3",
                    ReleaseDate = DateTime.Parse("2014-11-18"),
                    Rating = "Everyone",
                    Platform = "PS3",
                    Price = 9.99M
                },

                new Game
                {
                    Title = "Little Big Planet Karting",
                    ReleaseDate = DateTime.Parse("2012-11-06"),
                    Rating = "Everyone",
                    Platform = "PS3",
                    Price = 14.95M
                },
                
                new Game
                {
                    Title = "The Last of Us",
                    ReleaseDate = DateTime.Parse("2013-06-14"),
                    Rating = "Mature",
                    Platform = "PS3",
                    Price = 9.99M
                },

                new Game
                {
                    Title = "Resident Evil: Revelations",
                    ReleaseDate = DateTime.Parse("2013-05-21"),
                    Rating = "Mature",
                    Platform = "PS3",
                    Price = 23.70M
                },

                new Game
                {
                    Title = "Resident Evil: Revelations 2",
                    ReleaseDate = DateTime.Parse("2015-04-17"),
                    Rating = "Mature",
                    Platform = "PS3",
                    Price = 18.39M
                },

                new Game
                {
                    Title = "Crash Bandicoot: Twinsanity",
                    ReleaseDate = DateTime.Parse("2006-06-15"),
                    Rating = "Everyone",
                    Platform = "PS2",
                    Price = 47.91M
                },

                new Game
                {
                    Title = "God of War",
                    ReleaseDate = DateTime.Parse("2006-09-08"),
                    Rating = "Mature",
                    Platform = "PS2",
                    Price = 25.52M
                },

                new Game
                {
                    Title = "Grand Theft Auto IV",
                    ReleaseDate = DateTime.Parse("2008-04-29"),
                    Rating = "Mature",
                    Platform = "PS3",
                    Price = 9.93M
                },

                new Game
                {
                    Title = "Grand Theft Auto: San Andreas",
                    ReleaseDate = DateTime.Parse("2005-06-07"),
                    Rating = "Mature",
                    Platform = "PC",
                    Price = 14.99M
                },

                new Game
                {
                    Title = "Battle Realms",
                    ReleaseDate = DateTime.Parse("2001-11-01"),
                    Rating = "Teen",
                    Platform = "PC",
                    Price = 34.95M
                },

                new Game
                {
                    Title = "Max Payne",
                    ReleaseDate = DateTime.Parse("2001-07-26"),
                    Rating = "Mature",
                    Platform = "PC",
                    Price = 8.79M
                },

                new Game
                {
                    Title = "Max Payne 3",
                    ReleaseDate = DateTime.Parse("2012-09-11"),
                    Rating = "Mature",
                    Platform = "PS3",
                    Price = 19.99M
                }
            );
        }
    }
}
