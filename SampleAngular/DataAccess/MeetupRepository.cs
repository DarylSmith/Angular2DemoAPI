using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleAngular.Entities;
using SampleAngular.Models;
using Microsoft.EntityFrameworkCore;

namespace SampleAngular
{


    public class MeetupRepository
    {
        private MeetupInfoContext _ctx;

        public MeetupRepository _repository;

      

        public MeetupRepository(MeetupInfoContext ctx)
        {
            _ctx = ctx;
        }

        #region Events
        public IEnumerable<MeetupEvent> GetMeetupEvents()
        {
            IEnumerable<MeetupEvent> events = _ctx.MeetupEvents;
            foreach(MeetupEvent e in events)
            {
                e.EventTime = e.EventDate.ToString("yyyy-MM-dd");

            }
            return events;
        }

        public bool AddMeetupEvent(MeetupEvent e)
        {
            _ctx.MeetupEvents.Add(e);
            return SaveChanges();
        }

        public bool UpdateMeetupEvent(MeetupEvent e)
        {
            var obj = _ctx.MeetupEvents.Single(y => y.Id == e.Id);

        if(obj==null)
           return false;

            obj.EventDate = e.EventDate;
            obj.EventDescription = e.EventDescription;
            obj.EventName = e.EventName;
            obj.SpeakerId = e.SpeakerId;
            return SaveChanges();
        }

        public bool DeleteMeetupEvent(int eventID)
        {
            MeetupEvent meetupEvent = _ctx.MeetupEvents.Find(eventID);
            if (meetupEvent == null)
                return false;

            _ctx.MeetupEvents.Remove(meetupEvent);
            return SaveChanges();
        }


        #endregion

  
        #region Events
        public IEnumerable<MeetupSpeaker> GetMeetupSpeakers()
        {
            return _ctx.MeetupSpeakers;
        }

        public bool AddMeetupSpeaker(MeetupSpeaker s)
        {
            _ctx.MeetupSpeakers.Add(s);
            return SaveChanges();
        }

        public bool UpdateMeetupSpeaker(MeetupSpeaker s)
        {
            var obj = _ctx.MeetupSpeakers.Single(e => e.Id == s.Id);

            if (obj == null)
                return false;

            obj.FirstName = s.FirstName;
            obj.LastName = s.LastName;

            return SaveChanges();
        }

        public bool DeleteMeetupSpeaker(int speakerID)
        {
            MeetupEvent meetupSpeaker = _ctx.MeetupEvents.Find(speakerID);
            if (meetupSpeaker == null)
                return false;

            _ctx.MeetupEvents.Remove(meetupSpeaker);
            return SaveChanges();
        }




        #endregion

        #region Private
        private bool SaveChanges()
        {
            int changes = _ctx.SaveChanges();
            return changes > 0;
        }
        #endregion
    }
}
