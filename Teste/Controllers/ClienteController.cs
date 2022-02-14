using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teste.Data;
using Teste.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Teste.Controllers
{
    [Route("v1/clientes")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly DataContext _context;

        public ClienteController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Cliente>>> Get()
        {
            return await _context.clientes.ToListAsync();
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Cliente>> GetById(int id)
        {
            var cliente = await _context.clientes.FindAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }
            return cliente;
        }
        [HttpPost]
        public async Task<ActionResult<Cliente>> Create(string name, string cpf)
        {
            Cliente cliente = new(name, cpf);
            if (ModelState.IsValid && _context.clientes.Where(c => c.Cpf == cliente.Cpf).Any() == false)
            {
                _context.clientes.Add(cliente);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetById", new { id = cliente.Id }, cliente);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
