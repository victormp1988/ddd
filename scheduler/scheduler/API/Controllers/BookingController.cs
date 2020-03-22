using MediatR;
using Microsoft.AspNetCore.Mvc;
using Scheduler.API.Comands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Scheduler.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookingController : ControllerBase
    {
        private IMediator _mediator;

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public BookingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public IEnumerable<String> Get()
        {
            return Summaries;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]RequestBooking bookingRequest)
        {
            await _mediator.Send(bookingRequest);
            return Ok();
        }
    }
}