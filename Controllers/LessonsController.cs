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
    public class LessonsController(LMSDbContext context) : ControllerBase
    {
        private readonly LMSDbContext _context = context;

        /// <summary>
        /// Get all lessons.
        /// </summary>
        /// <returns>A list of lessons.</returns>
        [HttpGet]
        public ActionResult<IEnumerable<Lesson>> GetLessons()
        {
            return _context.Lessons.ToList();
        }

        /// <summary>
        /// Get a lesson by ID.
        /// </summary>
        /// <param name="id">The ID of the lesson.</param>
        /// <returns>The lesson details.</returns>
        [HttpGet("{id}")]
        public ActionResult<Lesson> GetLesson(int id)
        {
            var lesson = _context.Lessons.Find(id);

            if (lesson == null)
            {
                return NotFound();
            }

            return lesson;
        }

        /// <summary>
        /// Create a new lesson.
        /// </summary>
        /// <param name="lesson">The lesson details.</param>
        [HttpPost]
        public ActionResult<Lesson> PostLesson(Lesson lesson)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Lessons.Add(lesson);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetLesson), new { id = lesson.LessonID }, lesson);
        }

        /// <summary>
        /// Update an existing lesson.
        /// </summary>
        /// <param name="id">The ID of the lesson.</param>
        /// <param name="lesson">The updated lesson details.</param>
        [HttpPut("{id}")]
        public IActionResult PutLesson(int id, Lesson lesson)
        {
            if (id != lesson.LessonID)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Entry(lesson).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        /// <summary>
        /// Delete a lesson by ID.
        /// </summary>
        /// <param name="id">The ID of the lesson.</param>
        [HttpDelete("{id}")]
        public IActionResult DeleteLesson(int id)
        {
            var lesson = _context.Lessons.Find(id);
            if (lesson == null)
            {
                return NotFound();
            }

            _context.Lessons.Remove(lesson);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
