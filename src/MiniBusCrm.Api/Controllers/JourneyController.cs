using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MiniBusCrm.Domain.Contracts.Models;
using MiniBusCrm.Domain.Contracts.Services;

namespace MiniBusCrm.Api.Controllers
{
    public class JourneyController : BaseController
    {
        private readonly IJourneyService _journeyService;

        public JourneyController(IJourneyService journeyService)
        {
            _journeyService = journeyService;
        }

        [HttpPost("Create")]
        public async Task<ActionResult> Create([FromBody] JourneyModel journey)
        {
            var result = await _journeyService.Create(journey);
            if (result == Guid.Empty) return BadRequest();

            return Ok(result);
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var ordersCollection = _journeyService.GetAll();
            if (ordersCollection == null || !ordersCollection.Any())
                return BadRequest("Collection is empty");
            return Ok(ordersCollection);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetOrder(Guid id)
        {
            var order = await _journeyService.Get(id);
            if (order == null)
                return NotFound("Journey was not found");
            return Ok(order);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateOrder([FromBody] JourneyModel journey)
        {
            var result = await _journeyService.Update(journey);
            if (result == Guid.Empty)
                return BadRequest("Update failed");
            return Ok(result);
        }

        [HttpPost("Delete")]
        public async Task<ActionResult> DeleteOrder(Guid id)
        {
            await _journeyService.Delete(id);
            return Ok();
        }
    }
}