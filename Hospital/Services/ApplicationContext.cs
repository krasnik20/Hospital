using Microsoft.EntityFrameworkCore;
using Model.Model;

namespace Hospital.Services
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Drug> Drugs { get; set; }
        public DbSet<DrugRecord> DrugRecords { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
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
                    .HasMany(p => p.Diagnosis)
                    .WithOne(d => d.Patient);
        }
    }
}
