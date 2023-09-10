using C03.CallingStoredProcedure.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace C03.CallingStoredProcedure
{
    class Program
    {
        public static void Main(string[] args)
        {
            using (var context = new AppDbContext())
            {
                var startDateParam = new SqlParameter("@StartDate", System.Data.SqlDbType.Date)
                {
                    Value = new DateTime(2023, 01, 01)
                };
                var endDateParam = new SqlParameter("@EndDate", System.Data.SqlDbType.Date)
                {
                    Value = new DateTime(2023, 06, 30)
                };

                var sections = context.SectionWithDetails
                    .FromSql($"Exec dbo.sp_GetSectionWithninDateRange {startDateParam}, {endDateParam}")
                    .ToList();


                foreach (var s in sections)
                {
                    Console.WriteLine(s);
                }
            }
            Console.ReadKey();
        }
    }
}