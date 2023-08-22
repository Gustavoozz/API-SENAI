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
        private string StringConexao = "Data Source = NOTE18-S14; Initial Catalog = Filmes_Tarde; User Id=sa; Pwd=Senai@134";
        public void AtualizarIdCorpo(GeneroDomain genero)
        {
            throw new NotImplementedException();
        }

        public void AtualizarIdUrl(int id, GeneroDomain genero)
        {
            throw new NotImplementedException();
        }

        public GeneroDomain BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(GeneroDomain NovoGenero)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
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
                string querySelect = "SELECT IdGenero, Nome FROM Genero";

                // Abre a conexão com o banco de dados.
                con.Open();

                // Declara o SqlDartaReader para percorrer ( ler ) a tabela do banco de dados.
                SqlDataReader rdr;

                // Declara o SqlCommand passando a query que será executada e a conexão.
                using (SqlCommand cmd = new SqlCommand(querySelect,con))
                {
                    // Executa a query e armazena os dados do rdr.
                    rdr = cmd.ExecuteReader();

                    // Enquanto houver registros para serem lidos no rdr o laço se repetirá.
                    while(rdr.Read())
                    {
                        // Instancia  um objeto do tipo GeneroDomain.
                        GeneroDomain genero = new GeneroDomain();
                        {
                            // Atribui a propriedade IdGenero o valor da primeira coluna da tabela.
                            IdGenero = Convert.ToInt32(rdr[0]);

                            // Atribui a propriedade nome o valor da coluna Nome.
                            Nome = rdr["Nome"].ToString();
                        };

                        // Adiciona o objeto criado dentro da lista.
                        listaGeneros.Add(genero);
                    }
                }
            }
            // Retornando a lista de gêneros.
            return listaGeneros;
        }
    }
}
