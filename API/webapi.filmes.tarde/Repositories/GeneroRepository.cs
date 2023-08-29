using System.Data.SqlClient;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interfaces;

namespace webapi.filmes.tarde.Repositories
{
    // Herança:
    public class GeneroRepository : IGeneroRepository
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
        public void AtualizarIdCorpo(GeneroDomain genero)
        {

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryUpdate = "UPDATE Genero SET Nome = @Nome WHERE IdGenero = @IdGenero";

                using (SqlCommand cmd = new SqlCommand(queryUpdate,con))
                {
                    cmd.Parameters.AddWithValue("@Nome", genero.Nome);

                    cmd.Parameters.AddWithValue("@IdGenero", genero.IdGenero);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }

            }
        }

        public void AtualizarIdUrl(int idGenero, GeneroDomain genero)
        {

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryUpdate = $"UPDATE Genero SET Nome = @Nome WHERE IdGenero LIKE {idGenero}";

                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", genero.Nome);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }

            }
        }

        /// <summary>
        /// Buscar um gênero através do seu Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public GeneroDomain BuscarPorId(int id)
        {
            
            GeneroDomain generoBuscado = new();

            
            using (SqlConnection con = new(StringConexao))
            {
                // Declara a query que será executada.
                string queryFindById = "SELECT IdGenero, Nome FROM Genero";

                con.Open();
                
                SqlDataReader rdr;
               
                using SqlCommand cmd = new(queryFindById, con);
                
                rdr = cmd.ExecuteReader();
               
                while (rdr.Read())
                {
                    if (Convert.ToInt32(rdr[0]) == id)
                    {
                        generoBuscado = new()
                        {
                            
                            IdGenero = Convert.ToInt32(rdr[0]),
                            
                            Nome = rdr[1].ToString(),
                        };

                    };
                };
            };
           
            return generoBuscado;
        }
            


        /// <summary>
        /// Cadastrar um novo gênero.
        /// </summary>
        public void Cadastrar(GeneroDomain novoGenero)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // Declara a query que será executada.
                string queryInsert = "INSERT INTO Genero(Nome) VALUES(@Nome)";

                // Declara o SqlCommand passando a query que será executada e a conexão com o BD.
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {

                    cmd.Parameters.AddWithValue("@Nome", novoGenero.Nome);

                    // Abre a conexão com o banco de dados.
                    con.Open();

                    // Executa a query.
                    cmd.ExecuteNonQuery();
                }
            }

        }

            /// <summary>
            /// Deleter um gênero.
            /// </summary>
            /// <param name="id"></param>
            public void Deletar(int idGenero)
            {

            // Declara o SqlCommand passando a query que será executada e a conexão com o BD.
            using (SqlConnection con = new SqlConnection(StringConexao))
                {
                // Declara a query que será executada.
                string queryDelete = $"Delete FROM Genero WHERE IdGenero = {idGenero}";

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
            /// Listar todos os objetos do tipo gênero.
            /// </summary>
            /// <returns>Lista de obejetos do tipo gênero.</returns>
            public List<GeneroDomain> ListarTodos()
        {
            // Cria uma lista de gêneros onde será armazenados os gêneros.
            List<GeneroDomain> listaGeneros = new List<GeneroDomain>();

            // Declara a SqlConnection passando a string de conexão como parâmetro.
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // Declara a instrução ( SELECT ) a ser executada.
                string querySelectAll = "SELECT IdGenero, Nome FROM Genero";

                // Abre a conexão com o banco de dados.
                con.Open();

                // Declara o SqlDartaReader para percorrer ( ler ) a tabela do banco de dados.
                SqlDataReader rdr;

                // Declara o SqlCommand passando a query que será executada e a conexão.
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    // Executa a query e armazena os dados do rdr.
                    rdr = cmd.ExecuteReader();

                    // Enquanto houver registros para serem lidos no rdr o laço se repetirá.
                    while (rdr.Read())
                    {
                        // Instancia  um objeto do tipo GeneroDomain.
                        GeneroDomain genero = new GeneroDomain()
                        {
                            // Atribui a propriedade IdGenero o valor da primeira coluna da tabela.
                            IdGenero = Convert.ToInt32(rdr[0]),

                            // Atribui a propriedade nome o valor da coluna Nome.
                            Nome = rdr["Nome"].ToString()
                        }; 

                        // Retornando a lista de gêneros.
                        listaGeneros.Add(genero);
                    };
                }

            }
            return listaGeneros;
        }

        



    }
}
