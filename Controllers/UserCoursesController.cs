using LMSProject;
using LMSProject.Data;
using LMSProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace LMSProject.Controllers
{
    public class UserCoursesController(LMSDbContext context) : Controller
    {
        private readonly LMSDbContext _context = context;

        // GET: UserCourses
        public async Task<IActionResult> Index()
        {
            var userCourses = _context.UserCourses.Include(uc => uc.User).Include(uc => uc.Course);
            return View(await userCourses.ToListAsync());
        }

        // GET: UserCourses/Details/5
        public async Task<IActionResult> Details(int? userId, int? courseId)
        {
            if (userId == null || courseId == null)
            {
                return NotFound();
            }

            var userCourse = await _context.UserCourses
                .Include(uc => uc.User)
                .Include(uc => uc.Course)
                .FirstOrDefaultAsync(m => m.UserID == userId && m.CourseID == courseId);
            if (userCourse == null)
            {
                return NotFound();
            }

            return View(userCourse);
        }

        // GET: UserCourses/Create
        public IActionResult Create()
        {
            ViewData["UserID"] = new SelectList(_context.Users, "UserID", "FullName");
            ViewData["CourseID"] = new SelectList(_context.Courses, "CourseID", "CourseName");
            return View();
        }

        // POST: UserCourses/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserID,CourseID")] UserCourse userCourse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userCourse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserID"] = new SelectList(_context.Users, "UserID", "FullName", userCourse.UserID);
            ViewData["CourseID"] = new SelectList(_context.Courses, "CourseID", "CourseName", userCourse.CourseID);
            return View(userCourse);
        }

        // GET: UserCourses/Edit/5
        public async Task<IActionResult> Edit(int? userId, int? courseId)
        {
            if (userId == null || courseId == null)
            {
                return NotFound();
            }

            var userCourse = await _context.UserCourses.FindAsync(userId, courseId);
            if (userCourse == null)
            {
                return NotFound();
            }
            ViewData["UserID"] = new SelectList(_context.Users, "UserID", "FullName", userCourse.UserID);
            ViewData["CourseID"] = new SelectList(_context.Courses, "CourseID", "CourseName", userCourse.CourseID);
            return View(userCourse);
        }

        // POST: UserCourses/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int userId, int courseId, [Bind("UserID,CourseID")] UserCourse userCourse)
        {
            if (userId != userCourse.UserID || courseId != userCourse.CourseID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userCourse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserCourseExists(userCourse.UserID, userCourse.CourseID))
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
            ViewData["UserID"] = new SelectList(_context.Users, "UserID", "FullName", userCourse.UserID);
            ViewData["CourseID"] = new SelectList(_context.Courses, "CourseID", "CourseName", userCourse.CourseID);
            return View(userCourse);
        }

        // GET: UserCourses/Delete/5
        public async Task<IActionResult> Delete(int? userId, int? courseId)
        {
            if (userId == null || courseId == null)
            {
                return NotFound();
            }

            var userCourse = await _context.UserCourses
                .Include(uc => uc.User)
                .Include(uc => uc.Course)
                .FirstOrDefaultAsync(m => m.UserID == userId && m.CourseID == courseId);
            if (userCourse == null)
            {
                return NotFound();
            }

            return View(userCourse);
        }

        // POST: UserCourses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int userId, int courseId)
        {
            var userCourse = await _context.UserCourses.FindAsync(userId, courseId);
            Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<UserCourse> entityEntry = _context.UserCourses.Remove(userCourse);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserCourseExists(int userId, int courseId)
        {
            return _context.UserCourses.Any(e => e.UserID == userId && e.CourseID == courseId);
        }
    }
}
