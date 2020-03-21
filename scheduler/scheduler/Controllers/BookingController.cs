using System;
using System.Collections.Generic;
using Ical.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Scheduler.Comands;

namespace Scheduler.Controllers
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

            var calendar =  Calendar.Load("https://outlook.office365.com/owa/calendar/ec3e5ad91a0146278873ba35b5299345@netsuite.com/973a9111b0bf4b0085c52052b2a9235c16147836611522241913/calendar.ics");

            _mediator.Send(bookingRequest);
        }
    }
}
