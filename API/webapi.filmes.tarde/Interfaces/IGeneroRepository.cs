using webapi.filmes.tarde.Domains;

namespace webapi.filmes.tarde.Interfaces
    /// <summary>
    /// Interface responsável pelo repositório GeneroRepository.
    /// Define os métodos que serão implementados pelo repositório.
    /// </summary>
{
    public interface IGeneroRepository
    {
        // CRUD:

        // Ordem: TipoDeRetorno NomeMétodo(TipoParametro Nome Parametro)

        /// <summary>
        /// Método responsável por cadastrar um novo gênero.
        /// </summary>
        /// <param name="NovoGenero">Objeto que será cadastrado.</param>
        void Cadastrar(GeneroDomain NovoGenero);

        /// <summary>
        /// Retornar todos os gêneros cadastrados.
        /// </summary>
        /// <returns>Retorna uma lista de gêneros ( objetos ).</returns>
        List<GeneroDomain> ListarTodos();

        /// <summary>
        /// Buscar um objeto através do seu Id.
        /// </summary>
        /// <param name="id">Id do seu objeto que será buscado.</param>
        /// <returns>Objeto que foi buscado.</returns>
        GeneroDomain BuscarPorId(int id);

        /// <summary>
        /// Método responsável por atualizar um gênero existente passando o Id pelo corpo da requisição.
        /// </summary>
        /// <param name="genero">Objeto gênero com as novas informações.</param>
        void AtualizarIdCorpo(GeneroDomain genero);

        /// <summary>
        /// Atualizar um gênero existente passando o Id pela Url da requisição.
        /// </summary>
        /// <param name="id">Id do objeto a ser atualizado.</param>
        /// <param name="genero">Objeto com as novas informações.</param>
        void AtualizarIdUrl(int id, GeneroDomain genero);

        /// <summary>
        /// Método responsável por deletar um gênero existente.
        /// </summary>
        /// <param name="id">Id do objeto a ser deletado.</param>
        void Deletar(int id);




    }
}
