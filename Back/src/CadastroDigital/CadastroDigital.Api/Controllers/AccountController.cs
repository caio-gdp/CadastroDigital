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

                UserDtoResponse userResponse = new UserDtoResponse{
                    Id = user.Id,
                    UserId = user.UserId,
                    Token = _tokenService.CreateToken(user).Result,
                    Name = user.Name,
                    Noticia = user.Noticia,
                    TipoPessoa = user.TipoPessoa,
                    PassoCadastroId = user.PassoCadastroId,
                    StatusCadastroId = user.StatusCadastroId,
                    DateOfBirth = user.DateOfBirth,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber
                };

                return Ok(userResponse);
            }
            catch(Exception ex){
                 return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar efetuar login. Erro: {ex.Message}");
            }
        }

        [HttpPut("UpdateUser")]
        [Authorize]
        public async Task<IActionResult> UpdateUser(UserDto userDto){
            try{
                //var user = await _accountService.GetUserByUserId(userDto.UserId);

               // if (user == null) return Unauthorized("Usuário inválido.");

                var userReturn = await _accountService.UpdateAccount(userDto);

                if (userReturn == null)
                    return Unauthorized("Usuário inválido.");

                UserDtoResponse userResponse = new UserDtoResponse{
                    Id = userReturn.Id,
                    UserId = userReturn.UserId,
                    Token = userReturn.Token,
                    Name = userReturn.Name,
                    Noticia = userReturn.Noticia,
                    TipoPessoa = userReturn.TipoPessoa,
                    PassoCadastroId = userReturn.PassoCadastroId,
                    StatusCadastroId = userReturn.StatusCadastroId,
                    DateOfBirth = userReturn.DateOfBirth,
                    Email = userReturn.Email,
                    PhoneNumber = userReturn.PhoneNumber
                };    

                return Ok(userResponse);    
            }
            catch(Exception ex){
                 return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar atualizar o usuário. Erro: {ex.Message}");
            }
        }
    }
}