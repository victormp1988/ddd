using System;
using System.Collections.Generic;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using scheduler.Comands;

namespace scheduler.Controllers
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
        public void Post([FromBody]RequestBooking bookingRequest)
        {
            _mediator.Send(bookingRequest);
        }
    }
}
