using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public async Task<ActionResult<List<Student>>> GetStudents()
    {
        var students = await _studentService.GetStudentsAsync();
        return Ok(students);
    }
    [HttpGet("{registrationNumber}")]
    [Authorize]
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
    [Authorize(Roles ="Admin")]
    public async Task<ActionResult<Student>> CreateStudent(Student student)
    {
        await _studentService.AddStudentAsync(student);
        return CreatedAtAction(
            nameof(GetStudents),
            new { registrationNumber = student.RegistrationNumber },
            student);
    }
    [HttpPut("{registrationNumber}")]
    [Authorize(Roles ="Admin,Teacher")]
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
    [HttpDelete("{registrationNumber}")]
    [Authorize(Roles ="Admin")]
    public async Task<IActionResult> DeleteStudent(int registrationNumber)
    {
        bool deleted = await _studentService.DeleteStudentAsync(registrationNumber);
        if (!deleted)
        {
            return NotFound("Student Not found!");
        }
        return Content("Student Deleted");
    }
}
