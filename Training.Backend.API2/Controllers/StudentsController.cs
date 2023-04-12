using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Training.Backend.Data.Database;
using Training.Backend.Data.Entities;

namespace Training.Backend.API2.Controllers;

[ApiController]
[Route("/api/students")]
public class StudentsController : ControllerBase
{
    private readonly ApplicationDbContext _dbContext;

    public StudentsController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpPost]
    public async Task<IActionResult> CreateStudent(Student student)
    {
        if (student.Name.Length < 5)
            return BadRequest("The name is too short!");

        var entry = await _dbContext.Students.AddAsync(student);
        await _dbContext.SaveChangesAsync();

        return Ok(entry.Entity);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetStudents()
    {
        var students = await _dbContext.Students.ToListAsync();

        return Ok(students);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetStudents(int id)
    {
        var student = await _dbContext.Students.FirstOrDefaultAsync(x => x.Id == id);

        return Ok(student);
    }
    
    [HttpPut]
    public async Task<IActionResult> EditStudent(Student student)
    {
        var studentEntity = await _dbContext.Students.FirstOrDefaultAsync(x => x.Id == student.Id);

        if (studentEntity is null)
            return BadRequest("Student is not valid!");

        studentEntity.Name = student.Name;
        studentEntity.Faculty = student.Faculty;
        
        await _dbContext.SaveChangesAsync();

        return Ok();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteStudent(int id)
    {
        var studentEntity = await _dbContext.Students.FirstOrDefaultAsync(x => x.Id == id);

        if (studentEntity is null)
            return BadRequest("Student is not valid!");

        _dbContext.Remove(studentEntity);

        await _dbContext.SaveChangesAsync();

        return Ok();
    }
}