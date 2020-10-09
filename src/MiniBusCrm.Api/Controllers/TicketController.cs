using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MiniBusCrm.Domain.Contracts.Models;
using MiniBusCrm.Domain.Implementations.Services;

namespace MiniBusCrm.Api.Controllers
{
    public class TicketController : BaseController
    {
        private readonly ITicketService _ticketService;

        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpPost]
        public async Task<ActionResult<TicketModel>> Create(TicketModel model)
        {
            var result = await _ticketService.Create(model);

            return Ok(result);
        }

        [HttpGet("id")]
        public ActionResult<TicketModel> Get(Guid id)
        {
            var model = _ticketService.Get(id);

            if (model == null) return BadRequest("Ticket not found");

            return Ok(model);
        }

        [HttpGet]
        public ActionResult<List<TicketModel>> GetAll()
        {
            var collection = _ticketService.GetAll();

            if (collection == null) return BadRequest("Tickets not found");

            return Ok(collection);
        }

        [HttpPut]
        public async Task<IActionResult> Update(TicketModel model)
        {
            var result = await _ticketService.Update(model);

            if (result == Guid.Empty) return BadRequest("Ticket not updated");

            return Ok(result);
        }

        [HttpDelete("id")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _ticketService.Delete(id);
            return Ok();
        }
    }
}