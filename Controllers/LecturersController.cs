using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.MVC.Data;

namespace SchoolManagementSystem.MVC.Controllers;

[Authorize]
public class LecturersController : Controller
{
    private readonly SchoolDbContext _context;

    public LecturersController(SchoolDbContext context)
    {
        _context = context;
    }

    // GET: Lecturers
    public async Task<IActionResult> Index()
    {
        return View(await _context.Lecturers.ToListAsync());
    }

    // GET: Lecturers/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var lecturer = await _context.Lecturers
            .FirstOrDefaultAsync(m => m.Id == id);
        if (lecturer == null)
        {
            return NotFound();
        }

        return View(lecturer);
    }

    // GET: Lecturers/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Lecturers/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,FirstName,LastName")] Lecturer lecturer)
    {
        if (ModelState.IsValid)
        {
            _context.Add(lecturer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(lecturer);
    }

    // GET: Lecturers/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var lecturer = await _context.Lecturers.FindAsync(id);
        if (lecturer == null)
        {
            return NotFound();
        }
        return View(lecturer);
    }

    // POST: Lecturers/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName")] Lecturer lecturer)
    {
        if (id != lecturer.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(lecturer);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LecturerExists(lecturer.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(lecturer);
    }

    // GET: Lecturers/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var lecturer = await _context.Lecturers
            .FirstOrDefaultAsync(m => m.Id == id);
        if (lecturer == null)
        {
            return NotFound();
        }

        return View(lecturer);
    }

    // POST: Lecturers/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var lecturer = await _context.Lecturers.FindAsync(id);
        if (lecturer != null)
        {
            _context.Lecturers.Remove(lecturer);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool LecturerExists(int id)
    {
        return _context.Lecturers.Any(e => e.Id == id);
    }
}
