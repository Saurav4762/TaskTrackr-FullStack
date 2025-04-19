using Microsoft.AspNetCore.Mvc;
using TaskTrackr.Entities;
using TaskTrackr.Data;
using TaskTrackr.Contratcs;
using TaskTrackr.Contratcs.Request;
using TaskTrackr.Services;
using TaskTrackr.Repository;
using TaskTrackr.Repository.Interface;
using TaskTrackr.Services.Interface;


namespace TaskTrackr.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly IStudentService _studentService;
    
    private readonly IStudentRepository _studentRepository;

    public StudentController(IStudentService studentService, IStudentRepository studentRepository)
    {
        _studentService = studentService;
        _studentRepository = studentRepository;
    }
    
    //post
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] StudentRequestDto dto)
    {
        try
        {
            var student = await _studentService.AddStudentAsync(dto);
            return Ok("Added student successfully");

        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
            
        }
    }
    
    //PUT :api/student/{id}
    [HttpPut("/{id}")]
    public async Task<IActionResult> Update(int id, StudentRequestDto dto)
    {
        try
        {
            var student = await _studentService.UpdateStudentAsync(id, dto);
            return Ok("Student updated successfully");

        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
            
        }
    }
    
    //Delete
    [HttpDelete("/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _studentService.DeleteStudentAsync(id);
            return Ok("Student deleted successfully");

        }
        catch (Exception e)
        {
          return BadRequest(e.Message);
        }
    }
    
}