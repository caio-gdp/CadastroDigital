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
 
        // [HttpPut("{id}")]
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
