using TallinnaRakenduslikKolledz.Models;

namespace TallinnaRakenduslikKolledz.Data
{
    public class Dbinitializer
    {
        public static void Initializer(SchoolContext context)
        {
            context.Database.EnsureCreated();
            if (context.Students.Any())
            {
                return;
            }

            var students = new Student[]
            {
                new Student {FirstName = "George",LastName = "Teemus",EnrollmentDate = DateTime.Now, },
                new Student {FirstName = "Among",LastName = "us",EnrollmentDate = DateTime.Now, },
                new Student {FirstName = "Must",LastName = "Washhands",EnrollmentDate = DateTime.Now, },
                new Student {FirstName = "Mao",LastName = "Zedong",EnrollmentDate = DateTime.Now, },
                new Student {FirstName = "Benito",LastName = "Mussolini",EnrollmentDate = DateTime.Now, },
                new Student {FirstName = "Antony",LastName = "Martial",EnrollmentDate = DateTime.Now, },
                new Student {FirstName = "Cristiano",LastName = "Ronaldo",EnrollmentDate = DateTime.Now, },
                new Student {FirstName = "Donald",LastName = "Trump",EnrollmentDate = DateTime.Now, },

            };
            context.Students.AddRange(students);
            context.SaveChanges();
            if (context.Courses.Any()) { return; }
            var courses = new Course[]
            {
                new Course {CourseId=1001, Title="Programeerimise Alused", Credits=3 },
                new Course {CourseId=2002, Title="Programeerimise 1", Credits=6 },
                new Course {CourseId=3003, Title="Programeerimise 3", Credits=9 },
                new Course {CourseId=1001, Title="Tarkvara Arendusprotsess", Credits=3 },
                new Course {CourseId=1001, Title="Multimeedia", Credits=3 },
                new Course {CourseId=9001, Title="Hajusrakenduste", Credits=3 },
            };
            context.Courses.AddRange(courses);
            context.SaveChanges();
            if(context.Enrollments.Any()) { return; }
            var enrollments = new Enrollment[]
            {
                new Enrollment{StudentID=1,CourseID=3003,CurrentGrade=Grade.X},
                new Enrollment{StudentID=1,CourseID=3001,CurrentGrade=Grade.B},
                new Enrollment{StudentID=2,CourseID=1001,CurrentGrade=Grade.A},
                new Enrollment{StudentID=2,CourseID=1002,CurrentGrade=Grade.MA},
                new Enrollment{StudentID=3,CourseID=1001,CurrentGrade=Grade.C},
                new Enrollment{StudentID=3,CourseID=2003,CurrentGrade=Grade.C},
                new Enrollment{StudentID=4,CourseID=3003,CurrentGrade=Grade.A},
                new Enrollment{StudentID=4,CourseID=2002,CurrentGrade=Grade.X},
                new Enrollment{StudentID=5,CourseID=3003,CurrentGrade=Grade.A},
                new Enrollment{StudentID=5,CourseID=9001,CurrentGrade=Grade.MA},
                new Enrollment{StudentID=6,CourseID=2002,CurrentGrade=Grade.X},
                new Enrollment{StudentID=6,CourseID=9001,CurrentGrade=Grade.C},
                new Enrollment{StudentID=7,CourseID=3003,CurrentGrade=Grade.A},
                new Enrollment{StudentID=7,CourseID=1001,CurrentGrade=Grade.X},
            };
            context.Enrollments.AddRange(enrollments);
            context.SaveChanges();
            if(context.Instructors.Any()) { return; }
            var instructor = new Instructor[]
            {
                new Instructor { FirstName="DONKEY", LastName="Dragon",HireDate=DateTime.Now, Email="ABC123"},
                new Instructor { FirstName = "Shrek", LastName = "Ö G E R", HireDate = DateTime.Now, Age = 50},
                new Instructor { FirstName = "George", LastName = "Dragon", HireDate = DateTime.Now, Email = "OBAMA" },
                
            };
            context.Instructors.AddRange(instructor);
            context.SaveChanges();

            
        }   
    }
}
