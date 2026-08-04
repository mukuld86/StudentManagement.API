using Microsoft.AspNetCore.Mvc;
using StudentManagement.API.Models;
using StudentManagement.API.Services;

namespace StudentManagement.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentController : ControllerBase
{
    private readonly StudentService _studentService;
    public StudentController(StudentService studentService)
    {
        _studentService = studentService;
    }
    [HttpGet]
    public async Task<ActionResult<List<Student>>> GetStudents()
    {
        var students = await _studentService.GetStudentsAsync();
        return Ok(students);
    }
    [HttpGet("{registrationNumber}")]
    public async Task<ActionResult<Student>> GetStudent(int registrationNumber)
    {
        var student = await _studentService.GetStudentByRegistrationNumberAsync(registrationNumber);
        if (student == null)
        {
            return NotFound("No student found!");
        }
        return Ok(student);
    }
    [HttpPost]
    public IActionResult CreateStudent(Student student)
    {
        _studentService.AddStudent(student);
        return CreatedAtAction(
            nameof(GetStudents),
            new { registrationNumber = student.RegistrationNumber },
            student);
    }
    [HttpPut("{registrationNumber}")]
    public async Task<IActionResult> UpdateStudent(int registrationNumber, Student student)
    {
        if(registrationNumber != student.RegistrationNumber)
        {
            return BadRequest("Registration number mismatch");
        }
        bool updated = await _studentService.UpdateStudentAsync(student);
        if (!updated)
        {
            return NotFound("Student not found");
        }
        return NoContent();

    }
}
