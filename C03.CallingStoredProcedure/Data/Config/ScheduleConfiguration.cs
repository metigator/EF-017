using C03.CallingStoredProcedure.Entities;
using C03.CallingStoredProcedure.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace C03.CallingStoredProcedure.Data.Config
{
    public class ScheduleConfiguration : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            // builder.Property(x => x.CourseName).HasMaxLength(255); // nvarchar(255)

            builder.Property(x => x.ScheduleType)
                .HasConversion(
                     x => x.ToString(),
                     x => (ScheduleType)Enum.Parse(typeof(ScheduleType), x)
                );

            builder.ToTable("Schedules");
        }
    }
}
