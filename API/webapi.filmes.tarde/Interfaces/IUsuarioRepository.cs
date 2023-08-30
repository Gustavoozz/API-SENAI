using webapi.filmes.tarde.Domains;

namespace webapi.filmes.tarde.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IUsuarioRepository
    {
        UsuarioDomain Logar(string Email, string Senha);
    }
}
