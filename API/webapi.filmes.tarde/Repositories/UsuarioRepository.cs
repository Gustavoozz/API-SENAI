using System.Data.SqlClient;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interfaces;

namespace webapi.filmes.tarde.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string StringConexao = "Data Source = NOTE18-S14; Initial Catalog = Filmes_Tarde; User Id = sa; Pwd = Senai@134";

        UsuarioDomain usuarioBuscado = new();
        public UsuarioDomain Logar(string Email, string Senha)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryUsuario = $"SELECT IdUsuario, Email, Senha, Permissao FROM Usuario WHERE Email = (@email) AND Senha = (@senha)";

                using (SqlCommand cmd = new SqlCommand(queryUsuario, con))
                {
                    cmd.Parameters.AddWithValue("@email", Email);

                    cmd.Parameters.AddWithValue("@senha", Senha);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
                
            }
            return (usuarioBuscado);
        }

        
    }
}
