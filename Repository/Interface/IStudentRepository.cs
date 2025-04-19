using TaskTrackr.Contratcs.Request;
using TaskTrackr.Entities;

namespace TaskTrackr.Repository.Interface;

public interface IStudentRepository
{
    Task<StudentRequestDto> GetStudentByID (int id);
    
    Task<List<StudentRequestDto>> GetStudents(int id);
    
}