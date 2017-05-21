using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAngular.Models
{
    public class MeetupEventData
    {
        public static MeetupEventData Current { get; } = new MeetupEventData();

        public List<MeetupEvent> Events { get; set; }

        public MeetupEventData()
        {
            Events = new List<MeetupEvent>
            {
                new MeetupEvent()
                {
                    Id=1,
                    EventName="googlename",
                    EventDescription="googledescription"
                },
                                new MeetupEvent()
                {
                    Id=2,
                    EventName="mslename",
                    EventDescription="msdescription"
                }



            };
        }
    }
}
