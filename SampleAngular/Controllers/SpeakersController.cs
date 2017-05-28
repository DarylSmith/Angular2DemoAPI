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
    [Route("api/speakers")]
    public class SpeakersController : Controller
    {
        private ILogger<EventsController> _logger;
        public MeetupRepository _repository;

        public SpeakersController(ILogger<EventsController> logger, MeetupRepository repository)
        {
            _logger = logger;

            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetSpeakers()
        {
            var speakers = _repository.GetMeetupSpeakers();
            return Ok(speakers);
        }

        [HttpPost]
        public IActionResult CreateSpeaker([FromBody]MeetupSpeaker s)
        {
            bool insertSucceeded = _repository.AddMeetupSpeaker(s);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateSpeaker([FromBody]MeetupSpeaker s)
        {
            bool updateSucceeded = _repository.UpdateMeetupSpeaker(s);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteSpeaker(int id)
        {
            bool deleteSucceeded = _repository.DeleteMeetupSpeaker(id);
            return Ok();
        }
    }

}
