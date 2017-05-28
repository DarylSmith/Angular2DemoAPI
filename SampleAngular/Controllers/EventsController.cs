using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SampleAngular.Models;
using Microsoft.Extensions.Logging;
using SampleAngular.Entities;
using Microsoft.EntityFrameworkCore;


namespace SampleAngular.Controllers
{
    [Route("api/events")]
    public class EventsController:Controller
    {
        private ILogger<EventsController> _logger;

        public MeetupRepository _repository;

        public EventsController (ILogger<EventsController> logger, MeetupRepository repository)
        {
            _logger = logger;

            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetEvents()
        {
            _logger.LogInformation($"Found {MeetupEventData.Current.Events.Count} events");
            var events = _repository.GetMeetupEvents();
            return Ok(events);
        }

       [HttpPost]
        public  IActionResult CreateEvent ([FromBody]MeetupEvent e)
        {
            bool insertSucceeded = _repository.AddMeetupEvent(e);
           return Ok();
        }

        [HttpPut]
        public IActionResult UpdateEvent([FromBody]MeetupEvent e)
        {
            bool updateSucceeded = _repository.UpdateMeetupEvent(e);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteEvent(int id)
        {
            bool deleteSucceeded = _repository.DeleteMeetupEvent(id);
            return Ok();
        }
    }

}
