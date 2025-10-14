using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TallinnaRakenduslikKolledz.Data;
using TallinnaRakenduslikKolledz.Models;

namespace TallinnaRakenduslikKolledz.Controllers
{
    public class InstructorsController : Controller
    {
        private readonly SchoolContext _context;
        public InstructorsController(SchoolContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(int? id, int? courseId)
        {
            var vm = new InstructorIndexData();
            vm.Instructors = await _context.Instructors
            .Include(i => i.OfficeAssignment)
            .Include(i => i.CourseAssignments)
            .ToListAsync();
            return View(vm);

        }
        [HttpGet]
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            var teacher = await _context.Instructors.FindAsync(id);
            return View(teacher);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var teacher = await _context.Instructors.FindAsync(id);
            return View(teacher);
        }
        [HttpPost, ActionName("Edit")]
        public async Task<IActionResult> EditConfirmed([Bind("Id, LastName,FirstName,Email,HireDate,HomeAddress,Age")] Instructor teacher)
        {
            if (ModelState.IsValid)
            {
                _context.Instructors.Update(teacher);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(teacher);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var instructor = new Instructor();
            instructor.CourseAssignments = new List<CourseAssignment>();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Instructor instructor, string selectedCourses)
        {
            if (selectedCourses != null)
            {
                instructor.CourseAssignments = new List<CourseAssignment>();
                foreach (var course in selectedCourses)
                {
                    var courseToAdd = new CourseAssignment
                    {
                        InstructorId = instructor.Id,
                        CourseID = course

                    };
                    instructor.CourseAssignments.Add(courseToAdd);
                }
            }
            ModelState.Remove("selectedCourses");
            if(ModelState.IsValid)
            {
                _context.Add(instructor);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");

            }
            //PopulateAssignedCourseData(instructor);
            return View(instructor);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if(id == null)
            {
                return NotFound();
            }
            var deletableInstructor = await _context.Instructors
                .FirstOrDefaultAsync(s => s.Id == id);
            if (deletableInstructor == null)
            {
                return NotFound();
            }
            return View(deletableInstructor);
        }
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Instructor deletableinstructor = await _context.Instructors
                .SingleAsync(i => i.Id == id);
            _context.Instructors.Remove(deletableinstructor);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private void PopulateAssignedCourseData(Instructor instructor)
        {
            var allcourses = _context.Courses;
            var instructorCourses = new HashSet<int>(instructor.CourseAssignments.Select(c => c.CourseID));
            var vm = new List<AssignedCourseData>();
            foreach (var course in allcourses)
            {
                vm.Add(new AssignedCourseData
                {
                    CourseID = course.CourseId,
                    Title = course.Title,
                    Assigned = instructorCourses.Contains(course.CourseId)

                });
            }
            ViewData["Courses"] = vm;

        }
    }
}
