
using Microsoft.EntityFrameworkCore;
using TaskTrackr.Contratcs.Resposne;
using TaskTrackr.Data;
using TaskTrackr.Repository.Interface;

namespace TaskTrackr.Repository;

public class StudentRepository : IStudentRepository
{
    private readonly EfCoreDbContext _dbContext;

    public StudentRepository(EfCoreDbContext context)
    {
        _dbContext = context;
    }

    public async Task<StudentResponseDto> GetStudentById(Guid id)
    {
        var students = await _dbContext.Students
            .Where(x => x.Id == id)
            .Select(x => new StudentResponseDto
            {
                StudentId = x.Id,
                FullName = x.FullName,
                Email = x.Email,
                AssignmentId = x.AssignmentId,


            }).FirstOrDefaultAsync();

        return students;
    }

    public Task<List<StudentResponseDto>> GetStudents(Guid id)
    {
        var student = _dbContext.Students
            .Select(x => new StudentResponseDto
            {
                FullName = x.FullName,
                Email = x.Email,
                AssignmentId = x.AssignmentId,
            }).ToListAsync();

        return student;
    }
}    

    