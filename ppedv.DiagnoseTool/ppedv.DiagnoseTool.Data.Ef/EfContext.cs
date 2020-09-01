using ppedv.DiagnoseTool.Model;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Cryptography.X509Certificates;

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

            modelBuilder.Entity<Arzt>().ToTable("👨‍⚕️");
            modelBuilder.Entity<Diagnose>().ToTable("Diagnosen");
            modelBuilder.Entity<Patient>().ToTable("Patienten");

            modelBuilder.Entity<Arzt>().Property(x => x.FacharztRichtung)
                                       .HasMaxLength(28)
                                       .HasColumnName("🥨");
        }

    }
}
