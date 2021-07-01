using Microsoft.EntityFrameworkCore;
using PSV.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace PSV.Model
{
    public class PSVContext : DbContext
    {
        public static ProjectConfiguration Configuration;

        public PSVContext(DbContextOptions<PSVContext> context , ProjectConfiguration configuration) : base(context) 
        {
            if (configuration != null) 
            {
                PSVContext.Configuration = configuration;
            }
                
        }

        public PSVContext()
        {
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {

        }

        public DbSet<User> Users { get; set; }
        
        public DbSet<Examination> Examinations { get; set; }
        public DbSet<Feedback> Feedback { get; set; }
        public DbSet<BusinessHours> BusinessHours { get; set; }
        public DbSet<Instruction> Instructions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            if (optionsBuilder.IsConfigured)
            {
                return;
            }

            optionsBuilder.UseSqlServer(PSVContext.Configuration.DatabaseConfiguration.ConnectionString);
        }



    }
}
