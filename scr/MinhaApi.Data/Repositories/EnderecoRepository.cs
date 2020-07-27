using Dapper;
using MinhaApi.Business.Interfaces;
using MinhaApi.Business.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaApi.Data.Repository
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly string _stringConnection;

        public EnderecoRepository()
        {
            _stringConnection = "Server=(localdb)\\mssqllocaldb;Database=ClienteApi;Trusted_Connection=True;MultipleActiveResultSets=true;";
        }

        public async Task<int> Add(Endereco entity)
        {

            var sql = "INSERT INTO Endereco (Logradouro, Bairro, Cidade, Estado) VALUES (@Logradouro, @Bairro, @Cidade, @Estado);";
            using (var connection = new SqlConnection(_stringConnection))
            {
                connection.Open();
                var linhasAfetadas = await connection.ExecuteAsync(sql, entity);
                return linhasAfetadas;
            }

        }

     
        public async Task<int> Delete(int id)
        {
            var sql = "delete from Endereco where Id = @Id;";
            using (var connection = new SqlConnection(_stringConnection))
            {
                connection.Open();
                var linhasAfetadas = await connection.ExecuteAsync(sql, new { Id = id });
                return linhasAfetadas;
            }
        }

        public async Task<Endereco> Get(int id)
        {
            var sql = "select * from endereco where Id = @Id;";
            using (var connection = new SqlConnection(_stringConnection))
            {
                connection.Open();
                var result = await connection.QueryAsync<Endereco>(sql, new { Id = id });
                return result.FirstOrDefault();
            }
        }

        public async Task<IEnumerable<Endereco>> GetAll()
        {
            var sql = "select * from endereco;";
            using (var connection = new SqlConnection(_stringConnection))
            {
                connection.Open();
                var result = await connection.QueryAsync<Endereco>(sql);
                return result;
            }
        }

        public async Task<int> Update(Endereco entity)
        {
            var sql = "update Endereco set Logradouro = @Logradouro, Bairro = @Bairro, Cidade = @Cidade, Estado = @Estado where Id = @Id;";
            using (var connection = new SqlConnection(_stringConnection))
            {
                connection.Open();
                var linhasAfetadas = await connection.ExecuteAsync(sql, entity);
                return linhasAfetadas;
            }
        }

    
    }
}
