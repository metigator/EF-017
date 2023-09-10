using C07.GlobalQueryFilter.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace C07.GlobalQueryFilter.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Office> Offices { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Participant> Particpants { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<CourseOverview> CourseOverviews { get; set; }

        public DbSet<SectionDetails> SectionWithDetails { get; set; }


        protected override void ConfigureConventions(ModelConfigurationBuilder builder)
        {
            base.ConfigureConventions(builder);
            builder.Properties<DateOnly>()
                .HaveConversion<Config.DateOnlyConverter>()
                .HaveColumnType("date");

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json")
                .Build();

            var connectionString = config.GetSection("constr").Value;

            optionsBuilder.UseSqlServer(connectionString)
                //.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information)
                ;

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // modelBuilder.ApplyConfiguration(new CourseConfiguration()); // not best practice

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            modelBuilder.HasDbFunction(
                       typeof(AppDbContext)
                      .GetMethod(nameof(GetSectionsExceedingParticipantCount), new[] { typeof(int) }));
        }


        [DbFunction("fn_InstructorAvailability", Schema = "dbo")]
        public static string GetInstructorAvailability(int instructorId
            , DateTime startDate
            , DateTime endDate
            , TimeSpan startTime
            , TimeSpan endTime)
        {
            // This doesn't need an implementation; EF core uses the function mapping
            throw new NotImplementedException();
        }

        public IQueryable<Section> GetSectionsExceedingParticipantCount(int participantThreshold)
            => FromExpression(() => GetSectionsExceedingParticipantCount(participantThreshold));
    }
}
