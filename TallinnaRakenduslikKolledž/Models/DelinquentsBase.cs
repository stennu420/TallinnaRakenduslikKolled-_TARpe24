namespace TallinnaRakenduslikKolledz.Models;
using System.ComponentModel.DataAnnotations;


public enum Violation
{
    Smoking, Gooning, Sleeping, Drugs, Alcohol
}

public class DelinquentsBase
{
        [Key]
        public int DelinquentsId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime EventDate { get; set; }
        public bool isStudent { get; set; }
        public string PunishmentType { get; set; }
        public int PunishmentLenght { get; set; }
        public string Description { get; set; }

}
    

