using System.ComponentModel.DataAnnotations;

namespace webapi.filmes.tarde.Domains
{
    /// <summary>
    /// Classe que representa a entidade ( tabela ) 'Genero'.
    /// </summary>
    public class GeneroDomain
    {
        public int IdGenero { get; set; }

        // Data Annotation: Utilizada para exibir dados ou informações na interface de usuários.
        [Required(ErrorMessage = "O nome do gênero é obrigatório!")]
        public string? Nome { get; set; }

    }
}
