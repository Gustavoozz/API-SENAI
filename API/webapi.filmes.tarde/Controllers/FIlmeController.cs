using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interfaces;
using webapi.filmes.tarde.Repositories;

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

    public class FilmeController : ControllerBase
    {
        /// <summary>
        /// Objeto que irá receber os métodos definidos na interface.
        /// </summary>
        private IFilmeRepository _filmeRepository { get; set; }

        /// <summary>
        /// Instância udo objeto -generoRepository para que haja referência aos métodos no repositório.
        /// </summary>
        public FilmeController()
        {
            _filmeRepository = new FilmeRepository();
        }

        /// <summary>
        /// EndPoint ( URL ) que acessa um método de listar os filmes.
        /// </summary>
        /// <returns>Lista de gêneros e um status code.</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                // Cria uma lista para receber os gêneros.
                List<FilmeDomain> listaFilmes = _filmeRepository.ListarTodos();

                // Retorna o Status Code 200 - Ok e a lista de gêneros no formato JSON.
                return Ok(listaFilmes);
                // Ok = StatusCode(200).
            }
            catch (Exception erro)
            {
                // Retorna um Status Code 400 - BadRequest e a mensagem de erro. 
                return BadRequest(erro.Message);
            }

        }


        [HttpPut]
        public IActionResult Put(FilmeDomain filme)
        {
            try
            {
                _filmeRepository.AtualizarIdCorpo(filme);
                return Ok(filme);
            }
            catch (Exception erro)
            {

                // Retorna um Status Code 400 - BadRequest e a mensagem de erro.
                return BadRequest(erro.Message);
            }
        }

        [HttpPut("{idFilme}")]
        public IActionResult Put(int idFilme, FilmeDomain novoFilme)
        {
            try
            {
                _filmeRepository.AtualizarIdUrl(idFilme, novoFilme);
                return Ok(novoFilme);
            }
            catch (Exception erro)
            {

                // Retorna um Status Code 400 - BadRequest e a mensagem de erro.
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// EndPoint que acessa um método de buscar filmes através do seu Id.
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                // 200 - Ok.
                FilmeDomain filmeBuscado = _filmeRepository.BuscarPorId(id);
                return Ok(filmeBuscado);

            }
            catch (Exception erro)
            {
                // 400 - BadResquest.
                return BadRequest(erro.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(FilmeDomain novoFilme)
        {
            try
            {
                _filmeRepository.Cadastrar(novoFilme);

                // 201 - Created.
                return Created("Objeto criado!", novoFilme);
            }
            catch (Exception erro)
            {
                // Retorna um Status Code 400 - BadRequest e a mensagem de erro.
                return BadRequest(erro.Message);
            }

        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                // 200 - OK.
                _filmeRepository.Deletar(id);
                return StatusCode(204);
            }
            catch (Exception erro)
            {
                // Retorna um Status Code 400 - BadRequest e a mensagem de erro.
                return BadRequest(erro.Message);
            }
        }


    }
}


