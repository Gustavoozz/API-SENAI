using webapi.filmes.tarde.Domains;

namespace webapi.filmes.tarde.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório FilmeRepository.
    /// Define os métodos que serão implementados pelo repositório.
    /// </summary>
    public interface IFilmeRepository
    {
        /// <summary>
        /// Método responsável por cadastrar um novo filme.
        /// </summary>
        /// <param name="NovoFilme"></param>
        void Cadastrar(FilmeDomain NovoFilme);

        List<FilmeDomain> ListarTodos();

        FilmeDomain BuscarPorId(int id);

        void AtualizarIdCorpo(FilmeDomain filme);

        void AtualizarIdUrl(int idn, FilmeDomain filme);

        void Deletar(int id);
    }
}
