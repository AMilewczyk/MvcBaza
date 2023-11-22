using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcBaza.Models;

namespace MvcBaza.Data
{
    public class MvcBazaContext : DbContext
    {
        public MvcBazaContext (DbContextOptions<MvcBazaContext> options)
            : base(options)
        {
        }

        public DbSet<MvcBaza.Models.Cat> Cat { get; set; } = default!;
    }
}
