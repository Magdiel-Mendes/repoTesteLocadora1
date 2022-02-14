using System;
using System.Linq;
using Teste.Models;

namespace Teste.Data
{
    public class SeedingService
    {
        private DataContext _context;
        public SeedingService(DataContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.clientes.Any() ||
                _context.Locacao.Any() ||
                _context.filmes.Any())
            {
                return; 
            }
            Cliente c1 = new("Magdiel", "00256312308");
            Cliente c2 = new("Raphael", "00253322268");

            Filme m1 = new("Senhor dos aneis");
            Filme m2 = new("Perdidos no espaço");

            Locacao r1 = new(1, 2, new DateTime(2021, 5, 2));
            Locacao r2 = new(1, 1, new DateTime(2021, 10, 6));
            Locacao r3 = new(2, 1, new DateTime(2021, 10, 20));

            _context.clientes.AddRange(c1, c2);
            _context.filmes.AddRange(m1, m2);
            _context.Locacao.AddRange(r1, r2, r3);
            _context.SaveChanges();
        }
    }
}
