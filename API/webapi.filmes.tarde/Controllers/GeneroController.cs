using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    }
}
