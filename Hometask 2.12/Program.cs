// Hometask 2.12


// 1. Create queries using:
//        - Group (by multiple fields) ✅
//        - GroupJoin ✅                            *не поддерживается в EF Core
//        - Aggregation ✅
//        - Having ✅
// 2. Create subqueries with:
//        - In
//        - Exists
//        - Any
//        - All
// 3. Create queries with projection conditionals
// 4. Write extension methods that does paginating for me


using Hometask_2._7.Entities;
using System;

namespace Hometask_2._7
{
    class Program
    {
        public static void Main(string[] args)
        {
            Queries();
        }

        public static void Queries()
        {
            var context = new ScheduleDbContext();

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




            var all = context.Schedules.ToList();
            Console.WriteLine();
                                    
        }
    }
}

