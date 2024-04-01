using AngularApp.Server.Model;
using Microsoft.EntityFrameworkCore;

namespace AngularApp.Server.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<HistoricoModel> Historicos { get; set; }
    }
}
