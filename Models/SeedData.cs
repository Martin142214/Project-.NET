using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using WebApplication1.Models;

namespace MvcMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AppDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<AppDbContext>>()))
            {
                // Look for any movies.
                if (context.Players.Any())
                {
                    return;   // DB has been seeded
                }

                context.Players.AddRange(
                    new Player
                    {
                       
                    },

                    new Player
                    {
                        
                    },

                    new Player
                    {
                       
                    },

                    new Player
                    {
                        
                    }
                );
                context.SaveChanges();
            }
        }
    }
}