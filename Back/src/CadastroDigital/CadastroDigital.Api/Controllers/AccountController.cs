using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CadastroDigital.App.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Threading;
using CadastroDigital.App.Dtos;
using System.Diagnostics.CodeAnalysis;
using System.Security.Claims;
using CadastroDigital.Api.Extensions;

namespace CadastroDigital.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly ITokenService _tokenService;

        public AccountController(IAccountService accountService,
                                 ITokenService tokenService)
        {
            _tokenService = tokenService;
            _accountService = accountService;
        }

        [HttpGet("GetUser")]
        [Authorize]
        public async Task<IActionResult> GetUser(){
            try{
                var id = User.GetUserId();
                var user = await _accountService.GetUserByUserId(id);
                return Ok(user);
            }
            catch(Exception ex){
                 return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar o usuário. Erro: {ex.Message}");
            }
        }

        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(UserDto userDto){
            try{
                if (await _accountService.UserExists(userDto.UserId))
                    return BadRequest("Usuário já existe");

                var user = await _accountService.CreateAccount(userDto);

                if (user != null)
                       return Ok(new{
                            userId = user.UserId,
                            token = _tokenService.CreateToken(user).Result
                        });

                return BadRequest("Usuário não criado, tente novamente mais tarde!");    
            }
            catch(Exception ex){
                 return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar registrar o usuário. Erro: {ex.Message}");
            }
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto){
            try{
                var user = await _accountService.GetUserByUserId(userLoginDto.UserId);

                if (user == null) return Unauthorized("Usuário ou senha incorretos.");

                var result = await _accountService.CheckUserPassword(user, userLoginDto.PasswordHash);
                
                if (!result.Succeeded) return Unauthorized(); 

                return Ok(new{
                    userId = user.UserId,
                    token = _tokenService.CreateToken(user).Result
                });
            }
            catch(Exception ex){
                 return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar efetuar login. Erro: {ex.Message}");
            }
        }

        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser(UserDto userDto){
            try{
                var user = await _accountService.GetUserByUserId(User.GetUserId());

                if (user == null) return Unauthorized("Usuário inválido.");

                var userReturn = await _accountService.UpdateAccount(userDto);

                if (user == null)
                    return NoContent(); 

                return Ok(userReturn);    
            }
            catch(Exception ex){
                 return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar atualizar o usuário. Erro: {ex.Message}");
            }
        }
    }
}