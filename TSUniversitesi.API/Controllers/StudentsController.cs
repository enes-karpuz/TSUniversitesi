using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TSUniversitesi.API.Models;

namespace TSUniversitesi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly StudentDbContext _studentDbContext;

        public StudentsController(StudentDbContext studentDbContext)
        {
            _studentDbContext = studentDbContext;
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            return Ok(_studentDbContext.Students.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetStudentById(int id)
        {
            var student = _studentDbContext.Students.Find(id);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            _studentDbContext.Students.Add(student);
            _studentDbContext.SaveChanges();
            return Ok(student);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, Student student)
        {
            _studentDbContext.Students.Update(student);
            _studentDbContext.SaveChanges();
            return Ok(student);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var student = _studentDbContext.Students.Find(id);
            _studentDbContext.Students.Remove(student);
            _studentDbContext.SaveChanges();
            return Ok(student);
        }
    }
}
