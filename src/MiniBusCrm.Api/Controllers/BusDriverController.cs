using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MiniBusCrm.Domain.Contracts.Models;
using MiniBusCrm.Domain.Contracts.Services;

namespace MiniBusCrm.Api.Controllers
{
    public class BusDriverController : BaseController
    {
        private readonly IBusDriverService _busDriverService;

        public BusDriverController(IBusDriverService busDriverService)
        {
            _busDriverService = busDriverService;
        }

        [HttpPost]
        public async Task<ActionResult<BusDriverModel>> Create([FromBody]BusDriverModel model)
        {
            var result = await _busDriverService.Create(model);

            return Ok(result);
        }

        [HttpGet("id")]
        public async Task<IActionResult> Get(Guid id)
        {
            var model = await _busDriverService.Get(id);

            if (model == null) return BadRequest("Bus driver not found");

            return Ok(model);
        }

        [HttpGet]
        public ActionResult<List<BusDriverModel>> GetAll()
        {
            var collection = _busDriverService.GetAll();

            if (collection == null) return BadRequest("Bus driver not found");

            return Ok(collection);
        }

        [HttpPut]
        public async Task<IActionResult> Update(BusDriverModel model)
        {
            var result = await _busDriverService.Update(model);

            if (result == Guid.Empty) return BadRequest("Bus driver not updated");

            return Ok(result);
        }

        [HttpDelete("id")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _busDriverService.Delete(id);
            return Ok();
        }
    }
}
