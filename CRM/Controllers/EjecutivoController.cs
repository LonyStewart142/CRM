using CRM.Application.DTOs;
using CRM.Application.Interfaces;
using CRM.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CRM.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EjecutivoController : ControllerBase
    {
        private readonly ILogger<EjecutivoController> _logger;
        private readonly IEjecutivoService _service;

        public EjecutivoController(IEjecutivoService service,ILogger<EjecutivoController> logger)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var ejecutivo = await _service.GetByIdAsync(id);
            return ejecutivo is null ? NotFound() : Ok(ejecutivo);
        }
        [HttpPost]
        public async Task<IActionResult> Create(EjecutivoDTO dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }
    }
}
