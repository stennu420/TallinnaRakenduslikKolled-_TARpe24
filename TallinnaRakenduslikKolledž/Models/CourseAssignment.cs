using System.ComponentModel.DataAnnotations;

namespace TallinnaRakenduslikKolledz.Models
{
    public class CourseAssignment
    {
        [Key]
        public int Id { get; set; }
        public int InstructorId { get; set; }
        public int CourseID { get; set; }
        public Instructor instructor {  get; set; }
        public Course Course { get; set; }
    }
}
