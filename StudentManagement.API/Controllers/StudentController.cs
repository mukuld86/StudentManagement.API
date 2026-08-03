using Microsoft.AspNetCore.Mvc;
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
    public IActionResult GetStudents()
    {
        var students = _studentService.GetStudents();
        return Ok(students);
    }
}
