using Microsoft.EntityFrameworkCore;
using Model.Model;

namespace Hospital.Services
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Cure> Drugs { get; set; }
        public DbSet<CureRecord> CureRecords { get; set; }
        public DbSet<Disease> Diseases { get; set; }
        public DbSet<PatientDisease> PatientDiseases { get; set; }
        public ApplicationContext()
        {
            //Database. EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=hospitaldb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>()
                    .HasMany(p => p.Diseases)
                    .WithOne(d => d.Patient)
                    .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Patient>()
                    .HasMany(p => p.Treatment)
                    .WithOne(t => t.Patient)
                    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
