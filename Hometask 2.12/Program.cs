﻿// Hometask 2.12


// 1. Create queries using:
//        - Group (by multiple fields) ✅
//        - GroupJoin ✅                            *не поддерживается в EF Core
//        - Aggregation ✅
//        - Having ✅
// 2. Create subqueries with:
//        - In ✅
//        - Exists ✅
//        - Any ✅
//        - All ✅
// 3. Create queries with projection conditionals ✅
// 4. Write extension methods that does paginating for me


using Hometask_2._7.Entities;
using System;

namespace Hometask_2._7
{
    class Program
    {
        public static void Main(string[] args)
        {
            //Queries();
            //SubQueries();
            //ProjectionConditionals();
        }

        public static void Queries()
        {
            using var context = new ScheduleDbContext();

            var groupByQuery = context
                                    .Schedules
                                    .Where(x => x.Price > 20)
                                    .GroupBy(x => new
                                    {
                                        x.Time,
                                        x.Date
                                    })
                                    .Select(x => new
                                    {
                                        Time = x.Key.Time,
                                        Date = x.Key.Date,
                                        TimeCount = x.Count()
                                    })
                                    .Where(x => x.Date == "09/07/2022")
                                    .OrderByDescending(x => x.TimeCount)
                                    .Take(1);


            var groupByQuery2 = from schedules in context.Schedules.ToList()
                           where schedules.Price > 20
                           group schedules by new { schedules.Time, schedules.Date } into td
                           select new { Time = td.Key.Time, Date = td.Key.Date, Count = td.Count()};

            var groupJoinQuery = context.Clients
                                            .GroupBy(x => x.Gender)
                                            .Select(x => new
                                            {
                                                AvgAge = x.Average(client => client.Age),
                                                Gender = x.Key
                                            })
                                            .OrderBy(x => x.AvgAge);
        }

        public static void SubQueries()
        {
            using var context = new ScheduleDbContext();


            var inQuery = context.Clients
                            .Where(x => new[]{"Jorja Smith", "Elvis Presley", "Liza Gilbrait"}.Contains(x.FullName))
                            .Select(x => new { x.Id, x.FullName, x.Gender, x.Age });

            var anyQuery = context.Clients
                                .Where(x => x.Schedules.Any(y => y.Price > 70) && x.Age > 30).OrderBy(x => x.Age);

            var allQuery = context.Schedules
                                .All(x => x.Topic != null);

            var existsQuery = context.Clients
                                .Any(x => x.FullName == "Jorja Smith");

        }

        public static void ProjectionConditionals()
        {
            using var context = new ScheduleDbContext();

            var conditionals = context.Clients
                                        .Select(x => new
                                        {
                                            Name = x.FullName,
                                            Age = (x.Age > 20 && x.Age < 30) ? "In Their Thirties" :
                                            ((x.Age > 30 && x.Age < 40) ? "In Their Fourties" :
                                            (x.Age > 40) ? "In Their Fifties" : "Others")
                                        });
        }
    }
}

