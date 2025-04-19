using TaskTrackr.Contratcs.Request;
using TaskTrackr.Data;
using TaskTrackr.Repository.Interface;

namespace TaskTrackr.Repository;

public class StudentRepository : IStudentRepository
{
    private readonly EfCoreDbContext _context;
    public Task<StudentRequestDto> GetStudentByID(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<StudentRequestDto>> GetStudents(int id)
    {
        throw new NotImplementedException();
    }
}