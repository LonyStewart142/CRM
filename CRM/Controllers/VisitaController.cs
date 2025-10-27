using CRM.Application.DTOs;
using CRM.Application.Interfaces;
using CRM.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CRM.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VisitaController : ControllerBase
    {
        private readonly ILogger<VisitaController> _logger;
        private readonly IVisitaService _service;

        public VisitaController(IVisitaService service,ILogger<VisitaController> logger)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var visita = await _service.GetByIdAsync(id);
            return visita is null ? NotFound() : Ok(visita);
        }
        [HttpPost]
        public async Task<IActionResult> Create(VisitaDTO dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }
    }
}
