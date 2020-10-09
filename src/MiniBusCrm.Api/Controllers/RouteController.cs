using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MiniBusCrm.Domain.Contracts.Models;
using MiniBusCrm.Domain.Contracts.Services;

namespace MiniBusCrm.Api.Controllers
{
    public class RouteController : BaseController
    {
        private readonly IRouteService _routeService;

        public RouteController(IRouteService routeService)
        {
            _routeService = routeService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RouteModel route)
        {
            var result = await _routeService.Create(route);
            if (result == Guid.Empty) return BadRequest("Route not created");

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] RouteModel model)
        {
            var result = await _routeService.Update(model);
            if (result == Guid.Empty)
                return BadRequest("Route not updated");
            return Ok(result);
        }

        [HttpGet("id")]
        public ActionResult<RouteModel> Get(Guid id)
        {
            var model = _routeService.Get(id);

            if (model == null) return BadRequest("Route not found");

            return Ok(model);
        }

        [HttpGet]
        public ActionResult<List<RouteModel>> GetAll()
        {
            var collection = _routeService.GetAll();

            if (collection == null) return BadRequest("Routes not found");

            return Ok(collection);
        }

        [HttpDelete("id")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _routeService.Delete(id);
            return Ok();
        }
    }
}