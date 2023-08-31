using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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


        [HttpPost]
        public IActionResult Post(string Email, string Senha)
        {
            try
            {
                UsuarioDomain usuarioBuscado = _usuarioRepository.Logar(Email, Senha);

                if (usuarioBuscado ==  null)
                {
                    return NotFound("Usuário não encontrado!");
                }
                
                return Ok(usuarioBuscado);
            }

            catch (Exception erro)
            {          
                return BadRequest(erro.Message);
            }
        }
}
}
