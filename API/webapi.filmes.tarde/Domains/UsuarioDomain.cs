using System.ComponentModel.DataAnnotations;

namespace webapi.filmes.tarde.Domains
{
    public class UsuarioDomain
    {
        public int IdUsuario { get; set; }


        [Required(ErrorMessage = "Campo obrigatório!")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public string? Senha { get; set; }

        public bool Permissao { get; set; }
    }
}
