namespace webapi.filmes.tarde.Domains
{
    public class UsuarioDomain
    {
        public int idUsuario { get; set; }

        public string? Email { get; set; }

        public string? Senha { get; set; }

        public bool Permissao { get; set; }
    }
}
