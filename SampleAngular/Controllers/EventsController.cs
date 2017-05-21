using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SampleAngular.Models;
using Microsoft.Extensions.Logging;

namespace SampleAngular.Controllers
{
    [Route("api/[controller]")]
    public class EventsController:Controller
    {
        private ILogger<EventsController> _logger;

        public EventsController (ILogger<EventsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public JsonResult GetEvents()
        {
            _logger.LogInformation($"Found {MeetupEventData.Current.Events.Count} events");
            return new JsonResult(MeetupEventData.Current.Events);
        }

        //[HttpPost("api/[controller]")]
        //public  IActionResult CreateEvent (MeetupEvent e)
        //{


        //}
    }
}
