using DB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
     public class ApplicationContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }
        public DbSet<DoctorModel> Doctors { get; set; }
        public DbSet<SpecializationModel> Specializations { get; set; }
        public DbSet<SheduleModel> Shedules { get; set; }
        public DbSet<VisitModel> Visits { get; set; }

        public ApplicationContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserModel>().HasIndex(model => model.Login);
            modelBuilder.Entity<DoctorModel>().HasIndex(model => model.Name).IsUnique();
        }
    }
}
