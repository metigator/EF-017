using C07.GlobalQueryFilter.Data;

namespace C07.GlobalQueryFilter
{
    class Program
    {
        public static void Main(string[] args)
        {
            using (var context = new AppDbContext())
            {
                foreach (var section in context.GetSectionsExceedingParticipantCount(21))
                {
                    Console.WriteLine($"{section.Id}\t{section.SectionName}\t{section.DateRange}\t{section.TimeSlot}");
                }
            }

            Console.ReadKey();
        }
    }
}