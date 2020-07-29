using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MiniBusCrm.Domain.Contracts.Models;
using MiniBusCrm.Domain.Contracts.Services;

namespace MiniBusCrm.Api.Controllers
{
    public class PassengerController : BaseController
    {
        private readonly IPassengerService _passengerService;

        public PassengerController(IPassengerService passengerService)
        {
            _passengerService = passengerService;
        }
        [HttpGet]
        public ActionResult<List<PassengerModel>> GetAll()
        {
            var result = _passengerService.GetAll();
            if (result == null) return BadRequest("Passengers not found");
            return result;
        }
    }
}
