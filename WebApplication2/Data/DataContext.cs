﻿using Server.Models;
using WebApplication2;

namespace Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        
        public DbSet<Athlete> Athletes { get; set; }

        public DbSet<Club> Clubs { get; set; }

        public DbSet<Sport> Sports { get; set; }

        public DbSet<Trener> Trener { get; set; }

        public DbSet<SportPlace> SportPlaces { get; set; }
    }
}