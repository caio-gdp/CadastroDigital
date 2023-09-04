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

namespace CadastroDigital.Api.Controllers
{
    [Authorize]
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

        [HttpGet("GetUser/{userName}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetUser(string userName){
            try{
                var user = await _accountService.GetUserByUserName(userName);
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
                if (await _accountService.UserExists(userDto.UserName))
                    return BadRequest("Usuário já existe");

                var user = await _accountService.CreateAccount(userDto);

                if (user != null)
                    return Ok(user); 

                return BadRequest("Usuário não criado, tente novamente mais tarde!");    
            }
            catch(Exception ex){
                 return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar o usuário. Erro: {ex.Message}");
            }
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto){
            try{
                var user = await _accountService.GetUserByUserName(userLoginDto.UserName);

                if (user == null) return Unauthorized("Usuário ou senha incorretos.");

                var result = await _accountService.CheckUserPassword(user, userLoginDto.PasswordHash);
                
                if (!result.Succeeded) return Unauthorized(); 

                //return Ok(user);
 
                
                return Ok(new{
                    userName = user.UserName,
                    token = _tokenService.CreateToken(user).Result
                });
            }
            catch(Exception ex){
                 return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar o usuário. Erro: {ex.Message}");
            }
        }
    }
}