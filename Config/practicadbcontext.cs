using Microsoft.EntityFrameworkCore;
using practica.Models;

namespace practica.Config
{
    public class practicadbcontext:DbContext
    {
        public practicadbcontext(DbContextOptions contexto): base(contexto) {}

        public DbSet<ClientModel> Clients { get; set; }
        public DbSet<RolModel> Roles { get; set; }
    }
}
