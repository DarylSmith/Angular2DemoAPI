using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using SampleAngular.Entities;

namespace SampleAngular.Migrations
{
    [DbContext(typeof(MeetupInfoContext))]
    partial class MeetupInfoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SampleAngular.Models.MeetupEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EventDate");

                    b.Property<string>("EventDescription")
                        .HasMaxLength(1000);

                    b.Property<string>("EventName")
                        .HasMaxLength(255);

                    b.Property<int>("SpeakerId");

                    b.HasKey("Id");

                    b.HasIndex("SpeakerId");

                    b.ToTable("MeetupEvents");
                });

            modelBuilder.Entity("SampleAngular.Models.MeetupSpeaker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName")
                        .HasMaxLength(255);

                    b.Property<string>("LastName")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("MeetupSpeakers");
                });

            modelBuilder.Entity("SampleAngular.Models.MeetupEvent", b =>
                {
                    b.HasOne("SampleAngular.Models.MeetupSpeaker", "Speaker")
                        .WithMany()
                        .HasForeignKey("SpeakerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
