using AuvoProject_Core.Models;
using Microsoft.EntityFrameworkCore;

namespace AuvoProject_Core.Context
{
    public class ObjContext : DbContext
    {
        public DbSet<Estado> Estado { get; set; }
        public DbSet<Cidade> Cidade { get; set; }
        public DbSet<PrevisaoClima> PrevisaoClima { get; set; }

        //HardCode
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Provider=SQLOLEDB.1;Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ClimaTempoSimples;Data Source=DESKTECH-DK");
        }
    }
}
