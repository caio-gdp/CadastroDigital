using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using CadastroDigital.App.Interfaces;

namespace CadastroDigital.Api.Controllers
{
    [Route("api/[controller]")]
    public class ParceriaController : Controller
    {
        private readonly IParceriaService _parceriaService;
        private readonly IWebHostEnvironment _hostEnviroment;
        // private readonly ILogger<ParceriaController> _logger;

        // public ParceriaController(ILogger<ParceriaController> logger)
        public ParceriaController(IParceriaService parceriaService, IWebHostEnvironment hostEnviroment)
        {
            _parceriaService = parceriaService;
            _hostEnviroment = hostEnviroment;
            // _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var parcerias = await _parceriaService.Get();

            if (parcerias == null)
                return NotFound("Nenhum registro encontrado.");

            return Ok(parcerias);
        }


        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}