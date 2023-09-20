using System;
using System.Security.Claims;

namespace CadastroDigital.Api.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetUserId(this ClaimsPrincipal user){

            return user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }

        public static int GetId(this ClaimsPrincipal user){

            return int.Parse(user.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        }

        // public static int GetUserId(this ClaimsPrincipal user){

        //     try{
        //         var ret = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        //         return int.Parse(user.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        //     }
        //     catch(Exception ex){

        //     }
        //     return 0;
            
        // }
    }
}