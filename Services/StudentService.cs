using Microsoft.EntityFrameworkCore;
using TaskTrackr.Contratcs.Request;
using TaskTrackr.Data;
using TaskTrackr.Entities;
using TaskTrackr.Services.Interface;

namespace TaskTrackr.Services;

public class StudentService: IStudentService
{
    private readonly EfCoreDbContext _dbcontext;

    public StudentService(EfCoreDbContext dbcontext)
    {
        _dbcontext = dbcontext;
    }

    public async Task<Student> AddStudentAsync(StudentRequestDto dto)
    {
        var studentExists = await _dbcontext.Students.AnyAsync(s => s.Id == dto.AssignmentId);
        //validate studentId
        if (!studentExists)
        {
            throw new Exception("Student not found");
        }

        var student = new Student()
        {
            Id = dto.AssignmentId,
            FullName = dto.FullName,
            Email = dto.Email,
            AssignmentId = dto.AssignmentId,
        };
        
        _dbcontext.Students.Add(student);
        await _dbcontext.SaveChangesAsync();
        
        return student;

    }

    public async Task<Student> UpdateStudentAsync(int id, StudentRequestDto dto)
    {
        var student = await _dbcontext.Students.FindAsync(id);

        if (student == null)
        {
            throw new Exception("Assignment not found");
        }

        student.FullName = dto.FullName;
        student.Email = dto.Email;
        student.AssignmentId = dto.AssignmentId;
        student.Id = dto.AssignmentId;
        
        _dbcontext.Update(student);
        await _dbcontext.SaveChangesAsync();
        
        return student;
        
    }

    public async Task DeleteStudentAsync(int id)
    {
       var student = await _dbcontext.Students.FindAsync(id);
       //validate StudentId
       if (student == null)
       {
           throw new Exception("Assignment not found");
       }
       _dbcontext.Students.Remove(student);
       await _dbcontext.SaveChangesAsync();
    }
}