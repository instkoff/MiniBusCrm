using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MiniBusCrm.Domain.Contracts.Models;
using MiniBusCrm.Domain.Contracts.Services;

namespace MiniBusCrm.Api.Controllers
{
    public class PlaneController : BaseController
    {
        private readonly IPlaneService _planeService;

        public PlaneController(IPlaneService planeService)
        {
            _planeService = planeService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] PlaneModel plane)
        {
            var result = await _planeService.Create(plane);
            if (result == Guid.Empty) return BadRequest();

            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var ordersCollection = _planeService.GetAll();
            if (ordersCollection == null || !ordersCollection.Any())
                return BadRequest("Collection is empty");
            return Ok(ordersCollection);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(Guid id)
        {
            var order = await _planeService.Get(id);
            if (order == null)
                return NotFound("Plane was not found");
            return Ok(order);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrder([FromBody] PlaneModel plane)
        {
            var result = await _planeService.Update(plane);
            if (result == Guid.Empty)
                return BadRequest("Update failed");
            return Ok(result);
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> DeleteOrder(Guid id)
        {
            await _planeService.Delete(id);
            return Ok();
        }
    }
}