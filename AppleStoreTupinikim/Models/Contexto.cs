using Microsoft.EntityFrameworkCore;
using AppleStoreTupinikim.Models;

namespace AppleStoreTupinikim.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }
        public DbSet<AppleStoreTupinikim.Models.Login>? Login { get; set; }
        public DbSet<AppleStoreTupinikim.Models.Clientes>? Clientes { get; set; }
        public DbSet<AppleStoreTupinikim.Models.Produtos>? Produtos { get; set; }
        public DbSet<AppleStoreTupinikim.Models.Vendedores>? Vendedores { get; set; }
    }
}
