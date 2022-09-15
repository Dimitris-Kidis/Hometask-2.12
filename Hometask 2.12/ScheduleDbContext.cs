using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Hometask_2._7.Entities;
using System.Security.Claims;
using System.Configuration;
using Hometask_2._12.EntitiesConfiguration;

namespace Hometask_2._7
{
    public class ScheduleDbContext : DbContext
    {
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Client> Clients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Data Source=.;Database=TestDb;Integrated Security=True");

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            

            builder.ApplyConfiguration<Client>(new ClientConfiguration());
            builder.ApplyConfiguration<Schedule>(new ScheduleConfiguration());


        }
    }
}

