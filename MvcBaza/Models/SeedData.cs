using Microsoft.EntityFrameworkCore;
using MvcBaza.Data;

namespace MvcBaza.Models;

    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcBazaContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcBazaContext>>()))
            {
            // Look for any cats.
            if (context.Cat.Any())
                {
                    return;   // DB has been seeded
                }
                context.Cat.AddRange(
                    new Cat
                    {
                        Name = "When Harry Met Sally",
                        Years = 1,
                        Genre = "Romantic Comedy",
                        Behawior = "jjj"
                    },
                    new Cat
                    {
                        Name = "Ghostbusters ",
                        Years = 1,
                        Genre = "Comedy",
                        Behawior = "ffff"
                    },
                    new Cat
                    {
                        Name = "Ghostbusters 2",
                        Years = 1,
                        Genre = "Comedy",
                        Behawior = "ffff"
                    },
                    new Cat
                    {
                        Name = "Rio Bravo",
                        Years = 1,
                        Genre = "Western",
                        Behawior = "ddd"
                    }
                );
                context.SaveChanges();
            }
        }
    }


