using ppedv.DiagnoseTool.Model;
using System.Data.Entity;

namespace ppedv.DiagnoseTool.Data.Ef
{
    public class EfContext : DbContext
    {
        public DbSet<Arzt> Ärzte { get; set; }
        public DbSet<Patient> Patienten { get; set; }
        public DbSet<Diagnose> Diagnosen { get; set; }

    }
}
