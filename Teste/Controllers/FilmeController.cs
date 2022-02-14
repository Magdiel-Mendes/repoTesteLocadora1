using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Teste.Data;
using Teste.Models;

namespace Teste.Controllers
{

    [Route("v1/fimes")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private readonly DataContext _context;

        public FilmeController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Filme>>> Get()
        {
            return await _context.filmes.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Filme>> Create(string title)
        {
            Filme filme = new(title);
            if (ModelState.IsValid)
            {
                _context.filmes.Add(filme);
                await _context.SaveChangesAsync();
                return CreatedAtAction("Get", new { id = filme.Id }, filme);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

    }
}
