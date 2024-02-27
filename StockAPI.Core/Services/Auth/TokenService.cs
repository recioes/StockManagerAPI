using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using StockAPI.Core.Extensions;
using StockAPI.Core.Models.Auth;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace StockAPI.Core.Services.Auth
{

    public class TokenService
    {
        private readonly IConfiguration _configuration;
        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GenerateToken(User user)
        {
            //Estancia do manipulador de Token
            var tokenHandler = new JwtSecurityTokenHandler();
            //Chave da classe Configuration. O Token Handler espera um Array de Bytes, por isso é necessário converter
            var key = Encoding.ASCII.GetBytes(_configuration["JWT_KEY"]);
            //Convertendo JWTKey em byte
            var claims = user.GetClaims();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims), //Claims que vão compor o token
                Expires = DateTime.UtcNow.AddHours(1), //Por quanto tempo vai valer o token?
                SigningCredentials = //Assinatura do token, serve para identificar que mandou o token e garantir que o token não foi alterado no meio do caminho.
                new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            //Gerando o token
            var token = tokenHandler.CreateToken(tokenDescriptor);
            //Retornando tudo como uma string
            return tokenHandler.WriteToken(token);
        }
    }
}
