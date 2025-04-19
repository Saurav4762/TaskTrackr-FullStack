namespace TaskTrackr.Entities;

public class Assignment
{
    public Guid Id { get; set; }
    
    public string AssignmentName { get; set; }
    
    public string AssignmentDescription { get; set; }
    
    public DateTime AssignmentDate { get; set; }
    public bool AssignmentStatus { get; set; }
    public Guid StudentId { get; set; }
    
    public virtual Student Student { get; set; }
}