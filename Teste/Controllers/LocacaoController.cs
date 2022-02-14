using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Teste.Data;
using Teste.Models;

namespace Teste.Controllers
{
    [Route("v1/locacoes")]
    [ApiController]
    public class LocacaoController : ControllerBase
    {
        private readonly DataContext _context;

        public LocacaoController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Locacao>>> GetRentals()
        {
            return await _context.Locacao.ToListAsync();
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Locacao>> GetRental(int id)
        {
            var locacao = await _context.Locacao.FindAsync(id);

            if (locacao == null)
            {
                return NotFound();
            }

            return locacao;
        }
        [HttpPost]
        public async Task<ActionResult<Locacao>> Create(Locacao obj)
        {
            if (FilmeEx(obj.FilmeId) && ClienteEx(obj.ClienteId) && ModelState.IsValid && _context.filmes.Find(obj.FilmeId).Disponivel == true)
            {
                _context.Add(obj);
                _context.filmes.Find(obj.FilmeId).Disponivel = false;
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetRental", new { id = obj.Id }, obj);
            }
            return BadRequest();
        }

        [HttpPut("LocacaoFechada/{id}")]
        public async Task<ActionResult<Locacao>> Cloese(int id)
        {
            if (!locacaoEx(id))
            {
                return NotFound();
            }
            Locacao locacao = _context.Locacao.Find(id);
            locacao.Devolucao = true;
            if (locacao.Dataretorno < DateTime.Today)
            {
                locacao.Multa = true;
            }
            _context.filmes.Find(locacao.FilmeId).Disponivel = true;

            try
            {
                await _context.SaveChangesAsync();
                return AcceptedAtAction("GetRental", new { id = locacao.Id }, locacao);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!locacaoEx(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        private bool locacaoEx(int id)
        {
            return _context.Locacao.Any(e => e.Id == id);
        }

        private bool FilmeEx(int id)
        {
            return _context.filmes.Any(e => e.Id == id);
        }
        private bool ClienteEx(int id)
        {
            return _context.clientes.Any(e => e.Id == id);
        }
    }
}