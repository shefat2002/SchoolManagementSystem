using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.MVC.Data;

namespace SchoolManagementSystem.MVC.Controllers;

[Authorize]
public class EnrollmentsController : Controller
{
    private readonly SchoolDbContext _context;

    public EnrollmentsController(SchoolDbContext context)
    {
        _context = context;
    }

    // GET: Enrollments
    public async Task<IActionResult> Index()
    {
        var schoolDbContext = _context.Enrollments.Include(e => e.Class).Include(e => e.Student);
        return View(await schoolDbContext.ToListAsync());
    }

    // GET: Enrollments/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var enrollment = await _context.Enrollments
            .Include(e => e.Class)
            .Include(e => e.Student)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (enrollment == null)
        {
            return NotFound();
        }

        return View(enrollment);
    }

    // GET: Enrollments/Create
    public IActionResult Create()
    {
        ViewData["ClassId"] = new SelectList(_context.Classes, "Id", "Id");
        ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Id");
        return View();
    }

    // POST: Enrollments/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,StudentId,ClassId,Cgpa,Grade")] Enrollment enrollment)
    {
        if (ModelState.IsValid)
        {
            _context.Add(enrollment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["ClassId"] = new SelectList(_context.Classes, "Id", "Id", enrollment.ClassId);
        ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Id", enrollment.StudentId);
        return View(enrollment);
    }

    // GET: Enrollments/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var enrollment = await _context.Enrollments.FindAsync(id);
        if (enrollment == null)
        {
            return NotFound();
        }
        ViewData["ClassId"] = new SelectList(_context.Classes, "Id", "Id", enrollment.ClassId);
        ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Id", enrollment.StudentId);
        return View(enrollment);
    }

    // POST: Enrollments/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,StudentId,ClassId,Cgpa,Grade")] Enrollment enrollment)
    {
        if (id != enrollment.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(enrollment);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnrollmentExists(enrollment.Id))
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
        ViewData["ClassId"] = new SelectList(_context.Classes, "Id", "Id", enrollment.ClassId);
        ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Id", enrollment.StudentId);
        return View(enrollment);
    }

    // GET: Enrollments/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var enrollment = await _context.Enrollments
            .Include(e => e.Class)
            .Include(e => e.Student)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (enrollment == null)
        {
            return NotFound();
        }

        return View(enrollment);
    }

    // POST: Enrollments/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var enrollment = await _context.Enrollments.FindAsync(id);
        if (enrollment != null)
        {
            _context.Enrollments.Remove(enrollment);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool EnrollmentExists(int id)
    {
        return _context.Enrollments.Any(e => e.Id == id);
    }
}
