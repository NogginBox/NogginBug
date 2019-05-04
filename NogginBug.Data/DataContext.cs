using Microsoft.EntityFrameworkCore;
using NogginBug.Data.Model;

namespace NogginBug.Data
{
    public class DataContext : DbContext, IDataContext
    {
        private readonly string _connectionString;

        /// <summary>
        /// Constructor used by EF console to run migrations locally
        /// </summary>
        public DataContext()
        {
            _connectionString = "Server=localhost;Database=NogginBug;Trusted_Connection=True;";
        }

        public DbSet<Bug> Bugs { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }
    }
}