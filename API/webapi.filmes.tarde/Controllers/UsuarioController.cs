using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interfaces;
using webapi.filmes.tarde.Repositories;

namespace webapi.filmes.tarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        /// <summary>
        /// Objeto que irá receber os métodos definidos na interface.
        /// </summary>
        private IUsuarioRepository _usuarioRepository { get; set; }

        /// <summary>
        /// Instância udo objeto -generoRepository para que haja referência aos métodos no repositório.
        /// </summary>
        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Método de Login.
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(UsuarioDomain usuario)
        {
            try
            {
                UsuarioDomain usuarioBuscado = _usuarioRepository.Logar(usuario.Email, usuario.Senha);

                if (usuarioBuscado ==  null)
                {
                    return NotFound("Usuário não encontrado, e-mail ou senha inválidos!");
                }
                // Caso encontre o usuário buscado, prossegue para a criação do Token.

                // 1 - Definir as informações ( Claims ) que serão fornecidos no Token ( Payload ):
                var claims = new[]
                {
                    // Formato da claim ( Tipo, valor ).
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                    new Claim(ClaimTypes.Role, usuarioBuscado.Permissao.ToString()),

                    // Existe a possibilidade de criar uma claim personalizada.
                    new Claim("Claim Personalziada", "Valor Personalizado")
                };

                // 2 - Definir a chave de acesso ao Token:
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Filmes.chave.autenticacao-webapi-dev"));


                // 3 - Definir as credenciais do Token ( Header ):
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                // 4 - Gerar o token:
                var token = new JwtSecurityToken
                (

                // Emissor do token:
                issuer: "webapi.filmes.tarde",

                // Destinatário:
                audience: "wepapi.filmes.tarde",

                //Dados definidos nas claims:
                claims: claims,

                // Tempo de expiração:
                expires: DateTime.Now.AddMinutes(5),

                // Credênciais do Token:
                signingCredentials: creds


                );

                return Ok(usuarioBuscado);
            }

            catch (Exception erro)
            {          
                return BadRequest(erro.Message);
            }
        }
}
}
