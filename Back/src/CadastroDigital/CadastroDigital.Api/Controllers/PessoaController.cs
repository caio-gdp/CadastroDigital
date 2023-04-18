using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using CadastroDigital.App.Dtos;
using CadastroDigital.App.Services;
using CadastroDigital.App.Interfaces;

namespace CadastroDigital.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaService _pessoaService;
   
        public PessoaController(IPessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }
 
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var pessoas = await _pessoaService.GetAllPessoasAsync();

            if (pessoas == null)
                return NotFound("Nenhum registro encontrado.");

            return Ok(pessoas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var pessoa = await _pessoaService.GetPessoaByIdAsync(id);

            if (pessoa.Equals(null))
                return NoContent();

            return Ok(pessoa);
        }

        [HttpGet("cpf/{cpf}")]
        public async Task<IActionResult> GetByCpf(string cpf)
        {
            var pessoas = await _pessoaService.GetPessoaByCpfAsync(cpf);

            if (pessoas.Equals(null))
                return NoContent();

            return Ok(pessoas);
        }

        [HttpGet("nome/{nome}")]
        public async Task<IActionResult> GetByName(string nome)
        {
            var pessoas = await _pessoaService.GetPessoaByNameAsync(nome);

            if (pessoas == null)
                return NoContent();

            return Ok(pessoas);
        }

        [HttpPost]
        public async Task<IActionResult> Post(PessoaDto dto)
        {
            var ret = await _pessoaService.AddPessoa(dto);
            
            if (ret == null)
                return BadRequest("Erro ao tentar incluir registro.");

            return Ok("Registro incluído com sucesso.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, PessoaDto dto)
        {
            var ret = await _pessoaService.UpdatePessoa(id, dto);
            
            if (ret == null)
                return BadRequest("Erro ao tentar atualizar registro.");

            return Ok("Registro atualizado com sucesso.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
           var ret = await _pessoaService.DeletePessoa(id);
            
            if (!ret)
                return BadRequest("Erro ao tentar excluir registro.");

            return Ok("Registro excluído com sucesso.");
        }
    }
}
