using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAngular.Models
{
    public class MeetupEvent
    {
        public string EventName { get; set; }

        public string EventDescription { get; set; }

        public int EventDate { get; set ; }

        [ForeignKey("SpeakerId")]
        public MeetupSpeaker Speaker { get;set;}

        public int SpeakerId { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}
