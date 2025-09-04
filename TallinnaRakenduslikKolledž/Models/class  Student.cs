using System.ComponentModel.DataAnnotations;

namespace TallinnaRakenduslikKolledž.Models
{
    public class class__Student
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
       public string LastName { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }

        /* Lisa kolm omandust õpilasele, */ 
        public string Course {  get; set; }
        public string Gender { get; set; }
        public int? Email {  get; set; }

    }
}
