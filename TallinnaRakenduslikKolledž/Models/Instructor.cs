using System.ComponentModel.DataAnnotations;
using Microsoft.Identity.Client;

namespace TallinnaRakenduslikKolledz.Models
{
    public class Instructor
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Perekonnanimi")]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Eesnimi")]
        public string FirstName
        {
            get; set;

        }
        [Display(Name = "Õpetaja nimi")]
        public string FullName
        {
            get { return LastName + ", " + FirstName; }

        }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name ="Tööleasumiskuupäev")]
        public DateTime HireDate { get; set; }

        public ICollection<CourseAssignment>? CourseAssignments { get; set; }
        public OfficeAssignment? OfficeAssignment { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Email")]
        public string? Email
        {
            get; set;

        }

        [Required]
        
        [Display(Name = "Age")]
        public int? Age
        {
            get; set;

        }

        [Required]
        [StringLength(50)]
        [Display(Name = "HomeAddress")]
        public string? HomeAddress
        {
            get; set;

        }
    }


}  
