using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interfaces;
using webapi.filmes.tarde.Repositories;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace webapi.filmes.tarde.Controllers
{
    /// <summary>
    /// Define que a rota de uma requisição será do seguinte formato: dominio/api/nomeController.
    /// Exemplo: http://localhost:5000/api/Genero.
    /// </summary>
    [Route("api/[controller]")]

    /// <summary>
    /// Define que é um controlador de API.
    /// </summary>
    [ApiController]

    /// <summary>
    /// Define que o tipo de resposta da API é JSON.
    /// </summary>
    [Produces("application/json")]

    public class GeneroController : ControllerBase
    {
        /// <summary>
        /// Objeto que irá receber os métodos definidos na interface.
        /// </summary>
        private IGeneroRepository _generoRepository { get; set; }

        /// <summary>
        /// Instância udo objeto -generoRepository para que haja referência aos métodos no repositório.
        /// </summary>
        public GeneroController()
        {
            _generoRepository = new GeneroRepository();
        }

        /// <summary>
        /// EndPoint ( URL ) que acessa um método de listar os gêneros.
        /// </summary>
        /// <returns>Lista de gêneros e um status code.</returns>
        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            try
            {
                // Cria uma lista para receber os gêneros.
                List<GeneroDomain> listaGeneros = _generoRepository.ListarTodos();

                // Retorna o Status Code 200 - Ok e a lista de gêneros no formato JSON.
                return Ok(listaGeneros);
                // Ok = StatusCode(200).
            }
            catch (Exception erro)
            {
                // Retorna um Status Code 400 - BadRequest e a mensagem de erro. 
                return BadRequest(erro.Message);
            }

        }

        /// <summary>
        /// EndPoint que acessa um método de buscar gêneros através do seu Id.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("BuscarPorId")]
        public IActionResult GetById()
        {
            try
            {
                // 200 - Ok.
                GeneroDomain generoBuscado = _generoRepository.BuscarPorId(6);
                return Ok(generoBuscado);

            }
            catch (Exception erro)
            {
                // 400 - BadResquest.
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint que acessa um método de cadastrar um novo gênero.
        /// </summary>
        /// <param name="novoGenero"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(GeneroDomain novoGenero)
        {
            try
            {
                _generoRepository.Cadastrar(novoGenero);

                // 201 - Created.
                return Created("Objeto criado!", novoGenero);
            }
            catch (Exception erro)
            {
                // Retorna um Status Code 400 - BadRequest e a mensagem de erro.
                return BadRequest(erro.Message);
            }

        }

        /// <summary>
        /// Endpoint que acessa um método de deletar um novo gênero.
        /// </summary>
        /// <param name="idGenero"></param>
        /// <returns></returns>
        [HttpDelete("{idGenero}")]
        public IActionResult Delete(int idGenero)
        {
            try
            {
                // 200 - OK.
                _generoRepository.Deletar(idGenero);
                return Ok(idGenero);
            }
            catch (Exception erro)
            {
                // Retorna um Status Code 400 - BadRequest e a mensagem de erro.
                return BadRequest(erro.Message);
            }
        }


        /// <summary>
        /// Endpoint que acessa um método de atualizar um novo gênero através do corpo.
        /// </summary>
        /// <param name="genero"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put(GeneroDomain genero)
        {
            try
            {
                _generoRepository.AtualizarIdCorpo(genero);
                return Ok(genero);
            }
            catch (Exception erro)
            {

                // Retorna um Status Code 400 - BadRequest e a mensagem de erro.
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint que acessa um método de atualizar um novo gênero através da URL.
        /// </summary>
        /// <param name="idGenero"></param>
        /// <param name="novoGenero"></param>
        /// <returns></returns>
        [HttpPut("{idGenero}")]
        public IActionResult Put(int idGenero, GeneroDomain novoGenero)
        {
            try
            {
                 _generoRepository.AtualizarIdUrl(idGenero, novoGenero);
                return Ok(novoGenero);
            }
            catch (Exception erro)
            {

                // Retorna um Status Code 400 - BadRequest e a mensagem de erro.
                return BadRequest(erro.Message);
            }
        }




    }
}
