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
    public class ClienteRepository : IClienteRepository
    {
        private readonly string _stringConnection;

        public ClienteRepository()
        {
            _stringConnection = "Server=(localdb)\\mssqllocaldb;Database=ClienteApi;Trusted_Connection=True;MultipleActiveResultSets=true;";
        }

        public async Task<int> Add(Cliente entity)
        {

            var sql = "INSERT INTO Cliente (Nome, Cpf, DataNascimento, IdEndereco) VALUES (@Nome, @Cpf, @DataNascimento, @IdEndereco);";
            using (var connection = new SqlConnection(_stringConnection))
            {
                connection.Open();
                var linhasAfetadas = await connection.ExecuteAsync(sql, entity);
                return linhasAfetadas;
            }

        }

        public async Task<int> Delete(int id)
        {
            var sql = "delete from cliente where Id = @Id;";
            using (var connection = new SqlConnection(_stringConnection))
            {
                connection.Open();
                var linhasAfetadas = await connection.ExecuteAsync(sql, new { Id = id });
                return linhasAfetadas;
            }
        }

        public async Task<IEnumerable<Cliente>> GetAll()
        {
            var sql = "select * from cliente;";
            using (var connection = new SqlConnection(_stringConnection))
            {
                connection.Open();
                var result = await connection.QueryAsync<Cliente>(sql);
                return result;
            }
        }

        public async Task<int> Update(Cliente entity)
        {
            var sql = "update cliente set Nome = @Nome, Cpf = @Cpf, DataNascimento = @DataNascimento, IdEndereco = @IdEndereco where Id = @Id;";
            using (var connection = new SqlConnection(_stringConnection))
            {
                connection.Open();
                var linhasAfetadas = await connection.ExecuteAsync(sql, entity);
                return linhasAfetadas;
            }
        }

        public async Task<Cliente> Get(int id)
        {
            var sql = "select * from cliente where Id = @Id;";
            using (var connection = new SqlConnection(_stringConnection))
            {
                connection.Open();
                var result = await connection.QueryAsync<Cliente>(sql, new { Id = id });
                return result.FirstOrDefault();
            }
        }
    }
}
