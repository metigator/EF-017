namespace C03.CallingStoredProcedure.Entities
{
    public class SectionDetails
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public int TotalHours { get; set; }
        public string SectionName { get; set; }
        public string Instructor { get; set; }
        public string Period { get; set; }
        public string Timeslot { get; set; }
        public bool SUN { get; set; }
        public bool MON { get; set; }
        public bool TUE { get; set; }
        public bool WED { get; set; }
        public bool THU { get; set; }
        public bool FRI { get; set; }
        public bool SAT { get; set; }
        public int HoursPerWeek { get; set; }

        public override string ToString()
        {
            return $"{Id,5} {CourseName,-34} {Instructor,-22} {Timeslot,-24} " +
                   $"{string.Join(" ",
                       SUN ? "SUN" : "   ",
                       MON ? "MON" : "   ",
                       TUE ? "TUE" : "   ",
                       WED ? "WED" : "   ",
                       THU ? "THU" : "   ",
                       FRI ? "FRI" : "   ",
                       SAT ? "SAT" : "   "),-37}  ({HoursPerWeek}) hrs/week";
        }
    }
}
