namespace TallinnaRakenduslikKolledz.Models
{
    public class DelinquentsBase
    {
      public int DelinquentsID { get; set; }
        public string FirstName { get; set; }
      public string LastName { get; set; }
      public enum Violation
      {
         Smoking,Gooning,Sleeping,Drugs,Alcohol
      }
        public bool? isTeacherOrStudent { get; set; }

        public string ViolationDescription { get; set; }
    }
}
