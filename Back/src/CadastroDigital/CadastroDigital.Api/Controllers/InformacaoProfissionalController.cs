using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using CadastroDigital.App.Dtos;
using CadastroDigital.App.Services;
using CadastroDigital.App.Interfaces;

namespace CadastroDigital.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InformacaoProfissionalController : ControllerBase
    {
        private readonly IInformacaoProfissionalService _informacaoProfissionalService;
   
        public InformacaoProfissionalController(IInformacaoProfissionalService informacaoProfissionalService)
        {
            _informacaoProfissionalService = informacaoProfissionalService;
        }

        // [HttpGet("{id}")]
        // public async Task<IActionResult> GetById(int id)
        // {
        //     var endereco = await _enderecoService.GetEnderecoByIdAsync(id);

        //     if (endereco.Equals(null))
        //         return NoContent();

        //     return Ok(endereco);
        // }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var informacaoProfissional = await _informacaoProfissionalService.GetById(id);

            if (informacaoProfissional.Equals(null))
                return NoContent();

            return Ok(informacaoProfissional);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Post(int id, InformacaoProfissionalDto dto)
        {
            var ret = await _informacaoProfissionalService.AddInformacaoProfissional(id, dto);
            
            if (ret == null)
                return BadRequest("Erro ao tentar incluir registro.");

            return Ok();
        }

         // [HttpPut("{pessoaid}")]
        // public async Task<IActionResult> Put(int id, EnderecoDto dto)
        // {
        //     var ret = await _enderecoService.UpdateEndereco(id, dto);
        
        //     if (ret == null)
        //         return BadRequest("Erro ao tentar atualizar registro.");

        //     return Ok("Registro atualizado com sucesso.");
        // }

        // [HttpDelete("{id}")]
        // public async Task<IActionResult> Delete(int id)
        // {
        //    var ret = await _enderecoService.DeleteEndereco(id);
            
        //     if (!ret)
        //         return BadRequest("Erro ao tentar excluir registro.");

        //     return Ok("Registro excluído com sucesso.");
        // }
    }
}
