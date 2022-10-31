using Microsoft.AspNetCore.Mvc;
using Api.Domain.Entities;
using Api.Domain.Enum;
using Api.App.Services;
using Api.Infra.Context;

namespace Api.WebUI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VendaController : ControllerBase
    {
        private readonly PottencialContext _context;

        public VendaController(PottencialContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Create(Venda venda)
        {
            var vendaCriada = new VendaService(_context).Create(venda);
            return Ok(vendaCriada);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var venda = new VendaService(_context).GetByIdJoin(id);
            if (venda == null)
                return NotFound();

            return Ok(venda);
        }

        [HttpPut]
        [Route("Status/{id}")]
        public IActionResult UpdateStatus(int id, EnumStatus status)
        {
            var vendaAtualizada = new VendaService(_context).UpdateStatus(id, status);
            if (vendaAtualizada == null)
                return NotFound();
                
            return Ok(vendaAtualizada);
        }
    }
}