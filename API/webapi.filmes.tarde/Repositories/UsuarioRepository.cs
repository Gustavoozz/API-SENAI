using System.Data.SqlClient;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interfaces;

namespace webapi.filmes.tarde.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string StringConexao = "Data Source = NOTE18-S14; Initial Catalog = Filmes_Tarde; User Id = sa; Pwd = Senai@134";
        public UsuarioDomain Logar(string Email, string Senha)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryUsuario = "SELECT IdUsuario, Email, Senha, Permissao FROM Usuario WHERE Email = @Email AND Senha = @Senha";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(queryUsuario, con))
                {
                    cmd.Parameters.AddWithValue("@Email", Email);

                    cmd.Parameters.AddWithValue("@Senha", Senha);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        UsuarioDomain usuarioBuscado = new UsuarioDomain()
                        {
                            IdUsuario = Convert.ToInt32(rdr[0]),

                            Email = rdr["Email"].ToString(),

                            Senha = rdr["Senha"].ToString(),

                            Permissao = Convert.ToBoolean(rdr[0])
                        };
                        return usuarioBuscado;
                    }
                    return null;
                }

            }


            }
        }
    }
