namespace C07.GlobalQueryFilter.Entities
{
    public class CourseOverview
    {
        public string CourseName { get; set; }
        public string SectionName { get; set; }
        public string InstructorFirstName { get; set; }
        public string InstructorLastName { get; set; }
        public string ScheduleType { get; set; }
        public string CourseDays { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int NumberOfEnrolledParticipants { get; set; }

        public override string ToString()
        {
            return $"{CourseName,-34} {SectionName,-20} {InstructorFirstName,-15} {InstructorLastName,-15} " +
                   $"{ScheduleType,-15} {CourseDays,-30} {StartTime}-{EndTime,-20} {StartDate.ToShortDateString()}-{EndDate.ToShortDateString(),-20} " +
                   $"{NumberOfEnrolledParticipants} participants";
        }

    }
}
