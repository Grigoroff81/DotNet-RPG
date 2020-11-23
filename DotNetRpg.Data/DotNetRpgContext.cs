using DotNet_RPG.Data.Seeder;
using DotNetRpg.Data;
using DotNetRpg.Data.Configuration;
using DotNetRpg.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet_RPG.Data
{
    public class DotNetRpgContext : DbContext
    {
        public DotNetRpgContext(DbContextOptions<DotNetRpgContext> options) : base(options)
        {

        }
        public DbSet<Character> Characters { get; set; }
        public DbSet<RpgClass> Classes { get; set; }
        public DbSet<User> Users { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder
        //        .UseLoggerFactory(ConsoleLogger.Factory);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CharacterConfig());
            modelBuilder.ApplyConfiguration(new RpgClassConfig());
            modelBuilder.Seeder();
            base.OnModelCreating(modelBuilder);
        }
    }
}
