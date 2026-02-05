
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
            ViewData["creation"] = true;
            ViewData["InstructorID"] = new SelectList(_context.Instructors, "Id", "FullName");
            /*ViewData["StudentId"] = new SelectList(_context.Students, "Id", "LastName", "FirstName");*/
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Budget,StartDate,RowVersion,InstructorId,Staplers,WastedHours")] Department department)
        {
            if (ModelState.IsValid)
            {
                _context.Add(department);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["InstructorID"] = new SelectList(_context.Instructors, "Id", "FullName", department.InstructorID);
            /*ViewData["CourseStatus"] = new SelectList(_context.Instructors,"Id",department.CurrentStatus.ToString)*/
            return View(department);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            ViewData["creation"] = false;
            if (id == null)
            {
                return NotFound();
            }
            var department = await _context.Departments.FirstOrDefaultAsync(d => d.DepartmentID == id);
            if (department == null)
            {
                return NotFound();
            }
            /*_context.Departments.Update(department);        */
            return View("Create", department);
        }
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditConfirmed([Bind("DepartmentID,Name,Budget,StartDate,RowVersion,InstructorId,Staplers,WastedHours")] Department department)
        {
            _context.Departments.Update(department);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            ViewData["deletion"] = true;
            if (id == null)
            {
                return NotFound();
            }
            var department = await _context.Departments.FirstOrDefaultAsync(d => d.DepartmentID == id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Department department)
        {
            if (await _context.Departments.AnyAsync(m => m.DepartmentID == department.DepartmentID))
            {
                _context.Departments.Remove(department);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            ViewData["deletion"] = false;
            if (id == null)
            {
                return NotFound();
            }
            var department = await _context.Departments.FirstOrDefaultAsync(d => d.DepartmentID == id);
            if (department == null)
            {
                return NotFound();
            }
            return View("Delete", department);
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
