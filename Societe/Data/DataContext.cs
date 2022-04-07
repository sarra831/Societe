using Societe.Models;
using Microsoft.EntityFrameworkCore;


namespace Societe.Data
{
    public class DataContext :DbContext

    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Societes> Societes { get; set; }
        public DbSet<PerSc> PerSc { get; set; }




    }
}
