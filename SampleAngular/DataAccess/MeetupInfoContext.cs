using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SampleAngular.Models;

namespace SampleAngular.Entities
{
    public class MeetupInfoContext : DbContext
    {
        public MeetupInfoContext(DbContextOptions<MeetupInfoContext> options):base(options)
        {
            Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"Data Source=DESKTOP-593T1Q7\SQLEXPRESS;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;Database=MeetupEventsDB");
            base.OnConfiguring(builder);
        }


        public DbSet<MeetupEvent> MeetupEvents { get; set; }

        public DbSet<MeetupSpeaker> MeetupSpeakers { get; set; }
    }
}
