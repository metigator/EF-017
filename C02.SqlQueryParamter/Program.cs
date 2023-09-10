using C02.SqlQueryParameter.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace C02.SqlQueryParameter
{
    class Program
    {
        public static void Main(string[] args)
        {
            using (var context = new AppDbContext())
            {
                // on DbSet.
                // primary key only to search.
                // (local cache) first. if not exist it queries the database.
                // Returns null if the entity is not found.

                //var c1 = context.Courses.Find(1);
                //Console.WriteLine($"{c1.CourseName} ({c1.HoursToComplete})");

                // On IEnumerable or IQueryable.
                // Retrieves the first element of a sequence, or a default value.
                // You can provide a predicate(a condition) to filter the results. 
                //var c2 = context.Courses.FirstOrDefault(x => x.Id == 1);
                //Console.WriteLine($"{c2.CourseName} ({c2.HoursToComplete})");

                // On IEnumerable or IQueryable.
                // Retrieves the single element of a sequence or a default value.
                // more than one element satisfies, exception thrown.
                // Useful when you expect the query to return only one result.

                //var c3 = context.Courses.SingleOrDefault(x => x.Id == 1);
                //Console.WriteLine($"{c3.CourseName} ({c3.HoursToComplete})");

                var c1 = context.Courses
                    .FromSql($"SELECT * FROM dbo.Courses Where Id = {1}")
                    .FirstOrDefault();
                Console.WriteLine($"{c1.CourseName} ({c1.HoursToComplete})");

                var c2 = context.Courses
                   .FromSqlInterpolated($"SELECT * FROM dbo.Courses Where Id = {1}")
                   .FirstOrDefault();

                Console.WriteLine($"{c2.CourseName} ({c2.HoursToComplete})");

                // var courseId = "1; DELETE FROM dbo.Courses";

                var courseIdParam = new SqlParameter("@courseId", 1);
                var c3 = context.Courses
                .FromSqlRaw("SELECT * FROM dbo.Courses Where Id = @courseId", courseIdParam)
                .FirstOrDefault();

                Console.WriteLine($"{c3.CourseName} ({c3.HoursToComplete})");
            }
            Console.ReadKey();
        }
    }
}