using SAC_WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SAC_WebAPI.DataAccess
{
    public interface IDataAccess
    {
        Task<bool> AbrirTicket(Ticket ticket);
        Task<IEnumerable<Ticket>> GetTodosTickets();
        Task<bool> FecharTicket(Guid id);
    }
}
