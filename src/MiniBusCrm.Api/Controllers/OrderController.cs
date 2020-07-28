using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MiniBusCrm.Domain.Contracts.Models;
using MiniBusCrm.Domain.Contracts.Services;

namespace MiniBusCrm.Api.Controllers
{
    public class OrderController : BaseController
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("Create")]
        public async Task<ActionResult> Create([FromBody] OrderModel order)
        {
            var result = await _orderService.Create(order);
            if (result == Guid.Empty)
            {
                return BadRequest();
            }

            return Ok(result);
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            var ordersCollection = _orderService.GetAll();
            if (ordersCollection == null || !ordersCollection.Any())
                return BadRequest("Collection is empty");
            return Ok(ordersCollection);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetOrder(Guid id)
        {
            var order = await _orderService.Get(id);
            if (order == null)
                return NotFound("Order was not found");
            return Ok(order);
        }
        [HttpPut]
        public async Task<ActionResult> UpdateOrder([FromBody] OrderModel order)
        {
            var result = await _orderService.Update(order);
            if (result == Guid.Empty)
                return BadRequest("Update failed");
            return Ok(result);
        }
        [HttpPost("Delete")]
        public async Task<ActionResult> DeleteOrder(Guid id)
        {
            await _orderService.Delete(id);
            return Ok();
        }
    }
}
