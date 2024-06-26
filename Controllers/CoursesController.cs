using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using LMSProject;
using LMSProject.Models;
using LMSProject.Data;



namespace LMSProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController(LMSDbContext context) : ControllerBase
    {
        private readonly LMSDbContext _context = context;

        /// <summary>
        /// Get all courses.
        /// </summary>
        /// <returns>A list of courses.</returns>
        [HttpGet]
        public ActionResult<IEnumerable<Course>> GetCourses()
        {
            return _context.Courses.ToList();
        }

        /// <summary>
        /// Get a course by ID.
        /// </summary>
        /// <param name="id">The ID of the course.</param>
        /// <returns>The course details.</returns>
        [HttpGet("{id}")]
        public ActionResult<Course> GetCourse(int id)
        {
            var course = _context.Courses.Find(id);

            if (course == null)
            {
                return NotFound();
            }

            return course;
        }

        /// <summary>
        /// Create a new course.
        /// </summary>
        /// <param name="course">The course details.</param>
        [HttpPost]
        public ActionResult<Course> PostCourse(Course course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Courses.Add(course);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetCourse), new { id = course.CourseID }, course);
        }

        /// <summary>
        /// Update an existing course.
        /// </summary>
        /// <param name="id">The ID of the course.</param>
        /// <param name="course">The updated course details.</param>
        [HttpPut("{id}")]
        public IActionResult PutCourse(int id, Course course)
        {
            if (id != course.CourseID)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Entry(course).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        /// <summary>
        /// Delete a course by ID.
        /// </summary>
        /// <param name="id">The ID of the course.</param>
        [HttpDelete("{id}")]
        public IActionResult DeleteCourse(int id)
        {
            var course = _context.Courses.Find(id);
            if (course == null)
            {
                return NotFound();
            }

            _context.Courses.Remove(course);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
