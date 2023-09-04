using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;

using CadastroDigital.App.Dtos;
using CadastroDigital.App.Services;
using CadastroDigital.App.Interfaces;
using System.IO;
using System.Linq;
using System;
using Microsoft.AspNetCore.Http;

namespace CadastroDigital.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaService _pessoaService;
        private readonly IWebHostEnvironment _hostEnviroment;

        public PessoaController(IPessoaService pessoaService, IWebHostEnvironment hostEnviroment)
        {
            _pessoaService = pessoaService;
            _hostEnviroment = hostEnviroment;
        }
 
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var pessoas = await _pessoaService.Get();

            if (pessoas == null)
                return NotFound("Nenhum registro encontrado.");

            return Ok(pessoas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try{
            var pessoa = await _pessoaService.GetPessoaById(id);

            if (pessoa.Equals(null))
                return NoContent();

            return Ok(pessoa);
            }
            catch(Exception ex){
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar a pessoa. Erro: {ex.Message}");
            }
        }

        // [HttpGet("cpf/{cpf}")]
        // public async Task<IActionResult> GetPessoaByCpf(string cpf)
        // {
        //     var pessoas = await _pessoaService.GetPessoaByCpf(cpf);

        //     if (pessoas.Equals(null))
        //         return NoContent();

        //     return Ok(pessoas);
        // }

        // [HttpGet("nome/{nome}")]
        // public async Task<IActionResult> GetByName(string nome)
        // {
        //     var pessoas = await _pessoaService.GetPessoaByName(nome);

        //     if (pessoas == null)
        //         return NoContent();

        //     return Ok(pessoas);
        // }

        // [HttpPost]
        // public async Task<IActionResult> Post(PessoaDto dto)
        // {
        //     var pessoa = await _pessoaService.GetPessoaByCpf(dto.PessoaFisica.Cpf);

        //     if (pessoa != null)
        //         return BadRequest("CPF já cadastrado.");

        //     var ret = await _pessoaService.AddPessoa(dto);
            
        //     if (ret == null)
        //         return BadRequest("Erro ao tentar incluir registro.");

        //     // return Ok("Registro incluído com sucesso");
        //     return Ok();
        // }

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

        [HttpPost("upload-image/{pessoaId}")]
        public async Task<IActionResult> UploadImage(int pessoaId)
        {
            var pessoa = await _pessoaService.GetPessoaById(pessoaId);

            if (pessoa == null)
                return NoContent();

            var file = Request.Form.Files[0];

            if (file.Length > 0)
            {
                DeleteImage(pessoa.PessoaFisica.Imagem);
                pessoa.PessoaFisica.Imagem = await SaveImage(file);
            }

            var ret = await _pessoaService.UpdatePessoa(pessoaId, pessoa);

            return Ok(ret);
        }

        [NonAction]
        public async Task<string> SaveImage(Microsoft.AspNetCore.Http.IFormFile imageFile){

            string imageName = new String(Path.GetFileNameWithoutExtension(imageFile.FileName)
                                                 .Take(10)
                                                 .ToArray())
                                                 .Replace(' ','-');

            imageName = $"{imageName}{DateTime.UtcNow.ToString("yymmssfff")}{Path.GetExtension(imageFile.FileName)}";

            var imagePath = Path.Combine(_hostEnviroment.ContentRootPath, @"Resources/Images");

            using (var fileStream = new FileStream(imagePath, FileMode.Create)){
                await imageFile.CopyToAsync(fileStream);
            }
            
            return imageName;
        }

        [NonAction]
        public void DeleteImage(string imageName){

            var imagePath = Path.Combine(_hostEnviroment.ContentRootPath, @"Resources/Images", imageName);
            
            if (System.IO.File.Exists(imagePath))
                System.IO.File.Delete(imagePath);
        }
    }
}
