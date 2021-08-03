using DapperExtensions;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Collections.Generic;
using System.Data;

namespace FacApi.Infra.Repositorio
{
    public class RepositorioBase : IRepositorioBase
    {
        private readonly string _connectionString;

        public NpgsqlConnection ConexaoBanco { get; private set; }

        public RepositorioBase(IConfiguration conexao) 
        {
            _connectionString = conexao.GetConnectionString("Conexao");
            this.ConexaoBanco = new NpgsqlConnection(_connectionString);
            DapperExtensions.DapperExtensions.SqlDialect = new DapperExtensions.Sql.PostgreSqlDialect();
        } 

        private void OpenConnection()
        {
            if (ConexaoBanco.State == ConnectionState.Closed && ConexaoBanco.State != ConnectionState.Open)
                ConexaoBanco.Open();
        }

        public IEnumerable<T> BuscarTodos<T>(string query)
        {
            OpenConnection();

            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
            return Dapper.SqlMapper.Query<T>(ConexaoBanco, query);
        }

        private void CloseConnection()

        {
            if (ConexaoBanco.State == ConnectionState.Open)
            {
                ConexaoBanco.Close();
                ConexaoBanco.Dispose();
            }
        }

        public void Dispose()
            => CloseConnection();

        public int Inserir<T>(T entidade) where T : class
        {
            OpenConnection();
            int.TryParse(ConexaoBanco.Insert(entidade).ToString(), out int retorno);
            return retorno;
        }

        public bool Deletar<T>(T entidade) where T : class
        {
            OpenConnection();
            return ConexaoBanco.Delete(entidade);
        }
    }
}
