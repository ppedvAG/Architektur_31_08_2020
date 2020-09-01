using ppedv.DiagnoseTool.Model;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace ppedv.DiagnoseTool.Data.Ef
{
    public class EfContext : DbContext
    {
        public DbSet<Arzt> Ärzte { get; set; }
        public DbSet<Patient> Patienten { get; set; }
        public DbSet<Diagnose> Diagnosen { get; set; }

        public EfContext() : this("Server=(localdb)\\MSSQLLocalDB;Database=Diagnosetool_DEV;Trusted_Connection=true;")
        { }

        public EfContext(string conString) : base(conString)
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //System.Data.Entity.ModelConfiguration.Conventions.
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Properties<DateTime>().Configure(x => x.HasColumnType("datetime2"));

            modelBuilder.Entity<Arzt>().ToTable("👨‍⚕️");
            modelBuilder.Entity<Diagnose>().ToTable("Diagnosen");
            modelBuilder.Entity<Patient>().ToTable("Patienten");

            modelBuilder.Entity<Arzt>().Property(x => x.FacharztRichtung)
                                       .HasMaxLength(128)
                                       .HasColumnName("🥨");
        }

        public override int SaveChanges()
        {
            foreach (var item in this.ChangeTracker.Entries().Where(x => x.State == EntityState.Added))
            {
                ((Entity)item.Entity).Created = DateTime.Now;
                ((Entity)item.Entity).Modified = DateTime.Now;
            }

            foreach (var item in this.ChangeTracker.Entries().Where(x => x.State == EntityState.Modified))
            {
                ((Entity)item.Entity).Modified = DateTime.Now;
            }

            return base.SaveChanges();
        }

    }
}
