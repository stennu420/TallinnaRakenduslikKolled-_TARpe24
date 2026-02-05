using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using TallinnaRakenduslikKolledz.Data;
using TallinnaRakenduslikKolledz.Models;


namespace TallinnaRakenduslikKolledz.Controllers
{
    public class DelinquentsController : Controller
    {
        private readonly SchoolContext _context;

        public DelinquentsController(SchoolContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Delinquents.ToListAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Delinquent delinquent)
        {
            if (ModelState.IsValid)
            {

                _context.Delinquents.Add(delinquent);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var delinquent = await _context.Delinquents.FirstOrDefaultAsync(d => d.BreakId == Id);
            if (delinquent == null)
            {
                return NotFound();
            }
            return View(delinquent);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id)
        {
           if (id == null) 
           {
                return NotFound();
           }
           var delinquent = await _context.Delinquents.FirstOrDefaultAsync(d => d.BreakId == id);
            if ( (delinquent == null)
            {
                return NotFound();
            }
            _context.Delinquents.Update(delinquent);
            return View(delinquent);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditConfirmed([Bind("BreakerId, FirsName, LastName, Violations,Description,Position")] Delinquent delinquent)
        {
            _context.Delinquents.Update(delinquent);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var delinquent = await _context.Delinquents.FirstOrDefaultAsync(d => d.BreakerId == Id);
            if (delinquent == null)
            {
                return NotFound();
            }
            return View(delinquent);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Delinquent delinquent)
        {
            if (await _context.Delinquents.AnyAsync(d => d.BreakerId == delinquent.BreakerId))
            {
                _context.Delinquents.Remove(delinquent);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }
}
