using Societe.Models;
using Microsoft.EntityFrameworkCore;


namespace Societe.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Societes> Societe { get; set; }
        public DbSet<PerSc> PerScs { get; set; }
    }
}
