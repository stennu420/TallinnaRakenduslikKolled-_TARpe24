using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using TallinnaRakenduslikKolledz.Data;
using TallinnaRakenduslikKolledz.Models;

namespace TallinnaRakenduslikKolledz.Controllers
{
    public class CoursesController : Controller
    {
        private readonly SchoolContext _context;
        public CoursesController(SchoolContext context)
        {
            _context = context;
        }
       
        

        
        public IActionResult Index()
        {
            var courses = _context.Courses.Include(c => c.Department)
                .AsNoTracking();
            return View(courses);
        }
        [HttpGet]
        public IActionResult Create()
        {
            PopulateDepartmentsDropDownList();
            ViewData["viewtype"] = "Create";
            return View();
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Course course)
        {
            if (ModelState.IsValid)
            { 
            _context.Add(course);
            await _context.SaveChangesAsync();
            PopulateDepartmentsDropDownList(course.DepartmentID);
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult>Delete(int?id)
        {
            ViewBag.viewtype = "Delete";
            if(id==null || _context.Courses == null)
            {
                return NotFound();
            }
            var courses = await _context.Courses
                .Include(c => c.Department)
                .AsNoTracking()
                .FirstOrDefaultAsync(mbox => mbox.CourseId == id);
            if(courses == null)
            {
                return NotFound();
            }
            return View(courses);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            
            if(_context.Courses == null)
            {
                return NotFound();
            }
            var course = await _context.Courses.FindAsync(id);
            if(course != null)
            {
                _context.Courses.Remove(course);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        

        private void PopulateDepartmentsDropDownList(object selectedDepartment = null)
        {
           var departmentsQuery = from d in _context.Departments
                                  orderby d.Name
                                  select d;
            ViewBag.DepartmentID = new SelectList(departmentsQuery.AsNoTracking(), "DepartmentID", "Name", selectedDepartment);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewData["viewtype"] = "Edit";
            var course = await _context.Courses.FindAsync(id);
            return View("Create", course);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Title,Credits,Department,CourseId")] Course course)
        {
            if (ModelState.IsValid)
            {
                _context.Courses.Update(course);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewData["CourseID"] = new SelectList(_context.Courses, "id", "FullName", course.CourseId);
           
            return View("Create", course);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            ViewData["viewtype"] = "Details";
            var courses = await _context.Courses
                .Include(c => c.Department)
                .AsNoTracking()
                .FirstOrDefaultAsync(mbox => mbox.CourseId == id);
            return View("Delete", courses);
        }
    }
}
