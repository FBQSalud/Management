using FBQ.Salud_Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FBQ.Salud_AccessData.Commands
{
    public class FBQSaludDbContext: DbContext 
    {
        public FBQSaludDbContext() { }

        public FBQSaludDbContext(DbContextOptions<FBQSaludDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=DbManagement;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        public virtual DbSet<Documentos> Documentos { get; set; }
        public virtual DbSet<Insumos> Insumos { get; set; }
    }
}
