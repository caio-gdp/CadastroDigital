using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using CadastroDigital.App.Dtos;
using CadastroDigital.App.Services;
using CadastroDigital.App.Interfaces;

namespace CadastroDigital.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoService _enderecoService;
   
        public EnderecoController(IEnderecoService enderecoService)
        {
            _enderecoService = enderecoService;
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
            var endereco = await _enderecoService.GetById(id);

            if (endereco == null)
                return NoContent();

            return Ok(endereco);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Post(int id, EnderecoDto dto)
        {
            var ret = await _enderecoService.AddEndereco(id, dto);
            
            if (ret == null)
                return BadRequest("Erro ao tentar incluir registro.");

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(EnderecoDto dto)
        {
            var ret = await _enderecoService.UpdateEndereco(dto);

            if (ret == null)
                return BadRequest("Erro ao tentar atualizar registro.");

            return Ok();
        }

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
