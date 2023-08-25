using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CadastroDigital.Api.Controllers
{
    [Route("[controller]")]
    public class Login : Controller
    {
        private readonly ILogger<Login> _logger;

        public Login(ILogger<Login> logger)
        {
            _logger = logger;
        }

        [HttpGet("cpf/{cpf}")]
        public async Task<IActionResult> GetPessoaByCpf(string cpf)
        {
            var pessoas = await _pessoaService.GetPessoaByCpf(cpf);

            if (pessoas.Equals(null))
                return NoContent();

            return Ok(pessoas);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}