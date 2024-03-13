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

        [HttpGet("{idUser}")]
        public async Task<IActionResult> GetByIdUser(int idUser)
        {
            var endereco = await _enderecoService.GetByIdUser(idUser);

            if (endereco == null)
                return NoContent();

            return Ok(endereco);
        }

        [HttpPost("{idUser}")]
        public async Task<IActionResult> Post(int idUser, EnderecoDto dto)
        {
            var ret = await _enderecoService.AddEndereco(idUser, dto);
            
            if (ret == null)
                return BadRequest("Erro ao tentar incluir registro.");

            return Ok();
        }

        [HttpPut("{idUser}")]
        public async Task<IActionResult> Put(int idUser, EnderecoDto dto)
        {
            var ret = await _enderecoService.UpdateEndereco(idUser, dto);

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
