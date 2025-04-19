namespace TaskTrackr.Contratcs.Request;

public class StudentRequestDto
{
    
    public Guid StudentId { get; set; }
    public string? FullName  { get; set; }
    
    public string? Email { get; set; }
    
    public Guid AssignmentId { get; set; }
    
}