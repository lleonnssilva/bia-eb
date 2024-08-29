using BIA.Models;
using Microsoft.EntityFrameworkCore;
using System.Xml;

namespace BIA.Data
{
    public class MeuDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public MeuDbContext(DbContextOptions<MeuDbContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(_configuration.GetConnectionString("DefaultConnection"));
            }
        }
        public DbSet<Tarefa> Tarefas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Tarefa>(entity =>
            {
                entity.ToTable("Tarefas");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Titulo);
                entity.Property(e => e.Importante);
                entity.Property(e => e.Dia_atividade);
                entity.Property(e => e.createdAt);
                entity.Property(e => e.updatedAt);
            });
        }
    }
    

}


