using Microsoft.AspNetCore.Mvc;
using LMSProject.Models;
using LMSProject;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using LMSProject.Data;



namespace LMSProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(LMSDbContext context) : ControllerBase
    {
        private readonly LMSDbContext _context = context;

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            return _context.Users.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

        [HttpPost]
        public ActionResult<User> PostUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return CreatedAtAction("GetUser", new { id = user.UserID }, user);
        }

        [HttpPut("{id}")]
        public IActionResult PutUser(int id, User user)
        {
            if (id != user.UserID)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
