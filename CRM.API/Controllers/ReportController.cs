using CRM.Application.DTOs;
using CRM.Application.Interfaces;
using CRM.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CRM.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly ILogger<ReportController> _logger;
        private readonly IReportService _service;

        public ReportController(IReportService service,ILogger<ReportController> logger)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet("GetProductividadPorEjecutivo")]
        public async Task<IActionResult> GetProductividadPorEjecutivoAsync() => Ok(await _service.GetProductividadPorEjecutivoAsync());
    }
}
