using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using SAC_WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAC_WebAPI.DataAccess
{
    public class DataAccess : IDataAccess
    {
        private readonly IConfiguration _configuration;
        private string _connectionString;

        public DataAccess(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration["ConnectionString"];
        }

        public async Task<bool> AbrirTicket(Ticket ticket)
        {
            using (MySqlConnection conexao = new MySqlConnection(_connectionString))
            {
                ticket.TicketId = Guid.NewGuid();
                var insert = @"INSERT INTO sac_web_api.ticket
	                            (ticket_id,nome,email,telefone,mensagem)
                            VALUES 
	                            (@TicketId,@NomeDeUsuario,@Email,@Telefone,@Mensagem);";
                var resultado = await conexao.ExecuteAsync(insert, ticket);
                return resultado == 1;
            }
        }

        public async Task<IEnumerable<Ticket>> GetTodosTickets()
        {
            using (MySqlConnection conexao = new MySqlConnection(_connectionString))
            {
                var query = @"SELECT 
                                ticket_id TicketId,
                                nome NomeDeUsuario,
                                email Email,
                                telefone Telefone,
                                mensagem Mensagem,
                                aberto Aberto
                            FROM
                                sac_web_api.ticket;";
                return await conexao.QueryAsync<Ticket>(query);
            }
        }

        public async Task<bool> FecharTicket(Guid id)
        {
            using (MySqlConnection conexao = new MySqlConnection(_connectionString))
            {
                var resultado = await conexao.ExecuteAsync("UPDATE sac_web_api.ticket SET aberto = '0' WHERE ticket_id = @id", new { id });
                return resultado == 1;
            }
        }
    }
}
