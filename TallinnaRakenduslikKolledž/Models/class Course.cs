namespace TallinnaRakenduslikKolledž.Models
{
    public class class_Course
    {
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public int Credits { get; set; }

        public ICollection<Class_Enrollment> Enrollmets {  get; set; }

    }
}
