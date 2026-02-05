
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TallinnaRakenduslikKolledz.Data;
using TallinnaRakenduslikKolledz.Models;

namespace TallinnaRakenduslikKolledz.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly SchoolContext _context;
        public DepartmentsController(SchoolContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var schoolContext = _context.Departments.Include(d => d.Adminstrator);
            return View(await schoolContext.ToListAsync());
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewData["viewtype"] = "Create";
            ViewData["InstructorID"] = new SelectList(_context.Instructors, "Id", "FullName");
            ViewData["CourseStatus"] = new SelectList(_context.Instructors, "id", "LastName","InstructorName");  
             return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Budget,StartDate,RowVersion,InstructorID,SteamAccountName,WaterStations,EndDate")]Department department)
        {
            if(ModelState.IsValid)
            {
                _context.Departments.Add(department);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewData["InstructorID"] = new SelectList(_context.Instructors, "id", "FullName", department.InstructorID);
           // ViewData["CourseStatus"] = new SelectList(_context.Instructors, "id", department.CurrentStatus.ToString(), department.StudentID);
           return View(department);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            ViewData["viewtype"] = "Delete";
            if(id == null)
            {
                return NotFound();
            }
            var department = await _context.Departments
                .Include(d => d.Adminstrator)
                .FirstOrDefaultAsync(d => d.DepartmentID == id);
            if(department == null)
            {
                return NotFound();
            }
            return View(department);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Department department)
        {
            if(await _context.Departments.AnyAsync(m => m.DepartmentID == department.DepartmentID))
            {
                _context.Departments.Remove(department);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            ViewData["viewtype"] = "Details";
            ViewData["Edit"] = new SelectList(_context.Departments, "id", "FullName");
            var department = await _context.Departments
                            .Include(d => d.Adminstrator)
                            .FirstOrDefaultAsync(d => d.DepartmentID == id);
            return View("Delete", department);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewData["viewtype"] = "Edit";
            var department = await _context.Departments.FindAsync(id);
            return View("Create", department);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("DepartmentID,Name,Budget,StartDate,RowVersion,InstructorID,SteamAccountName,WaterStations,EndDate")]Department department)
        {
            if(ModelState.IsValid)
            {
                _context.Departments.Update(department);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewData["InstructorID"] = new SelectList(_context.Instructors, "id", "FullName", department.InstructorID);
           // ViewData["CourseStatus"] = new SelectList(_context.Instructors, "id", department.CurrentStatus.ToString(), department.StudentID);
           return View("Create",department);
        }
        //[HttpPost, ActionName("Edit")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> EditConfirmed([Bind("DepartmentID,Name,InstructorID,Budget,StartDate,Adminstrator,EndDate,WaterStations,SteamAccountName,RowVersion")] Department department)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Departments.Update(department);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }
        //    return View(department);
        //}

    }
}
