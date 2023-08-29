using System.Data.SqlClient;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interfaces;

namespace webapi.filmes.tarde.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {
        public void AtualizarIdCorpo(FilmeDomain filme)
        {
            throw new NotImplementedException();
        }

        public void AtualizarIdUrl(int id, FilmeDomain filme)  
        {
            throw new NotImplementedException();
        }

        public FilmeDomain BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(FilmeDomain NovoFilme)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<FilmeDomain> ListarTodos()
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
    
