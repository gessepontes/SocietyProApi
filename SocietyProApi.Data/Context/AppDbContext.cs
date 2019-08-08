using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SocietyProApi.Data.Mappings.EntityFramework;
using SocietyProApi.Domain.Entities;
using System.IO;

namespace SocietyProApi.Data.Context
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)   
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PessoaPerfilMap());
            modelBuilder.ApplyConfiguration(new PessoaMap());
            modelBuilder.ApplyConfiguration(new PlayerMap());
            modelBuilder.ApplyConfiguration(new TeamMap());
            modelBuilder.ApplyConfiguration(new FieldMap());
            modelBuilder.ApplyConfiguration(new FieldItemMap());
            modelBuilder.ApplyConfiguration(new HoraryExtraMap());
            modelBuilder.ApplyConfiguration(new HoraryMap());
            modelBuilder.ApplyConfiguration(new SchedulingMap());
            modelBuilder.ApplyConfiguration(new ChampionshipMap());
            modelBuilder.ApplyConfiguration(new InscriptionMap());
        }

        public DbSet<PessoaPerfil> PessoaPerfis { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Field> Fields { get; set; }
        public DbSet<FieldItem> FieldItens { get; set; }
        public DbSet<HoraryExtra> HoraryExtras { get; set; }
        public DbSet<Horary> Horarys { get; set; }
        public DbSet<Scheduling> Schedulings { get; set; }
        public DbSet<Championship> Championships { get; set; }
        public DbSet<Inscription> Inscriptions { get; set; }
    }
}