using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new TvShowContext(
            serviceProvider.GetRequiredService<DbContextOptions<TvShowContext>>()))
        {
            // Ensure database is created
            context.Database.EnsureCreated();

            // Look for any TV shows.
            if (context.TvShows.Any())
            {
                return;   // DB has been seeded
            }

            // Add new data
            var tvShows = new List<TvShow>
            {
                new TvShow { Name = "Hachiko", Favorite = true },
                new TvShow { Name = "Eragon", Favorite = false },
                new TvShow { Name = "Jobs", Favorite = true },
            };

            context.TvShows.AddRange(tvShows);
            context.SaveChanges();
        }
    }
}
