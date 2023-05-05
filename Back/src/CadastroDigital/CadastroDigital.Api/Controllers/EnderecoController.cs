﻿using System.Threading.Tasks;
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
   
        public EnderecoController(IEnderecoService EnderecoService)
        {
            _enderecoService = EnderecoService;
        }

        // [HttpGet("{id}")]
        // public async Task<IActionResult> GetById(int id)
        // {
        //     var endereco = await _enderecoService.GetEnderecoByIdAsync(id);

        //     if (endereco.Equals(null))
        //         return NoContent();

        //     return Ok(endereco);
        // }

        // [HttpPost]
        // public async Task<IActionResult> Post(EnderecoDto dto)
        // {
        //     var ret = await _enderecoService.AddEndereco(dto);
            
        //     if (ret == null)
        //         return BadRequest("Erro ao tentar incluir registro.");

        //     return Ok("Registro incluído com sucesso.");
        // }

 
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