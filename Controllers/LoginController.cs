using Chapter_TURMA14.Interfaces;
using Chapter_TURMA14.Models;
using Chapter_TURMA14.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace Chapter_TURMA14.Controllers
{

    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioRepository _iUsuarioRepository;

        public LoginController (IUsuarioRepository iUsuarioRepository)
        {
            _iUsuarioRepository = iUsuarioRepository;
        }

        [HttpGet]
        public IActionResult Login(LoginViewModelcs dadosLogin) 
        {
            try
            {
                Usuario usuarioBuscado = _iUsuarioRepository.Login(dadosLogin.email, dadosLogin.senha);

                if (usuarioBuscado == null)
                {
                    return Unauthorized(new {msg = "e-mail ou senha incorreto"});
                }

                var minhaClaims = new[]
                {

                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.Id.ToString()),
                    new Claim(ClaimTypes.Role, usuarioBuscado.Tipo)

                };
                var chave = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("chapter-chave-autenticacao"));
                var credenciais = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);
                var meuToken = new JwtSecurityToken(

                    issuer: "chapter.webapi",

                    audience: "chapter.webapi",

                    claims: minhaClaims,

                    expires: DateTime.Now.AddMinutes(60),

                    signingCredentials: credenciais


                    );

                return Ok( new { Token =  new JwtSecurityTokenHandler().WriteToken(meuToken)});



                
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
    }
}
