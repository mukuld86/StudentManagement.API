using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace StudentManagement.API.Models;

[Index(nameof(RegistrationNumber), IsUnique = true)]
public class Student
{
    public int Id { get; set; }
    [Required]
    public int RegistrationNumber { get; set; }
    [Required]
    [StringLength(30)]
    public string Name { get; set; } = string.Empty;
    [Required]
    [StringLength(30)]
    public string Course { get; set; } = string.Empty;
    [Range(18, 60)]
    public int Age { get; set; }
    [Required]
    [StringLength(30)]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
}