namespace TaskTrackr.Contratcs.Resposne;

public class AssignmentResponseDto
{
    public Guid AssignmentId { get; set; }
    
    public string AssignmentDescription { get; set; }
    
    public string AssingnmentName { get; set; }
    
    public DateTime AssignmentDate { get; set; }
    public bool AssignmentStatus { get; set; }
    public Guid StudentId { get; set; }
}