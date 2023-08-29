using webapi.filmes.tarde.Domains;

namespace webapi.filmes.tarde.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório FilmeRepository.
    /// Define os métodos ( métodos obrigatórios ) que serão implementados pelo repositório.
    /// </summary>
    public interface IFilmeRepository
    {

        /// <summary>
        /// Método responsável por cadastrar um novo filme.
        /// </summary>
        /// <param name="NovoFilme">Objeto que será cadastrado.</param>
        void Cadastrar(FilmeDomain NovoFilme);

        /// <summary>
        /////// Retornar todos os filmes cadastrados.
        /// </summary>
        /// <returns>Retorna uma lista de filmes ( objetos ).</returns>
        List<FilmeDomain> ListarTodos();

        /// <summary>
        /// Buscar um objeto através do seu Id.
        /// </summary>
        /// <param name="id">Id do seu objeto que será buscado.</param>
        /// <returns>Objeto que foi buscado.</returns>
        FilmeDomain BuscarPorId(int id);

        /// <summary>
        /// Método responsável por atualizar um filme existente passando o Id pelo corpo da requisição.
        /// </summary>
        /// <param name="filme">Objeto gênero com as novas informações.</param>
        void AtualizarIdCorpo(FilmeDomain filme);

        /// <summary>
        /// Atualizar um filme existente passando o Id pela Url da requisição.
        /// </summary>
        /// <param name="id">Id do objeto a ser atualizado.</param>
        /// <param name="filme">Objeto com as novas informações.</param>
        void AtualizarIdUrl(int id, FilmeDomain filme);

        /// <summary>
        /// Método responsável por deletar um filme existente.
        /// </summary>
        /// <param name="id">Id do objeto a ser deletado.</param>
        void Deletar(int id);
    }
}
