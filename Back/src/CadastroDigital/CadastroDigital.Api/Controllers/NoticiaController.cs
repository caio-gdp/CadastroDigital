using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using CadastroDigital.App.Interfaces;

namespace CadastroDigital.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NoticiaController : Controller
    {
        private readonly INoticiaService _noticiaService;
        private readonly IWebHostEnvironment _hostEnviroment;
        // private readonly ILogger<NoticiaController> _logger;

        public NoticiaController(INoticiaService noticiaService, IWebHostEnvironment hostEnviroment)
        {
            _noticiaService = noticiaService;
            _hostEnviroment = hostEnviroment;
            // _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var noticias = await _noticiaService.Get();

            if (noticias == null)
                return NotFound("Nenhum registro encontrado.");

            return Ok(noticias);
        }
    }
}