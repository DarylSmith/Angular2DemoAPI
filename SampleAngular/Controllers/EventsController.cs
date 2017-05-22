using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SampleAngular.Models;
using Microsoft.Extensions.Logging;
using SampleAngular.Entities;
using Microsoft.EntityFrameworkCore;
using 


namespace SampleAngular.Controllers
{
    [Route("api/[controller]")]
    public class EventsController:Controller
    {
        private ILogger<EventsController> _logger;

        public MeetupRepository _repository;

        public EventsController (ILogger<EventsController> logger, MeetupRepository _repository)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetEvents()
        {
            _logger.LogInformation($"Found {MeetupEventData.Current.Events.Count} events");
            return Ok()
        }

        //[HttpPost("api/[controller]")]
        //public  IActionResult CreateEvent (MeetupEvent e)
        //{


        //}
    }
}
