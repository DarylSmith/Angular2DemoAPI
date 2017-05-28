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
            return _ctx.MeetupEvents;
        }

        public bool AddMeetupEvent(MeetupEvent e)
        {
            _ctx.MeetupEvents.Add(e);
            return SaveChanges();
        }

        public bool UpdateMeetupEvent(MeetupEvent e)
        {
            if (_ctx.MeetupEvents.Find(e.Id) == null)
                return false;

            _ctx.MeetupEvents.Attach(e);
            _ctx.Entry(e).State = EntityState.Modified;
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
            if (_ctx.MeetupEvents.Find(s.Id) == null)
                return false;

            _ctx.MeetupSpeakers.Attach(s);
            _ctx.Entry(s).State = EntityState.Modified;
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
