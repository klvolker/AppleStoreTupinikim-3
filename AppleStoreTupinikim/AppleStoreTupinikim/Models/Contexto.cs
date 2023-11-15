using Microsoft.EntityFrameworkCore;
using AppleStoreTupinikim.Models;

namespace AppleStoreTupinikim.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> opcoes) : base(opcoes) { }
        public DbSet<AppleStoreTupinikim.Models.clientes>? clientes { get; set; }
        public DbSet<AppleStoreTupinikim.Models.produtos>? produtos { get; set; }
        public DbSet<AppleStoreTupinikim.Models.vendedores>? vendedores { get; set; }
        public DbSet<AppleStoreTupinikim.Models.tela_de_login>? tela_de_login { get; set; }
    }
}
