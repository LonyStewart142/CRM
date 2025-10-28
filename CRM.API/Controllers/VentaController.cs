using CRM.Application.DTOs;
using CRM.Application.Interfaces;
using CRM.Application.Services;
using CRM.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CRM.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VentaController : ControllerBase
    {
        private readonly ILogger<VentaController> _logger;
        private readonly IVentaService _service;

        public VentaController(IVentaService service,ILogger<VentaController> logger)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var venta = await _service.GetByIdAsync(id);
            return venta is null ? NotFound() : Ok(venta);
        }
        [HttpPost]
        public async Task<IActionResult> Create(VentaDTO dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPost("UploadVentas")]
        public async Task<IActionResult> UploadVentas(IFormFile file)
        {
            var result = await _service.ProcesarArchivoAsync(file);
            return Ok(result);
        }

    }
}
