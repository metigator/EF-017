using C01.SqlQuery.Data;
using Microsoft.EntityFrameworkCore;

namespace C01.SqlQuery
{
    class Program
    {
        public static void Main(string[] args)
        {
            using (var context = new AppDbContext())
            {
                // FromSql +ef 7.0
                // FromSqlInterpolated ef 3.0
                // FromSqlRaw ef 3.0

                var courses =
                    context.Courses.FromSql($"SELECT * FROM dbo.Courses");

                var coursesv2 =
                  context.Courses.FromSqlInterpolated($"SELECT * FROM dbo.Courses");

                var coursesv3 =
                 context.Courses.FromSqlRaw("SELECT * FROM dbo.Courses");

                foreach (var c in coursesv3)
                {
                    Console.WriteLine($"{c.CourseName} ({c.HoursToComplete})");
                }

            }
            Console.ReadKey();
        }
    }
}