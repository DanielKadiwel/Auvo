using AuvoProject_Core.Models;
using Microsoft.EntityFrameworkCore;

namespace AuvoProject_Core.Context
{
    public class ObjContext : DbContext
    {

        //HardCode
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ClimaTempoSimples;Data Source=DESKTECH-DK");
        }
    }
}
