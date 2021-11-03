using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CarRentalProject.Model
{
    public class CRContext:DbContext
    {
        public CRContext(DbContextOptions<CRContext> options):base(options)
        {
            
        }
        public DbSet<tblBrands>TblBrands { get; set; }
        public DbSet<tblCars>TblCars  { get; set; }
        public DbSet<tblRents> TblRents { get; set; }
        public DbSet<tblUsers> TblUsers { get; set; }
        public DbSet<tblColors> tblColors { get; set; }
        public DbSet<tblGearboxTypes> tblGearboxTypes { get; set; } 


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblBrands>().ToTable("tblBrands");
            modelBuilder.Entity<tblCars>().ToTable("tblCars");
            modelBuilder.Entity<tblRents>().ToTable("tblRents");
            modelBuilder.Entity<tblUsers>().ToTable("tblUsers");
        }

    }
}
