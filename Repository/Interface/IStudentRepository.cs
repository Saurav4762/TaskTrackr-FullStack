using TaskTrackr.Contratcs.Resposne;


namespace TaskTrackr.Repository.Interface;

public interface IStudentRepository
{
    Task<StudentResponseDto> GetStudentById (Guid id);
    
    Task<List<StudentResponseDto>> GetStudents(Guid id);
    
}