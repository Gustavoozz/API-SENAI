using System.Data.SqlClient;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interfaces;

namespace webapi.filmes.tarde.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {
        /// <summary>
        /// String de conexão com o Banco de Dados que recebe os seguintes parâmetros:
        /// Data Source: Nome do servidor do banco.
        /// Initial Catalog: Nome do banco de dados.
        /// Autenticação.
        /// - Windows: Integrate Security = True.
        /// - SQlServer: User Id = sa; Pwd = Senha.
        /// </summary>
        private string StringConexao = "Data Source = NOTE18-S14; Initial Catalog = Filmes_Tarde; User Id = sa; Pwd = Senai@134";

        /// <summary>
        /// Atualizar um gênero.
        /// </summary>
        /// <param name="genero"></param>
        public void AtualizarIdCorpo(FilmeDomain filme)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryUpdate = $"UPDATE Filme SET Titulo = (@Titulo) WHERE IdFilme LIKE {filme.IdFilme}";

                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@Titulo", filme.Titulo);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }

            }
        }

        public void AtualizarIdUrl(int id, FilmeDomain filme)  
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryUpdate = $"UPDATE Genero SET Nome = @Nome WHERE IdGenero LIKE {id}";

                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@Titulo", filme.Titulo);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }

            }
        }

        public FilmeDomain BuscarPorId(int id)
        {
            FilmeDomain filmeBuscado = new();


            using (SqlConnection con = new(StringConexao))
            {
                // Declara a query que será executada.
                string queryFindById = $"SELECT * FROM Filme WHERE IdFilme LIKE {id}";

                con.Open();

                SqlDataReader rdr;

                using SqlCommand cmd = new(queryFindById, con);

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    if (Convert.ToInt32(rdr[0]) == id)
                    {
                        filmeBuscado = new()
                        {
                            IdFilme = Convert.ToInt32(rdr["IdFilme"]),
                            IdGenero = Convert.ToInt32(rdr["IdGenero"]),
                            Titulo = rdr["Titulo"].ToString(),
                        };

                    };
                };
            };

            return filmeBuscado;
        }

        public void Cadastrar(FilmeDomain novoFilme)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // Declara a query que será executada.
                string queryInsert = $"INSERT INTO Filme(IdGenero, Titulo) VALUES (@IdGenero, @Titulo)";

                // Declara o SqlCommand passando a query que será executada e a conexão com o BD.
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@IdGenero", novoFilme.IdGenero);
                    cmd.Parameters.AddWithValue("@Titulo", novoFilme.Titulo);

                    // Abre a conexão com o banco de dados.
                    con.Open();

                    // Executa a query.
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            // Declara o SqlCommand passando a query que será executada e a conexão com o BD.
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // Declara a query que será executada.
                string queryDelete = $"Delete FROM Filme WHERE IdFilme LIKE {id}";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    // Abre a conexão com o banco de dados.
                    con.Open();

                    // Executa a query.
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
		/// Retornar todos os gêneros cadastrados
		/// </summary>
		/// <returns>Uma lista de objetos</returns>
		public List<FilmeDomain> ListarTodos()
        {
            //Cria uma lista de gêneros para armazená-los
            List<FilmeDomain> ListaFilmes = new();

            //Declara a SqlConnection passando a String de Conexão como parâmetro
            using (SqlConnection con = new(StringConexao))
            {
                //Declara a instrução a ser executada
                string querySelectAll = "SELECT F.IdFilme,F.IdGenero,F.Titulo,G.Nome FROM Filme AS F INNER JOIN Genero AS G ON F.IdGenero = G.IdGenero";

                //Abre a conexão com o banco de dados
                con.Open();

                //Declara o SqlDataReader para percorrer (ler) a tabela no banco de dados
                SqlDataReader rdr;

                //Declara o SqlCommand passando a query que será executada e a conexão
                using SqlCommand cmd = new(querySelectAll, con);
                //Executa a query e armazena os dados no rdr
                rdr = cmd.ExecuteReader();

                //Enquanto houver registros para serem lidos no rdr, o laço se repetirá.
                while (rdr.Read())
                {
                    FilmeDomain Filme = new()
                    {
                        //Atribui à propriedade IdFilme os valores das colunas
                        IdFilme = Convert.ToInt32(rdr["IdFilme"]),
                        IdGenero = Convert.ToInt32(rdr["IdGenero"]),
                        Titulo = rdr["Titulo"].ToString(),

                        Genero = new GeneroDomain()
                        {
                            Nome = Convert.ToString(rdr["Nome"]),
                        }
                        
                    };

                    
                    ListaFilmes.Add(Filme);
                };
            }

            //Retorna a lista de gêneros
            return ListaFilmes;

            
        }
    }
}