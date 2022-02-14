using Microsoft.EntityFrameworkCore;
using Teste.Models;

namespace Teste.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Cliente> clientes { get; set; }
        public DbSet<Filme> filmes { get; set; }
        public DbSet<Locacao> Locacao { get; set; }


    }
}
