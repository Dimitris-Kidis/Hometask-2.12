using Hometask_2._7.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hometask_2._12.EntitiesConfiguration
{
    internal class ScheduleConfiguration : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            var scheduleList = new List<Schedule>() {
                    new Schedule { Id = 9, ClientId = 1, Topic = "Work Meeting", Price = 35, Time = "09:30", Date = "09/07/2022"},
                    new Schedule { Id = 10, ClientId = 1, Topic = "Talking", Price = 19, Time = "12:10", Date = "09/07/2022"},
                    new Schedule { Id = 11, ClientId = 1, Topic = "English Practice", Price = 45, Time = "16:00", Date = "09/07/2022"},
                    new Schedule { Id = 12, ClientId = 1, Topic = "Family Call", Price = 52, Time = "20:00", Date = "09/07/2022"},
                    new Schedule { Id = 13, ClientId = 2, Topic = "Rehearsal", Price = 56, Time = "09:30", Date = "10/01/2022"},
                    new Schedule { Id = 14, ClientId = 2, Topic = "Walking", Price = 17, Time = "12:10", Date = "09/07/2022"},
                    new Schedule { Id = 15, ClientId = 2, Topic = "Relax", Price = 73, Time = "21:00", Date = "01/01/2022"},
                    new Schedule { Id = 16, ClientId = 3, Topic = "Lecture Time", Price = 20, Time = "13:50", Date = "02/04/2022"},
                    new Schedule { Id = 17, ClientId = 3, Topic = "Vacation", Price = 36, Time = "09:30", Date = "09/07/2022"}
                };

            builder
                .HasOne<Client>(client => client.Client)
                .WithMany(schdule => schdule.Schedules)
                .HasForeignKey(schedule => schedule.ClientId);

            builder.HasData(scheduleList);
        }
    }
}
