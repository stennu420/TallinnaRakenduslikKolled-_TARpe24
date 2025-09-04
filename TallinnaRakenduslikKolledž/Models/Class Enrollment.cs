namespace TallinnaRakenduslikKolledž.Models
{
    public enum Grade
    {
        A,B,C,D,F,X,MA
      
    }
    public class Class_Enrollment
    {
        public int EnrollmentId { get; set; }
        public string? Email {  get; set; }

        public int StudentID { get; set; }
        public Grade? CurrentGrade { get; set; }

        public Course Course { get; set; }
        public class__Student Student {  get; set; }
    }
}
