using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using APIProject.Models;

namespace APIProject.Models
{
    public class APIProjectDBContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public APIProjectDBContext(DbContextOptions<APIProjectDBContext> options, IConfiguration configuration) : base(options)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = Configuration.GetConnectionString("APIProjectService");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //TODO: on add any entity add here the same
            modelBuilder.Entity<Character>().Property(e => e.CharacterId).ValueGeneratedNever();
            modelBuilder.Entity<Weapon>().Property(e => e.WeaponId).ValueGeneratedNever();
        }

        public DbSet<Character> Characters { get; set; } = null!;
        public DbSet<Weapon> Weapons { get; set; } = null!;
    }
}