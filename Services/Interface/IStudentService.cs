using TaskTrackr.Contratcs.Request;
using TaskTrackr.Entities;

namespace TaskTrackr.Services.Interface;

public interface IStudentService
{
    Task<Student> AddStudentAsync(StudentRequestDto dto);
    
    Task<Student> UpdateStudentAsync(int id, StudentRequestDto dto);
    
    Task DeleteStudentAsync(int id);
    
}