using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SAC_WebAPI.DataAccess;
using SAC_WebAPI.Models;

namespace SAC_WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class SACController : Controller
    {
        private readonly IDataAccess _dataAccess;

        public SACController(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        [HttpPost]
        public async Task<IActionResult> AbrirTicket(string nomeDoUsuario, string email, string telefone, string mensagem)
        {
            try
            {
                Ticket ticket = new Ticket
                {
                    NomeDeUsuario = nomeDoUsuario,
                    Email = email,
                    Telefone = telefone,
                    Mensagem = mensagem
                };
                return Ok(await _dataAccess.AbrirTicket(ticket));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetTodosTickets()
        {
            try
            {
                return Ok(await _dataAccess.GetTodosTickets());
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut]
        public async Task<IActionResult> FecharTicket(Guid id)
        {
            try
            {
                return Ok(await _dataAccess.FecharTicket(id));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
