using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MiniBusCrm.Domain.Contracts.Models;
using MiniBusCrm.Domain.Contracts.Services;

namespace MiniBusCrm.Api.Controllers
{
    public class BusController : BaseController
    {
        private readonly IBusService _busService;

        public BusController(IBusService busService)
        {
            _busService = busService;
        }

        [HttpPost]
        public async Task<ActionResult<BusModel>> Create(BusModel model)
        {
            var result = await _busService.Create(model);

            return Ok(result);
        }

        [HttpGet("id")]
        public ActionResult<BusModel> Get(Guid id)
        {
            var model = _busService.Get(id);

            if (model == null) return BadRequest("Bus not found");

            return Ok(model);
        }

        [HttpGet]
        public ActionResult<List<BusModel>> GetAll()
        {
            var collection = _busService.GetAll();

            if (collection == null) return BadRequest("Buses not found");

            return Ok(collection);
        }

        [HttpPut]
        public async Task<IActionResult> Update(BusModel model)
        {
            var result = await _busService.Update(model);

            if (result == Guid.Empty) return BadRequest("Bus not updated");

            return Ok(result);
        }

        [HttpDelete("id")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _busService.Delete(id);
            return Ok();
        }
    }
}
