using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using RssAiParser.Models;

namespace RssAiParser.Context
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        public DbSet<OriginalNew> OriginalNews { get; set; }
        public DbSet<ParsedNew> ParsedNews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Aquí puedes configurar tus modelos si es necesario
            //modelBuilder.Entity<OriginalNew>().ToTable("OriginalNews");
            //modelBuilder.Entity<ParsedNew>().ToTable("ParsedNews");
        }
    }

    public class YourDbContextFactory : IDesignTimeDbContextFactory<MyDbContext>
    {
        public MyDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MyDbContext>();
            //EN LA PROXIMA MIGRACION PROBAR A PILLAR LA CADENA DEL APPSETTINGS
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DebugDataBase;Integrated Security=True");

            return new MyDbContext(optionsBuilder.Options);
        }
    }
}
