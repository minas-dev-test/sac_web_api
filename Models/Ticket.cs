using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAC_WebAPI.Models
{
    public class Ticket
    {
        public Guid TicketId { get; set; }
        public string NomeDeUsuario { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Mensagem { get; set; }
        public bool Aberto { get; set; }
    }
}
