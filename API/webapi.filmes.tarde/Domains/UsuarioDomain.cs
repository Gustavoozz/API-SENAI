using System.ComponentModel.DataAnnotations;

namespace webapi.filmes.tarde.Domains
{
    public class UsuarioDomain
    {
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "O campo e-mail é obrigatório!")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "O campo senha é obrigatório!")]
        public string? Senha { get; set; }

        public bool Permissao { get; set; }
    }
}
